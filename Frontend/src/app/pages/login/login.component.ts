import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { OAuthService } from 'angular-oauth2-oidc';
import { Router } from '@angular/router';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  form: FormGroup;
  isSubmitting: boolean;
  onSubmitErrorMessage: string;

  constructor(private titleService: Title, private authService: OAuthService, private router: Router, fb: FormBuilder) { 
    this.form = fb.group({
      usernameControl: ['', [Validators.required] ],
      passControl: ['', [Validators.required] ]
    });
  }

  ngOnInit() {
    if (this.authService.hasValidAccessToken()) {
      this.router.navigate(['/home']);
    }
    this.titleService.setTitle("Login");
  }

  login() {
    // Safety check, form should always be valid at this point
    if(this.form.invalid) return;

    // Show that the form is now loading
    this.isSubmitting = true;
    this.form.disable();
    this.onSubmitErrorMessage = ""; // Clear for new submit

    this.authService.fetchTokenUsingPasswordFlowAndLoadUserProfile(this.usernameControl.value, this.passControl.value)
      .then((tokenResponse => {
        this.router.navigate(['/profile']);
      }))
      .catch(error => {
        // Show that the form is now done loading
        this.isSubmitting = false;
        this.form.enable();

        // TODO: Show some better error message
        console.log("Error: ", error);
        this.onSubmitErrorMessage = "Sorry, the submit failed for some reason!"
      });
  }

  get usernameControl() { return this.form.get('usernameControl'); }
  get passControl() { return this.form.get('passControl'); }

}
