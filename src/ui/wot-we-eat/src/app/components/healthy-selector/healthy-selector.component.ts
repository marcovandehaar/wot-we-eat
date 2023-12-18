import { Component, Provider, forwardRef } from '@angular/core';
import { HealthyOption, healtyOptions } from '../healthy-options';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

const HEALTHY_SELECTOR_VALUE_ACCESSOR: Provider = {
  provide: NG_VALUE_ACCESSOR,
  useExisting: forwardRef(()=>HealthySelectorComponent),
  multi:true,
}

@Component({
  selector: 'app-healthy-selector',
  templateUrl: './healthy-selector.component.html',
  styleUrls: ['./healthy-selector.component.scss'],
  providers: [HEALTHY_SELECTOR_VALUE_ACCESSOR],
})
export class HealthySelectorComponent implements ControlValueAccessor{

  healthyOptions = healtyOptions;
  selectedOption!: HealthyOption|null;

  private onChange!: Function;
  private onTouched!: Function;

  isActive(option: HealthyOption)
  {
    if(this.selectedOption!=null && this.selectedOption.id>=option.id)
    {
      return true;
    } else {
      return false;
    }
  }

  optionSelected(option: HealthyOption) {
    this.selectedOption = option;
    this.onChange(option.value);
  }

  writeValue(optionValue: string | null): void {
    this.selectedOption = healtyOptions.find(option => option.value === optionValue) || null;
  }

  registerOnChange(fn: Function): void {
    this.onChange = (icon:string) => {fn(icon);};
  }
  registerOnTouched(fn: Function): void {
    this.onTouched = fn;
  }
}


