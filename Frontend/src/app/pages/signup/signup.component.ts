import { UserSubmission } from './../../models/UserSubmission';
import { OAuthService } from 'angular-oauth2-oidc';
import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { PasswordValidators } from 'src/app/shared/password.validators';
import { PasswordErrorStateMatcher } from 'src/app/shared/password.errorstatematcher';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
  form: FormGroup;
  confirmErrorMatcher = new PasswordErrorStateMatcher();
  isSubmitting: boolean;
  onSubmitErrorMessage: string;

  constructor(private titleService: Title,
    fb: FormBuilder,
    private authService: OAuthService, 
    private router: Router,
    private userService: UserService) {
    this.form = fb.group({
      usernameControl: ['', [Validators.required] ],
      emailControl: ['', [Validators.required, Validators.email] ],
      passControl: ['', [Validators.required] ],
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

    if(environment.envName === 'noback') {
      this.titleService.setTitle('Sign Up (Not Functional in No Backend Mode)');
    }
    else {
      this.titleService.setTitle('Sign Up');
    }
  }

  onSubmit() {
    // Safety check, form should always be valid at this point
    if(this.form.invalid) return;

    // Show that the form is now loading
    this.isSubmitting = true;
    this.form.disable();
    this.onSubmitErrorMessage = ""; // Clear for new submit

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
      console.log("Successfully signed up", message)
      // TODO: Get the token in a single request/response
      this.router.navigate(['/login']);
    }
    else {
      // Show that the form is now done loading
      this.isSubmitting = false;
      this.form.enable();

      // TODO: Show some better error message
      console.log("Error: ", message);
      this.onSubmitErrorMessage = "Sorry, the submit failed for some reason!"
    }
  }

  get usernameControl() { return this.form.get('usernameControl'); }
  get emailControl() { return this.form.get('emailControl'); }
  get passControl() { return this.form.get('passControl'); }
  get confirmPassControl() { return this.form.get('confirmPassControl'); }

}