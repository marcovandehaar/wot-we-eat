import {
  Component,
  EventEmitter,
  Input,
  OnInit,
  OnChanges,
  Output,
  SimpleChanges,
  ChangeDetectionStrategy,
} from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { MealService } from '../services/meal.service'; 
import { GroupedMeatFish, MealOption, MeatFish, Vegetable } from '../models/meal-option.model';
import { mealBaseValues, seasons } from '../models/enums';
import { Location } from '@angular/common';
import { Validators } from '@angular/forms';


@Component({
  selector: 'meal-option-form',
  templateUrl: './meal-option-form.component.html',
  styleUrls: ['./meal-option-form.component.scss'],
  //changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MealOptionFormComponent implements OnInit {
  mealBases = mealBaseValues;
  mealOptionForm =  this.fb.nonNullable.group({
    id: '',
    description: ['', Validators.required],
    mealBase: '',
    amountOfWork: 1,
    healthy:'',
    suitableForChildren:true,
    vegetables:<Vegetable[]|null>null,
    meatFishes:<MeatFish[]|null>null,
    seasons:  new FormControl(seasons.map(season => season.value)),
    active:false,
  });
  vegetables: Vegetable[] = [];
  groupedMeatFishes: GroupedMeatFish[] = [];

  constructor(
    private route: ActivatedRoute, 
    private router: Router, 
    private mealService: MealService,
    private fb: FormBuilder,
    private location: Location,) { }
    isSaving = false;
    formSubmitted = false;
    dots = '';
    

    ngOnInit() {
      this.mealService.getAllVegetables().subscribe(vegetables => {
        this.vegetables = vegetables;
      });
      this.mealService.getGroupedMeatFishes().subscribe(groupedMeatFishes => {
        console.log('Meatfishes:', groupedMeatFishes);
        this.groupedMeatFishes = groupedMeatFishes;
      });

      this.route.paramMap.subscribe(params => {
        const id = params.get('id');
        if (id) {
          this.mealService.getMealOption(id).subscribe((mealOption)=>
        {
          if(!mealOption)
          return;
          
          //when you want to start the form only partially filled with values, patch!
          //const names = {firstName: contact.firstName, lastName: contact.lastName}
          //this.contactForm.patchValue(names);
          
          this.mealOptionForm.setValue(mealOption);
        }
      );
        } else {
          // Initialize form for creating a new meal option
        }
      });
    }

  
  saveMealOption(): void {
    this.formSubmitted = true;
    if (this.mealOptionForm.valid) {
      this.startSaving();
      console.log('Saving mealOption:', this.mealOptionForm.getRawValue());

      
      this.mealService.saveMealOption(this.mealOptionForm.getRawValue()).subscribe({
        next: (response) => {
          console.log('MealOption saved:', response);
          // Handle success, maybe navigate the user or show a success message.
          this.doneSaving();
        },
        error: (error) => {
          console.error('Error saving MealOption:', error);
          // Handle error, show an error message to the user.
          this.doneSaving();
        },
        complete: () => {
          // Handle completion if needed.
          this.doneSaving();
        }
      }); 
    } else {
      // Optionally, handle the invalid form case (e.g., show an error message)
      console.error('The form is invalid');
    }
  }

  private startSaving(){
    this.isSaving = true;    
    this.animateDots();
  }

  private doneSaving(){    
    this.isSaving = false;
    this.dots = '';    
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

  get selectedWorkAmountDescription(): string {
    const control = this.mealOptionForm.get('amountOfWork');

    if (control && control.value !== null && control.value !== undefined) {
        const valueAsNumber = Number(control.value);

        if (!isNaN(valueAsNumber)) {
            if (valueAsNumber <= 0) {
                return "Geen werk!";
            } else if (valueAsNumber > 0 && valueAsNumber <= 1) {
                return "Maar een paar minuten werk!";
            } else if (valueAsNumber > 1 && valueAsNumber <= 3) {
                return "Gemiddeld!";
            } else if (valueAsNumber > 3 && valueAsNumber <= 4) {
                return "Erg veel werk!";
            } else if (valueAsNumber > 4) {
                return "Donders veel werk!";
            }
        }
    }

    return ''; 
}


  

  goBack(): void {
    this.location.back();
  }
}
