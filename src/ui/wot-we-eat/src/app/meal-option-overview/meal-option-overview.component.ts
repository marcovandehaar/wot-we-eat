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
    {id:"1", description: '1This is a meal option with potatoes and...' },
    {id:"2", description: '2Another meal with another description bla bla bla' },
    {id:"3", description: '3Gekookte aardappelen, snijbonen en rundervink' },
    {id:"4", description: '4This is a meal option with potatoes and...' },
    {id:"5", description: '5Another meal with another description bla bla bla' },
    {id:"6", description: '6Gekookte aardappelen, snijbonen en rundervink' },
    {id:"7", description: '7This is a meal option with potatoes and...' },
    {id:"8", description: '8Another meal with another description bla bla bla' },
    {id:"9", description: '9Gekookte aardappelen, snijbonen en rundervink' },
    {id:"11", description: '10This is a meal option with potatoes and...' },
    {id:"12", description: '11Another meal with another description bla bla bla' },
    {id:"13", description: '12Gekookte aardappelen, snijbonen en rundervink' },
    {id:"14", description: '13This is a meal option with potatoes and...' },
    {id:"15", description: '14Another meal with another description bla bla bla' },
    {id:"16", description: '15Gekookte aardappelen, snijbonen en rundervink' },
    {id:"17", description: '16This is a meal option with potatoes and...' },
    {id:"18", description: '17Another meal with another description bla bla bla' },
    {id:"19", description: '18Gekookte aardappelen, snijbonen en rundervink' },
    // ... more dummy meal options
  ];

  currentPage = 1;
  itemsPerPage = 4; // This can be changed to test different resolutions
  paginationWindowStart = 1;
  paginationWindowEnd = 3;
  selectedMealOption: number | null = null;

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
    this.selectedMealOption = null;
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
    this.selectedMealOption = this.selectedMealOption === index ? null : index;
  }
  
}