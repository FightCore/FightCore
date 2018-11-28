import { AuthBridgeService } from './../../services/auth-bridge.service';
import { environment } from 'src/environments/environment';
import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  @Input('isPopup') isPopupMode: boolean;
  @Output('done') done = new EventEmitter(); // For closing self in popup as necessary

  form: FormGroup;
  isSubmitting: boolean;
  onSubmitErrorMessage: string;

  bonusMessage: string; // For presenting an optional message under header
  
  constructor(private authService: AuthBridgeService, private router: Router, fb: FormBuilder) { 
    this.form = fb.group({
      usernameControl: ['', [Validators.required] ],
      passControl: ['', [Validators.required] ]
    });
  }

  ngOnInit() {
    if(environment.envName === 'noback') {
      this.bonusMessage = 'Demo Mode: Use usernames "TestUserA" and "TestUserB" to login, password does not matter';
    }
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
        this.isSubmitting = false;
        // TODO: Show some confirmation message and state should be navigating to another page

        if(this.isPopupMode) {
          this.done.emit(); // Make sure popup doesn't stay open
        }
        else {
          this.router.navigate(['/profile']);
        }
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

  goSignUp() {
    if(this.isPopupMode) {
      // TODO: Open sign up in current popup
      this.done.emit(); // Make sure popup doesn't stay open
      this.router.navigate(['/signup']);      
    }
    else {
      this.router.navigate(['/signup']);
    }
  }

  get usernameControl() { return this.form.get('usernameControl'); }
  get passControl() { return this.form.get('passControl'); }

}