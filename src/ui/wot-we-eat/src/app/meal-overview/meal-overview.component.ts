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
  currentPage = 1;
  itemsPerPage = 4; // This can be changed to test different resolutions
  paginationWindowStart = 1;
  paginationWindowEnd = 3;
  selectedMeal: number | null = null;
  isLoading = false;

  constructor(private location: Location,
    private router: Router,
    private mealService: MealService) { }

  ngOnInit(): void {
    this.isLoading = true; 
    this.refreshMeals();
  }

  private refreshMeals() {
    this.mealService.getAllMeals().subscribe({
      next: (data: Meal[]) => {
        this.meals = data;
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

  addMeal(): void {
    // Logic to add a new meal option
    // For example, navigate to a form
    this.router.navigate(['/meal-form', 'new']);
  }

  editMealOption(mealOptionId: string): void {
    this.router.navigate(['/meal-option-form', mealOptionId]);
  }

  get paginatedMealOptions() {
    const startIndex = (this.currentPage - 1) * this.itemsPerPage;
    
    //debug
    //console.log('currrentpage: ' + this.currentPage);
    //console.log('startindex: ' + startIndex + ' items per page: ' + this.itemsPerPage);
    //console.log(this.mealOptions.slice(startIndex, startIndex + this.itemsPerPage));
    return this.meals.slice(startIndex, startIndex + this.itemsPerPage);
  }

  get totalPages() {
    return Math.ceil(this.meals.length / this.itemsPerPage);
  }

  goToPage(page: number): void {
    this.selectedMeal = null;
    this.currentPage = page;
  }

  nextPage(): void {
    //console.log(this.currentPage + ' - ' + this.totalPages);
    this.selectedMeal = null;
    if (this.currentPage < this.totalPages) {
      this.currentPage++;
    }
  }

  previousPage(): void {
    if (this.currentPage > 1) {
      this.currentPage--;
    }
  }

  get paginatedMeals() {
    const startIndex = (this.currentPage - 1) * this.itemsPerPage;
    
    return this.meals.slice(startIndex, startIndex + this.itemsPerPage);
  }

  getDisplayedPages() {
    let startPage: number, endPage: number;
  
    if (this.totalPages <= this.paginationWindowEnd) {
      // If total pages are 3 or less, show all pages
      startPage = 1;
      endPage = this.totalPages;
    } else {
      // For more than 3 pages, calculate window around current page
      if (this.currentPage === 1) {
        // If on the first page
        startPage = 1;
        endPage = this.paginationWindowEnd;
      } else if (this.currentPage === this.totalPages) {
        // If on the last page
        startPage = this.totalPages - 2;
        endPage = this.totalPages;
      } else {
        // For all other cases
        startPage = this.currentPage - 1;
        endPage = this.currentPage + 1;
      }
    }
  
    return Array.from({ length: (endPage + 1) - startPage }, (_, i) => startPage + i);
  }

  togglePanel(index: number): void {
    this.selectedMeal = this.selectedMeal === index ? null : index;
  }
}
