import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'wot-we-eat';
  menuOpen = false;

  openContextMenu() {
      this.menuOpen = !this.menuOpen;
  }

  isMenuOpen() {
    return this.menuOpen ? 'open' : '';
  }
}
