import { Component, Provider, forwardRef } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { seasons } from '../../models/enums';

const SEASON_SELECTOR_VALUE_ACCESSOR: Provider = {
  provide: NG_VALUE_ACCESSOR,
  useExisting: forwardRef(()=>SeasonSelectorComponent),
  multi:true,
}

@Component({
  selector: 'app-season-selector',
  templateUrl: './season-selector.component.html',
  styleUrls: ['./season-selector.component.scss'],
  providers: [SEASON_SELECTOR_VALUE_ACCESSOR] 
})
export class SeasonSelectorComponent implements ControlValueAccessor{
  seasons = seasons;
  selectedSeasons!: string[]|null;

  private onChange!: Function;
  private onTouched!: Function;
  
  
  selectSeason(season: string): void {
    // Check if the season is a valid value
    const isValidSeason = seasons.some(s => s.value === season);
  
    if (isValidSeason) {
      if (!this.selectedSeasons) {
        this.selectedSeasons = [];
      }
  
      const index = this.selectedSeasons.indexOf(season);
      if (index >= 0) {
        this.selectedSeasons.splice(index, 1); // Remove the season if it's already selected
      } else {
        this.selectedSeasons.push(season); // Add the season if it's not already selected
      }
      this.onChange(this.selectedSeasons); // Update form control value
      this.onTouched(); // Mark as touched
    } else {
      console.warn('Invalid season:', season); // Optional: handle invalid season
    }
  }
  
  

  writeValue(selectedSeasons: string[] | null): void {
    this.selectedSeasons = selectedSeasons || [];
  }
  
  registerOnChange(fn: any): void {
    this.onChange = fn;
  }
  
  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  getImageName(option: string) {
    // Find the corresponding 'value' for the given 'option'
    const seasonItem = seasons.find(s => s.value === option);
      // Ensure seasonItem is defined and get the 'value'
    const seasonValue = seasonItem ? seasonItem.value : null;
    if (seasonValue) {
      // Initialize selectedSeasons as an empty array if it's null
      const selectedSeasons = this.selectedSeasons || [];
        // Check if the season 'value' is in the selectedSeasons array
      const isSelected = selectedSeasons.includes(seasonValue);
        // Convert the 'value' to lowercase for the image name
      const imageName = seasonValue.toLowerCase();
        // Return the image path based on the selected state
      return `${imageName}${isSelected ? '' : '-disabled'}.png`;
    }
      // Return a default image or handle the case where no season is found
    return 'default-image.png'; // or handle this case appropriately
  }
  
  getSelectedSeasonTitles(): string {
    // Provide an empty array as a default if this.selectedSeasons is null or undefined
    const selectedSeasons = this.selectedSeasons ?? [];
  
    return selectedSeasons
      .map(value => seasons.find(season => season.value === value)?.title || '')
      .filter(title => title) // Filter out any empty titles
      .join(', ');
  }
  
  
  
  
}
