import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChildrenToggleComponent } from './children-toggle.component';

describe('ChildrenToggleComponent', () => {
  let component: ChildrenToggleComponent;
  let fixture: ComponentFixture<ChildrenToggleComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ChildrenToggleComponent]
    });
    fixture = TestBed.createComponent(ChildrenToggleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
