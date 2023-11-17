import { Component, Provider, forwardRef } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

const FAMILY_TOGGLE_VALUE_ACCESSOR: Provider = {
  provide: NG_VALUE_ACCESSOR,
  useExisting: forwardRef(()=>ChildrenToggleComponent),
  multi:true,
}


@Component({
  selector: 'app-children-toggle',
  templateUrl: './children-toggle.component.html',
  styleUrls: ['./children-toggle.component.scss'],
  providers: [FAMILY_TOGGLE_VALUE_ACCESSOR],
})
export class ChildrenToggleComponent implements ControlValueAccessor{
  suitebleForChildren!: boolean;
  
  private onChange!: Function;
  private onTouched!: Function;
  
  getImageName()
  {
    if(this.suitebleForChildren)
    {
      return 'family-color.png';
    } else {
      return 'family-grey.png';
    }
  }
  GetTitle()
  {
    if(this.suitebleForChildren)
    {
      return 'Voor het hele gezin!';
    } else {
      return 'Alleen voor de ouders.';
    }
  }

  click() {
    this.suitebleForChildren = !this.suitebleForChildren;
    this.onChange(this.suitebleForChildren);
  }

  writeValue(obj: boolean): void {
    this.suitebleForChildren = obj;
  }
  registerOnChange(fn: any): void {
    this.onChange = (check:boolean) => {fn(check);};
  }
  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

}
