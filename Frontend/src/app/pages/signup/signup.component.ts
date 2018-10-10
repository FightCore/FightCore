import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { FormControl, Validators, FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
  form: FormGroup;

  constructor(private titleService: Title,
    fb: FormBuilder) {
    this.form = fb.group({
      usernameControl: ['', [Validators.required] ],
      emailControl: ['', [Validators.required, Validators.email] ],
      passControl: ['', [Validators.required] ],
      confirmPassControl: ['', [Validators.required] ]
    });
  }

  ngOnInit() {
    this.titleService.setTitle("Sign Up");
  }

  get usernameControl() { return this.form.get('usernameControl'); }
  get emailControl() { return this.form.get('emailControl'); }
  get passControl() { return this.form.get('passControl'); }
  get confirmPassControl() { return this.form.get('confirmPassControl'); }

}