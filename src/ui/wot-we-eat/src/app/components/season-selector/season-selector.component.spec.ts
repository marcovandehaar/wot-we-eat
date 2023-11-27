import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SeasonSelectorComponent } from './season-selector.component';

describe('SeasonSelectorComponent', () => {
  let component: SeasonSelectorComponent;
  let fixture: ComponentFixture<SeasonSelectorComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SeasonSelectorComponent]
    });
    fixture = TestBed.createComponent(SeasonSelectorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
