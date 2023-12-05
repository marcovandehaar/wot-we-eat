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

  isMenuOpen() {
    return this.menuOpen ? 'open' : '';
  }

  navigateToMealOptionOverview(): void {
    this.router.navigate(['/meal-option-overview']);
  }

  navigateToMain(): void {
    this.router.navigate(['/main']);
  }
}
