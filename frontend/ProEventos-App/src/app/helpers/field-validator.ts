import { AbstractControl, FormGroup } from "@angular/forms";
import { group } from "console";

export class FieldValidator {

    static mustMatch(controlName: string, matchingControlName: string) {
        return (group: AbstractControl) => {
            const formGroup = group as FormGroup;
            const control = formGroup.controls[controlName];
            const matchingControl = formGroup.controls[matchingControlName];

            if (matchingControl.errors && !matchingControl.errors.passMustMatch) return null

            if (control.value != matchingControl.value) {
                matchingControl.setErrors({ passMustMatch: true });
            } else {
                matchingControl.setErrors(null);
            }

            return null;
        };
    }
}
