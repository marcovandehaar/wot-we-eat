import { Component } from '@angular/core';
import { Location } from '@angular/common';


@Component({
  selector: 'app-meal-option-overview',
  templateUrl: './meal-option-overview.component.html',
  styleUrls: ['./meal-option-overview.component.scss']
})
export class MealOptionOverviewComponent {
  // Assuming mealOptions is an array of meal options you will retrieve
  mealOptions = [
    { description: 'This is a meal option with potatoes and...' },
    // ... more dummy meal options
  ];

  constructor(private location: Location) {}

  goBack(): void {
    this.location.back(); // Use Angular's Location service to navigate back
  }
}
