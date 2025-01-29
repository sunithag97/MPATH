import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Patient } from 'src/app/shared/models/patient.model';
import { Recommendation } from 'src/app/shared/models/recommendation.model';
import { PatientService } from 'src/app/shared/services/patient.service';

@Component({
  selector: 'app-patient-details-modal',
  templateUrl: './patient-details-modal.component.html',
  styleUrls: ['./patient-details-modal.component.css']
})
export class PatientDetailsModalComponent {
  constructor(
    private patientService: PatientService,
    public dialogRef: MatDialogRef<PatientDetailsModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Patient
  ) {}

  onClose(): void {
    this.dialogRef.close();
  }


  toggleRecommendationCompletion(recommendation: Recommendation): void {
    recommendation.completed = !recommendation.completed;
    this.patientService.updatePatient(this.data).subscribe();
  }
}