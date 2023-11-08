import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MealOptionFormComponent } from './meal-option-form.component';

describe('AddMealComponent', () => {
  let component: MealOptionFormComponent;
  let fixture: ComponentFixture<MealOptionFormComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MealOptionFormComponent]
    });
    fixture = TestBed.createComponent(MealOptionFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
