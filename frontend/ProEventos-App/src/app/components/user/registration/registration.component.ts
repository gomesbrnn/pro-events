import { Component } from '@angular/core';
import { AbstractControlOptions, FormBuilder, Validators } from '@angular/forms';
import { FieldValidator } from 'src/app/helpers/field-validator';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent {
  constructor(private formbuilder: FormBuilder) { }

  formOptions: AbstractControlOptions = {
    validators: FieldValidator.mustMatch('password', 'confirmPassword')
  }

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
      Validators.minLength(8)
    ]],
    confirmPassword: ['', [
      Validators.required,
      Validators.minLength(8)
    ]]
  }, this.formOptions)
}
