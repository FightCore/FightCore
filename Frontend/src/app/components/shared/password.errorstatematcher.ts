import { FormControl, NgForm, FormGroupDirective } from '@angular/forms';
import { ErrorStateMatcher } from "@angular/material/core";

export class PasswordErrorStateMatcher implements ErrorStateMatcher {
    isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
        const passwordsDontMatch = form && form.errors && form.errors.passwordsShouldMatch;
        return !!((control && control.invalid && (control.dirty || control.touched)) || passwordsDontMatch);
    }
}