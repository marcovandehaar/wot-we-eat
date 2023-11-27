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
import { amountOfWorkValues } from '../models/enums';




@Component({
  selector: 'meal-option-form',
  templateUrl: './meal-option-form.component.html',
  styleUrls: ['./meal-option-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MealOptionFormComponent implements OnInit {
  mealBases = mealBaseValues;
  amountOfWorkValues = amountOfWorkValues;
  mealOptionForm =  this.fb.nonNullable.group({
    id: '',
    description: '', 
    mealBase: '',
    amountOfWork: '1',
    healthy:'',
    suitableForChildren:true,
    vegetables:<Vegetable[]|null>null,
    meatFishes:<MeatFish[]|null>null,
    seasons:  new FormControl(seasons.map(season => season.value)),
  });
  vegetables: Vegetable[] = [];
  groupedMeatFishes: GroupedMeatFish[] = [];

  constructor(
    private route: ActivatedRoute, 
    private router: Router, 
    private mealService: MealService,
    private fb: FormBuilder) { }
    

    ngOnInit() {
      this.mealService.getAllVegetables().subscribe(vegetables => {
        this.vegetables = vegetables;
      });
      this.mealService.getGroupedMeatFishes().subscribe(groupedMeatFishes => {
        console.log('Meatfishes:', groupedMeatFishes);
        this.groupedMeatFishes = groupedMeatFishes;
      });

      const mealOptionId = this.route.snapshot.params['id'];
      if (!mealOptionId) return          
      this.mealService.getMealOption(mealOptionId).subscribe((mealOption)=>
        {
          if(!mealOption)
          return;
          
          //when you want to start the form only partially filled with values, patch!
          //const names = {firstName: contact.firstName, lastName: contact.lastName}
          //this.contactForm.patchValue(names);
          
          this.mealOptionForm.setValue(mealOption);
        }
      );
    }

  
  saveMealOption(): void {
    console.log('saveMealOption called');
    
    this.mealService.saveMealOption(this.mealOptionForm.getRawValue()).subscribe({
      next: (response) => {
        console.log('MealOption saved:', response);
        // Handle success, maybe navigate the user or show a success message.
      },
      error: (error) => {
        console.error('Error saving MealOption:', error);
        // Handle error, show an error message to the user.
      },
      complete: () => {
        // Handle completion if needed.
      }
    });
  }

  get selectedWorkAmount(): string {
    const control = this.mealOptionForm.get('amountOfWork');

    // Check if control exists and has a value
    if (control && control.value !== null && control.value !== undefined) {
        // Ensure that control.value is treated as a number
        const valueAsNumber = Number(control.value);

        // Check if the conversion to a number was successful
        if (!isNaN(valueAsNumber)) {
            const selectedOption = this.amountOfWorkValues.find(opt => opt.index === valueAsNumber);
            return selectedOption ? selectedOption.title : '';
        }
    }

    return ''; 
}


  

  goBack(): void {
    this.router.navigate(['/main']);
  }
}
