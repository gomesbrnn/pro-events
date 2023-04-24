import { Component } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormControl, Validators } from '@angular/forms';
import { FieldValidator } from 'src/app/helpers/field-validator';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent {
  constructor(private formBuilder: FormBuilder) { }

  formOptions: AbstractControlOptions = {
    validators: FieldValidator.mustMatch('password', 'confirmPassword')
  }

  get form() {
    return this.profileForm.controls;
  }

  profileForm = this.formBuilder.group({
    name: ['', [
      Validators.required
    ]],
    lastName: ['', [
      Validators.required
    ]],
    email: ['', [
      Validators.required,
      Validators.email
    ]],
    phone: ['', [
      Validators.required,
      Validators.maxLength(15)
    ]],
    personalResume: ['', [
      Validators.required
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

  inputValidator(formField: FormControl): any {
    return { 'is-invalid': formField.errors && formField.touched }
  }
}
