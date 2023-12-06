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
    { description: '1This is a meal option with potatoes and...' },
    { description: '2Another meal with another description bla bla bla' },
    { description: '3Gekookte aardappelen, snijbonen en rundervink' },
    { description: '4This is a meal option with potatoes and...' },
    { description: '5Another meal with another description bla bla bla' },
    { description: '6Gekookte aardappelen, snijbonen en rundervink' },
    { description: '7This is a meal option with potatoes and...' },
    { description: '8Another meal with another description bla bla bla' },
    { description: '9Gekookte aardappelen, snijbonen en rundervink' },
    { description: '10This is a meal option with potatoes and...' },
    { description: '11Another meal with another description bla bla bla' },
    { description: '12Gekookte aardappelen, snijbonen en rundervink' },
    { description: '13This is a meal option with potatoes and...' },
    { description: '14Another meal with another description bla bla bla' },
    { description: '15Gekookte aardappelen, snijbonen en rundervink' },
    { description: '16This is a meal option with potatoes and...' },
    { description: '17Another meal with another description bla bla bla' },
    { description: '18Gekookte aardappelen, snijbonen en rundervink' },
    // ... more dummy meal options
  ];

  currentPage = 1;
  itemsPerPage = 4; // This can be changed to test different resolutions
  paginationWindowStart = 1;
  paginationWindowEnd = 3;

  constructor(private location: Location) {}

  goBack(): void {
    this.location.back();
  }

  get paginatedMealOptions() {
    const startIndex = (this.currentPage - 1) * this.itemsPerPage;
    console.log('currrentpage: ' + this.currentPage);
    console.log('startindex: ' + startIndex + ' items per page: ' + this.itemsPerPage);
    console.log(this.mealOptions.slice(startIndex, startIndex + this.itemsPerPage));
    return this.mealOptions.slice(startIndex, startIndex + this.itemsPerPage);
  }

  get totalPages() {
    return Math.ceil(this.mealOptions.length / this.itemsPerPage);
  }

  goToPage(page: number): void {
    this.currentPage = page;
  }

  nextPage(): void {
    console.log(this.currentPage + ' - ' + this.totalPages);
    if (this.currentPage < this.totalPages) {
      this.currentPage++;
    }
  }

  previousPage(): void {
    if (this.currentPage > 1) {
      this.currentPage--;
    }
  }

  getDisplayedPages() {
    // Ensure we don't exceed the total number of pages
    const endPage = Math.min(this.paginationWindowEnd, this.totalPages);
    // Adjust the start page if necessary
    const startPage = Math.max(endPage - (this.paginationWindowEnd - this.paginationWindowStart), 1);
  
    return Array.from({ length: endPage - startPage + 1 }, (_, i) => startPage + i);
  }
  
  updatePaginationWindow(direction: 'next' | 'previous') {
    const step = this.paginationWindowEnd - this.paginationWindowStart;
    if (direction === 'next' && this.paginationWindowEnd < this.totalPages) {
      this.paginationWindowStart = Math.min(this.paginationWindowStart + step, this.totalPages - step);
      this.paginationWindowEnd = Math.min(this.paginationWindowEnd + step, this.totalPages);
    } else if (direction === 'previous' && this.paginationWindowStart > 1) {
      this.paginationWindowStart = Math.max(this.paginationWindowStart - step, 1);
      this.paginationWindowEnd = Math.max(this.paginationWindowEnd - step, step + 1);
    }
  }
  
}