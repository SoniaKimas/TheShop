import { AbstractControl, FormArray, ValidationErrors, ValidatorFn } from '@angular/forms';

export function nonEmptyArrayValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    if (control instanceof FormArray) {
      const hasValue = control.controls.some(c => c.value);
      return hasValue ? null : { nonEmptyArray: true };
    }
    return null;
  };
}
