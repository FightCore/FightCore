import { AbstractControl } from '@angular/forms';

export class PasswordValidators {
    /**
     * Validator checking if password fields match
     * @param control Must contain controls "passControl" and "confirmPassControl"
     * @returns Object with property passwordsShouldMatch: true if passwords match, or null otherwise
     */
    static passwordsShouldMatch(control: AbstractControl) {
        let newPassword = control.get('passControl');
        let confirmPassword = control.get('confirmPassControl');

        if (newPassword.value !== confirmPassword.value) {
            return { passwordsShouldMatch: true };
        }
        return null;
    }
}