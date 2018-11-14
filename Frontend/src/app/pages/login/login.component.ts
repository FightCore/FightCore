import { FakeAuthService } from 'src/app/resources/mockups/fake-auth.service';
import { environment } from 'src/environments/environment';
import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { OAuthService } from 'angular-oauth2-oidc';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

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
    let isLoggedIn: boolean = environment.envName === 'noback' ? 
      FakeAuthService.hasValidAccessToken() : 
      this.authService.hasValidAccessToken();
    if (isLoggedIn) {
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

    let authPromise: Promise<object> = environment.envName === 'noback' ? 
      FakeAuthService.fetchTokenUsingPasswordFlowAndLoadUserProfile(this.usernameControl.value, this.passControl.value) : 
      this.authService.fetchTokenUsingPasswordFlowAndLoadUserProfile(this.usernameControl.value, this.passControl.value);

    authPromise
      .then((tokenResponse => {
        this.isSubmitting = false;
        // TODO: Show some confirmation message and state should be navigating to another page

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
