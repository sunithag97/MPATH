import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PatientDetailsModalComponent } from './patient-details-modal.component';

describe('PatientDetailsModalComponent', () => {
  let component: PatientDetailsModalComponent;
  let fixture: ComponentFixture<PatientDetailsModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PatientDetailsModalComponent]
    });
    fixture = TestBed.createComponent(PatientDetailsModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
