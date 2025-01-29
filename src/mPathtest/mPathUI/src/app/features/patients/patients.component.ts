import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PatientDetailsModalComponent } from '../patient-details-modal/patient-details-modal.component';
import { AddPatientModalComponent } from '../add-patient-modal/add-patient-modal.component';
import { Patient } from 'src/app/shared/models/patient.model';
import { PatientService } from 'src/app/shared/services/patient.service';
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: 'app-patients',
  templateUrl: './patients.component.html',
  styleUrls: ['./patients.component.css']
})
export class PatientsComponent implements OnInit {
  patients: Patient[] = [];
  filteredPatients: Patient[] = [];
  searchQuery: string = '';
  currentPage: number = 1;
  itemsPerPage: number = 10;
  displayedColumns: string[] = ['id', 'name'];
  isAdmin: boolean = false;

  constructor(
    private patientService: PatientService,
    public dialog: MatDialog,
    private authService: AuthService
  ) { }

  ngOnInit(): void {
    this.isAdmin = this.authService.isAdmin();
    this.patientService.getPatients().subscribe((data: Patient[]) => {
      this.patients = data;
      this.filteredPatients = data;
    });
  }

  onSearch(): void {
    this.filteredPatients = this.patients.filter(patient =>
      patient.name.toLowerCase().includes(this.searchQuery.toLowerCase()) ||
      patient.id.toString().includes(this.searchQuery)
    );
  }

  onPageChange(page: number): void {
    this.currentPage = page;
  }

  openPatientDetails(patient: Patient): void {
    this.dialog.open(PatientDetailsModalComponent, {
      width: '400px',
      data: patient
    });
  }

  openAddPatientDialog(): void {
    const dialogRef = this.dialog.open(AddPatientModalComponent, {
      width: '400px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.patients.push(result);
        this.patientService.getPatients().subscribe((data: Patient[]) => {
          this.patients = data;
          this.filteredPatients = data;
        });
      }
    });
  }
}