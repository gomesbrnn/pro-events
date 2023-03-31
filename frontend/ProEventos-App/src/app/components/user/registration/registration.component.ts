import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent {
  constructor(private formbuilder: FormBuilder) { }

  get form() {
    return this.registrationForm.controls;
  }

  registrationForm = this.formbuilder.group({

    firstName: ['', [
      Validators.required
    ]],
    lastName: ['', [
      Validators.required
    ]],
    email: ['', [
      Validators.required,
      Validators.email
    ]],
    username: ['', [
      Validators.required,
      Validators.minLength(4)
    ]],
    password: ['', [
      Validators.required,
      Validators.min(8)
    ]],
    confirmPassword: ['', [
      Validators.required,
      Validators.min(8)
    ]],

  })
}
