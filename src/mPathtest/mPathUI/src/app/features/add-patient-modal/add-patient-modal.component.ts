import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PatientService } from 'src/app/shared/services/patient.service';
import { dateOfBirthValidator } from 'src/app/shared/validators/dateofbirthvalidator';
@Component({
  selector: 'app-add-patient-modal',
  templateUrl: './add-patient-modal.component.html',
  styleUrls: ['./add-patient-modal.component.css']
})
export class AddPatientModalComponent {
  addPatientForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private patientService: PatientService,
    public dialogRef: MatDialogRef<AddPatientModalComponent>
  ) {
    this.addPatientForm = this.fb.group({
      name: ['', Validators.required],
      dateOfBirth: ['', [Validators.required, dateOfBirthValidator()]],
      gender: ['', Validators.required]
    });
  }

  onAddPatient(): void {
    if (this.addPatientForm.invalid) return;

    const newPatient = this.addPatientForm.value;

    this.patientService.addPatient(newPatient)
    .subscribe(response => {
      this.dialogRef.close(newPatient);
    },
    error => {
      // Handle error
      alert('Error adding patient'+ newPatient.name);
      this.dialogRef.close(newPatient);
    });
  }
  
  onClose(): void {
    this.dialogRef.close();
  }
}