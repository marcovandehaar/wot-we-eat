import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MealOverviewComponent } from './meal-overview.component';

describe('MealOverviewComponent', () => {
  let component: MealOverviewComponent;
  let fixture: ComponentFixture<MealOverviewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MealOverviewComponent]
    });
    fixture = TestBed.createComponent(MealOverviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
