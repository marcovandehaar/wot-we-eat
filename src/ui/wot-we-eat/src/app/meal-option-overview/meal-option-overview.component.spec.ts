import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MealOptionOverviewComponent } from './meal-option-overview.component';

describe('MealOptionOverviewComponent', () => {
  let component: MealOptionOverviewComponent;
  let fixture: ComponentFixture<MealOptionOverviewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MealOptionOverviewComponent]
    });
    fixture = TestBed.createComponent(MealOptionOverviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
