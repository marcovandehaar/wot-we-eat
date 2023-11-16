import { Component } from '@angular/core';
import { HealtyOption, healtyOptions } from '../healthy-options';

@Component({
  selector: 'app-healthy-selector',
  templateUrl: './healthy-selector.component.html',
  styleUrls: ['./healthy-selector.component.scss']
})
export class HealthySelectorComponent {
  healthyOptions = healtyOptions;
  selectedOption!: HealtyOption|null;

  getImageName(option: HealtyOption)
  {
    if(this.selectedOption!=null && this.selectedOption.value==option.value)
    {
      return 'apple-green.png';
    } else {
      return 'apple-grey.png';
    }
  }
}


