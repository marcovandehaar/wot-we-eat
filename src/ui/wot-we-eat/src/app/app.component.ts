import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'wot-we-eat';
  menuOpen = false;

  constructor(private router: Router) { }

  openContextMenu() {
      this.menuOpen = !this.menuOpen;
  }

  closeMenu(){
    this.menuOpen = false;
  }

  navigateToMealOptionOverview(): void {
    this.router.navigate(['/meal-option-overview']);
    this.closeMenu();
  }

  navigateToMain(): void {
    this.router.navigate(['/main']);
    this.closeMenu();
  }

  navigateToMealOverview(): void {
    this.router.navigate(['/meal-overview']);
    this.closeMenu();
  }
  
}
