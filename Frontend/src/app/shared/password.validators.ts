import { AbstractControl } from '@angular/forms';

export class PasswordValidators {
    /**
     * Validator checking if password fields match
     * @param control Must contain controls "passControl" and "confirmPassControl" (eg, should be used on entire form)
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

    /**
     * Validator checking if control value has at least one number
     * @param control Contains the value that should be checked
     * @returns Object with property hasNoDigit: true if control doesn't have a single number
     */
    static hasDigit(control: AbstractControl) {
        let containsDigit = /\d/.test(control.value);
        if (!containsDigit) {
            return { hasNoDigit: true };
        }
        return null;
    }

    /**
     * Validator checking if control value has at least uppercase letter
     * @param control Contains the value that should be checked
     * @returns Object with property hasNoUppercase: true if control doesn't have an uppercase letter
     */
    static hasUppercase(control: AbstractControl) {
        let containsUpperLetter = /[A-Z]/.test(control.value);
        if (!containsUpperLetter) {
            return { hasNoUppercase: true };
        }
        return null;
    }

    /**
     * Validator checking if control value has at least uppercase letter
     * @param control Contains the value that should be checked
     * @returns Object with property hasNoNonAlphanumeric: true if control doesn't have an uppercase letter
     */
    static hasNonAlphanumeric(control: AbstractControl) {
        let containsNonAlphaNumeric = /[^a-zA-Z0-9]/.test(control.value);
        if (!containsNonAlphaNumeric) {
            return { hasNoNonAlphanumeric: true };
        }
        return null;
    }
}