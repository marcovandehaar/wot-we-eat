import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-meal',
  templateUrl: './add-meal.component.html',
  styleUrls: ['./add-meal.component.scss']
})
export class AddMealComponent {

  constructor(private router: Router) { }

  goBack(): void {
    this.router.navigate(['/main']);
  }
}
