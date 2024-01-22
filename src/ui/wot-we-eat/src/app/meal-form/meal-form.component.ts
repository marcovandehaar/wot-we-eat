// meal-form.component.ts

import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MealService } from '../services/meal.service'; // Update the path to your service
import { GroupedMeatFish, MealOption, MeatFish } from '../models/meal-option.model'; // Update the path to your model
import { Meal } from '../models/meal';
import { Location } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { suggestionStatus } from '../models/enums';
import * as moment from 'moment';


@Component({
  selector: 'app-meal-form',
  templateUrl: './meal-form.component.html',
  styleUrls: ['./meal-form.component.scss']
})
export class MealFormComponent implements OnInit {
  mealForm = this.fb.nonNullable.group({
    id: '00000000-0000-0000-0000-000000000000',
    mealOption: [<MealOption|null>null, Validators.required],
    date: [<Date> moment(new Date()).toDate(), Validators.required],
    selectedMeatFishes: <MeatFish[] | null>null,
    suggestionStatus: 'Suggested'
  });
  mealOptions: MealOption[] = []; // Populate this with actual data
  meatFishes: MeatFish[] = []; // Populate this with actual data
  isSaving = false;
  formSubmitted = false;
  dots = '';
  isLoading = false;
  groupedMeatFishes: GroupedMeatFish[] = [];

  constructor(
    private fb: FormBuilder,
    private mealService: MealService,
    private location: Location,
    private route: ActivatedRoute

  ) { }

  ngOnInit(): void {
    this.isLoading = true;

    this.route.queryParams.subscribe(params => {
      const dateParam = params['date'];
      console.log('Provided date: '+ dateParam);
      if (dateParam) {
        this.mealForm.patchValue({ date: new Date(dateParam) });
      }
    });

    this.mealService.getAllMealOptions(true) // Pass true to get only active meal options
      .subscribe({
        next: (mealOptions: MealOption[]) => {
          this.mealOptions = mealOptions;
          this.isLoading = false;
        },
        error: (error) => {
          console.error('Error fetching active meal options', error);
          this.isLoading = false;
        }
      });

    const mealOptionControl = this.mealForm.get('mealOption');
    if (mealOptionControl) {
      mealOptionControl.valueChanges.subscribe(mealOptionId => {
        this.onMealOptionChange(mealOptionId);
      });
    }

    this.route.paramMap.subscribe(params => {
      const mealId = params.get('id');
      if (mealId) {
        // Fetch the meal data for the given id
        console.log('loading meal with id' + mealId);
        this.loadMeal(mealId);
      }
    });
  }


  saveMeal(): void {
    this.startSaving();
    if (this.mealForm.valid) {
      // Call service to save the meal
      const meal: Meal = this.mealForm.getRawValue();
      this.mealService.saveMeal(meal).subscribe({
        next: (savedMeal) => {
          // Handle success
          console.log('Meal saved successfully', savedMeal);
          this.doneSaving();
        },
        error: (error) => {
          // Handle error
          console.error('Error saving meal', error);
        },
        complete: () => {
          // Handle completion if needed.
          this.doneSaving();
        }
      });
    } else {
      // Handle validation errors
      console.error('Form is not valid');
    }
  }

  goBack(): void {
    this.location.back();
  }

  private startSaving() {
    this.isLoading = true;
    this.isSaving = true;
    this.animateDots();
  }

  private doneSaving() {
    this.isSaving = false;
    this.dots = '';
    this.isLoading = false;
    this.location.back();
  }

  private animateDots() {
    let dotCount = 0;
    const interval = setInterval(() => {
      dotCount = (dotCount + 1) % 4; // Cycle through 0 to 3
      this.dots = '.'.repeat(dotCount);
      if (!this.isSaving) {
        clearInterval(interval);
      }
    }, 500); // Change the speed of animation as needed
  }

  private onMealOptionChange(mealOption: MealOption | null): void {
    console.log('Changed mealoption: ');
    console.log(mealOption);
    if (mealOption) {


      if (mealOption && mealOption.possibleMeatFishes) {
        // Group the meat fishes by type
        this.groupedMeatFishes = this.mealService.groupMeatFishesByType(mealOption.possibleMeatFishes);
      } else {
        // Reset groupedMeatFishes if no valid selection
        this.groupedMeatFishes = [];
      }
    }
    else {
      this.groupedMeatFishes = [];

    }
  }

  loadMeal(mealId: string): void {
    this.mealService.getMeal(mealId).subscribe({
      next: (meal: Meal) => {
        if (meal) {
          console.log(meal);
          meal.date = moment(meal.date).toDate();
          // Populate the form with the fetched meal data
          this.mealForm.setValue(meal);
          // Handle any transformations or additional logic needed for the form
        }
        this.isLoading = false;
      },
      error: (error) => {
        console.error('Error fetching meal', error);
        this.isLoading = false;
      }
    });
  }
}

