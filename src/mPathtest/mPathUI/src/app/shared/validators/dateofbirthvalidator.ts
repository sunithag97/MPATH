import { AbstractControl, ValidatorFn } from '@angular/forms';

export function dateOfBirthValidator(): ValidatorFn {
  return (control: AbstractControl): { [key: string]: any } | null => {
    const today = new Date();
    const dob = new Date(control.value);
    return dob > today ? { 'invalidDateOfBirth': { value: control.value } } : null;
  };
}