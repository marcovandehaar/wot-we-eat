import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HealthySelectorComponent } from './healthy-selector.component';

describe('HealthySelectorComponent', () => {
  let component: HealthySelectorComponent;
  let fixture: ComponentFixture<HealthySelectorComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HealthySelectorComponent]
    });
    fixture = TestBed.createComponent(HealthySelectorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
