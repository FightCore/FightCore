import { AppError } from './../../errors/app-error';
import { UserSubmission } from './../../models/UserSubmission';
import { OAuthService } from 'angular-oauth2-oidc';
import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { PasswordValidators } from 'src/app/shared/password.validators';
import { PasswordErrorStateMatcher } from 'src/app/shared/password.errorstatematcher';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
  form: FormGroup;
  confirmErrorMatcher = new PasswordErrorStateMatcher();
  isSubmitting: boolean;
  onSubmitErrorMessages: string[];

  readonly passMinLength = 6; // So only need to change in one place

  constructor(private titleService: Title,
    fb: FormBuilder,
    private authService: OAuthService, 
    private router: Router,
    private userService: UserService) {
    this.form = fb.group({
      usernameControl: ['', [Validators.required] ],
      emailControl: ['', [Validators.required, Validators.email] ],
      passControl: ['', [Validators.required, Validators.minLength(this.passMinLength), PasswordValidators.hasUppercase, PasswordValidators.hasDigit, PasswordValidators.hasNonAlphanumeric] ],
      confirmPassControl: ['', [Validators.required] ]
    }, {
      validator: PasswordValidators.passwordsShouldMatch
    });
  }

  ngOnInit() {
    // Redirect if already logged in
    if (this.authService.hasValidAccessToken()) {
      this.router.navigate(['/profile']);
    }

    this.titleService.setTitle("Sign Up");
  }

  onSubmit() {
    // Safety check, form should always be valid at this point
    if(this.form.invalid) return;

    // Show that the form is now loading
    this.isSubmitting = true;
    this.form.disable();
    this.onSubmitErrorMessages = []; // Clear for new submit

    // Submit the user's info
    let newUser: UserSubmission = {
      userName: this.form.get('usernameControl').value,
      email: this.form.get('emailControl').value,
      password: this.form.get('passControl').value
    }

    this.userService.createUser(newUser)
      .subscribe(
        response => this.afterSubmit(true, response),
        error => this.afterSubmit(false, error)
      );
  }

  afterSubmit(success: boolean, message: any) {
    if(success) {
      // TODO: Get the token in a single request/response
      this.router.navigate(['/login']);
    }
    else {
      // Show that the form is now done loading
      this.isSubmitting = false;
      this.form.enable();

      // Show specific error messages if possible
      if(message instanceof AppError && message.originalError) {
        // Display each error message's description
        message.originalError.error.forEach(element => {
          this.onSubmitErrorMessages.push(element.description);
        });
      }
      // Otherwise, this is an unexpected error
      else {
        this.onSubmitErrorMessages.push("Sorry, the submit failed for some unexpected reason");
        
        console.log("Sign up error: ", message); // TODO: Log message in some better/more accessible way
      }
    }
  }

  get usernameControl() { return this.form.get('usernameControl'); }
  get emailControl() { return this.form.get('emailControl'); }
  get passControl() { return this.form.get('passControl'); }
  get confirmPassControl() { return this.form.get('confirmPassControl'); }

}