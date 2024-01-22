import { Component, OnInit } from '@angular/core';
import { MealService } from '../services/meal.service';
import { Meal } from '../models/meal';
import { Location } from '@angular/common';
import { Router } from '@angular/router';
import { animate, state, style, transition, trigger } from '@angular/animations';

@Component({
  selector: 'app-meal-overview',
  templateUrl: './meal-overview.component.html',
  styleUrls: ['./meal-overview.component.scss'],
  animations: [
    trigger('slide', [
      state('closed', style({
        height: '0px',
        opacity: 0,
        overflow: 'hidden'
      })),
      state('open', style({
        height: '*',
        opacity: 1
      })),
      transition('closed <=> open', animate('0.3s ease-in-out'))
    ])
  ]
})
export class MealOverviewComponent implements OnInit {
  meals: Meal[] = [];
  dateBasedMeals: { date: Date; meal: Meal | null }[] = [];
  today: Date = new Date();
  currentWeekStart: Date =  new Date();
  currentPage = 1;
  itemsPerPage = 4; // This can be changed to test different resolutions
  paginationWindowStart = 1;
  paginationWindowEnd = 3;
  selectedMeal: string | null = null;
  isLoading = false;

  constructor(private location: Location,
    private router: Router,
    private mealService: MealService) { }

  ngOnInit(): void {
    this.today = new Date();
    this.currentWeekStart = this.getStartingMonday(new Date(this.today));
    this.prepareWeekMeals(this.currentWeekStart);
    this.refreshMeals();
  }

  getStartingMonday(date: Date): Date {
    const day = date.getDay();
    const diff = date.getDate() - day + (day === 0 ? -6 : 1); // adjust when day is Sunday
    return new Date(date.setDate(diff));
  }

  prepareWeekMeals(startDate: Date) {
    this.dateBasedMeals = [];
    for (let i = 0; i < 7; i++) {
      let date = new Date(startDate);
      date.setDate(date.getDate() + i);
      this.dateBasedMeals.push({ date: date, meal: null });
    }
  }

  private refreshMeals() {
    this.isLoading = true;
    this.mealService.getAllMeals().subscribe({
      next: (data: Meal[]) => {
        // Populate meals for the date range
        this.dateBasedMeals.forEach(dayData => {
          const mealForDay = data.find(meal => 
            new Date(meal.date).toDateString() === dayData.date.toDateString() &&
            (meal.suggestionStatus === 'Approved' || meal.suggestionStatus === 'Suggested'));
  
          dayData.meal = mealForDay || null;
        });
        this.isLoading = false;
      },
      error: (error) => {
        console.error('Error fetching meals', error);
        this.isLoading = false;
      }
    });
  }

  goBack(): void {
    this.location.back();
  }

  addMeal(date: Date): void {
    // Logic to add a new meal for the specified date
    // For example, navigate to a form with the date as a parameter
    this.router.navigate(['/meal-form/new'], { queryParams: { date: date.toISOString() } });
  }

  suggestMeal(date: Date): void {
    // Logic for suggesting a meal for a specific date
  }

  editMeal(mealId: string): void {
    this.router.navigate(['/meal-form', mealId]);
  }

  getMeatFishesNames(meal: Meal): string {
    return meal.selectedMeatFishes?.map(fish => fish.name).join(', ') || '';
  }

  get paginatedMealOptions() {
    const startIndex = (this.currentPage - 1) * this.itemsPerPage;
    
    //debug
    //console.log('currrentpage: ' + this.currentPage);
    //console.log('startindex: ' + startIndex + ' items per page: ' + this.itemsPerPage);
    //console.log(this.mealOptions.slice(startIndex, startIndex + this.itemsPerPage));
    return this.meals.slice(startIndex, startIndex + this.itemsPerPage);
  }

  nextWeek(): void {
    this.currentWeekStart.setDate(this.currentWeekStart.getDate() + 7);
    this.prepareWeekMeals(this.currentWeekStart);
    this.refreshMeals();
  }
  
  previousWeek(): void {
    this.currentWeekStart.setDate(this.currentWeekStart.getDate() - 7);
    this.prepareWeekMeals(this.currentWeekStart);
    this.refreshMeals();
  }

  isCurrentWeek(): boolean {
    return this.getStartingMonday(new Date()).getTime() === this.currentWeekStart.getTime();
  }

  get paginatedMeals() {
    const startIndex = (this.currentPage - 1) * this.itemsPerPage;
    
    return this.meals.slice(startIndex, startIndex + this.itemsPerPage);
  }

  togglePanel(mealDate: Date): void {
    const dateString = mealDate.toISOString();
    this.selectedMeal = this.selectedMeal === dateString ? null : dateString;
  }

  deleteMeal(mealId: string): void {
    // TODO: Implement the logic to delete a meal

    // This might involve calling a service method to delete the meal from the backend.
    // For example, if you have a service method like this.mealService.deleteMeal(mealId),
    // you can call it here and handle the response and any errors.

    
  }

}
