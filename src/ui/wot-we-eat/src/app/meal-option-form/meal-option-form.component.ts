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
import { FormGroup, FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { MealService } from '../services/meal.service'; 
import { MealOption } from '../models/meal-option.model';
import { mealBaseValues } from '../models/meal-base';
import { amountOfWorkValues } from '../models/amount-of-work';




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
    amountOfWork: '',
    healthy:'',
  });

  constructor(
    private route: ActivatedRoute, 
    private router: Router, 
    private mealService: MealService,
    private fb: FormBuilder) { }
    

    ngOnInit() {
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
    console.log(this.mealOptionForm.value);
    
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

  

  goBack(): void {
    this.router.navigate(['/main']);
  }
}
