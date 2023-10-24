import { Component } from '@angular/core';

@Component({
  selector: 'app-main-screen',
  templateUrl: './main-screen.component.html',
  styleUrls: ['./main-screen.component.scss']
})
export class MainScreenComponent {
  
  suggestMeal() {
    console.log('Suggest Meal clicked');
    // Implement your logic here
  }

  enterMeal() {
    console.log('Enter Meal clicked');
    // Implement your logic here
  }

}