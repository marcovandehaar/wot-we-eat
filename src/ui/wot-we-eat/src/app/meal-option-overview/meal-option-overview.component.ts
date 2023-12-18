import { Component } from '@angular/core';
import { Location } from '@angular/common';
import { MealService } from '../services/meal.service';
import { MealOption } from '../models/meal-option.model';
import { Router } from '@angular/router';
import { trigger, state, style, transition, animate } from '@angular/animations';


@Component({
  selector: 'app-meal-option-overview',
  templateUrl: './meal-option-overview.component.html',
  styleUrls: ['./meal-option-overview.component.scss'],
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
    ]),
    trigger('simpleFade', [
      state('in', style({ opacity: 1 })),
      transition(':enter', [
        style({ opacity: 0 }),
        animate(600)
      ]),
      transition(':leave', animate(600, style({ opacity: 0 })))
    ]),
    trigger('simpleSlide', [
      state('closed', style({ height: '0px' })),
      state('open', style({ height: '*' })),
      transition('closed <=> open', animate('0.3s ease-in-out'))
    ])
  ]
})


export class MealOptionOverviewComponent {
  // Assuming mealOptions is an array of meal options you will retrieve
  mealOptions: MealOption[] = [];

  currentPage = 1;
  itemsPerPage = 4; // This can be changed to test different resolutions
  paginationWindowStart = 1;
  paginationWindowEnd = 3;
  selectedMealOption: number | null = null;

  constructor(private location: Location,
    private router: Router,
    private mealService: MealService,) {}

  mealOptionsStatus: Record<string, boolean> = {
    // Assuming default statuses are set here
    "1": true, 
    "0": false,
    // ... for all meal options
  };

  ngOnInit(): void {
    this.refreshMealOptions();
  }

  private refreshMealOptions() {
    this.mealService.getAllMealOptions().subscribe({
      next: (data: MealOption[]) => {
        this.mealOptions = data;
      },
      error: (error) => {
        console.error('Error fetching meal options', error);
      }
    });
  }

  toggleMealOptionActiveStatus(mealOptionId: string, currentlyActive: boolean): void {
    const newActiveStatus = !currentlyActive;
    const mealOption = this.mealOptions.find(option => option.mealOptionId === mealOptionId);
    console.log('udpating active for mealoption:');
    console.log(mealOption);
    console.log(mealOptionId);
    this.mealService.updateMealOptionActiveStatus(mealOptionId, newActiveStatus).subscribe({
        next: () => {
            console.log('mealOptionid:' + mealOptionId);
            const mealOption = this.mealOptions.find(option => option.mealOptionId === mealOptionId);
            
            if (mealOption) {
              //nex tdoes not work for in mem....
              mealOption.active = newActiveStatus;
            }
            
        },
        error: (err) => {
            console.error('Error updating meal option status', err);
        },
        complete: () => console.log('Request completed')
    });
    this.refreshMealOptions();
    //debug
    //console.log(this.mealOptions);
}

  goBack(): void {
    this.location.back();
  }

  get paginatedMealOptions() {
    const startIndex = (this.currentPage - 1) * this.itemsPerPage;
    
    //debug
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
    //console.log(this.currentPage + ' - ' + this.totalPages);
    this.selectedMealOption = null;
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

  editMealOption(mealOptionId: string): void {
    this.router.navigate(['/meal-option-form', mealOptionId]);
  }

  addMealOption(): void {
    // Logic to add a new meal option
    // For example, navigate to a form
    this.router.navigate(['/meal-option-form', 'new']);
  }
  
}