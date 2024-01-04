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
import { GroupedMeatFish, MealOption, MealVariation, MeatFish, Vegetable } from '../models/meal-option.model';
import { mealBaseValues, seasons } from '../models/enums';
import { Location } from '@angular/common';
import { Validators } from '@angular/forms';
import { healtyOptions } from '../components/healthy-options';


@Component({
  selector: 'meal-option-form',
  templateUrl: './meal-option-form.component.html',
  styleUrls: ['./meal-option-form.component.scss'],
  //changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MealOptionFormComponent implements OnInit {
  mealBases = mealBaseValues;
  mealOptionForm =  this.fb.nonNullable.group({
    id: '00000000-0000-0000-0000-000000000000',
    description: ['', Validators.required],
    mealBase: ['', Validators.required],
    amountOfWork: 1,
    healthy:healtyOptions[0].value,
    suitableForChildren:true,
    vegetables:<Vegetable[]|null>null,
    possibleMeatFishes:<MeatFish[]|null>null,
    inSeasons:  new FormControl(seasons.map(season => season.value)),
    active:true,
    possibleVariations: <MealVariation[]|null>null,
    
  });
  vegetables: Vegetable[] = [];
  groupedMeatFishes: GroupedMeatFish[] = [];
  isLoading = false;
  isSaving = false;
  formSubmitted = false;
  dots = '';

  constructor(
    private route: ActivatedRoute, 
    private router: Router, 
    private mealService: MealService,
    private fb: FormBuilder,
    private location: Location,) { }
    
    

    ngOnInit() {
      this.isLoading = true; 
      this.mealService.getAllVegetables().subscribe(vegetables => {
        this.vegetables = vegetables;
      });
      this.mealService.getGroupedMeatFishes().subscribe(groupedMeatFishes => {
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
          console.log('Setting value:');
          console.log(mealOption);
          this.mealOptionForm.setValue(mealOption);
          this.isLoading = false;
        }
      );
        } else {
          this.isLoading = false;
          // Initialize form for creating a new meal option
        }
      });
    }

  
  saveMealOption(): void {
    
    this.formSubmitted = true;
    if (this.mealOptionForm.valid) {
      this.startSaving();
      console.log('Saving mealOption:', this.mealOptionForm.getRawValue());

      
      const mealOptionToSave: MealOption = {
        ...this.mealOptionForm.getRawValue(),
        possibleVariations: [] // Add an empty array for PossibleVariations
      };
      this.mealService.saveMealOption(mealOptionToSave).subscribe({
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
      this.isLoading = false;
    }
  }

  private startSaving(){
    this.isLoading = true;
    this.isSaving = true;    
    this.animateDots();
  }

  private doneSaving(){    
    this.isSaving = false;
    this.dots = '';    
    this.isLoading = false;
    this.router.navigate(['/meal-option-overview']); 
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
