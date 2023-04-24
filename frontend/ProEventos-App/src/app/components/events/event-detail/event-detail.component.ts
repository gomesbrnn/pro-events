import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-event-detail',
  templateUrl: './event-detail.component.html',
  styleUrls: ['./event-detail.component.scss']
})
export class EventDetailComponent implements OnInit {
  constructor(private formBuilder: FormBuilder) { }

  get form() {
    return this.eventDetailsForm.controls;
  }

  public resetForm(): void {
    this.eventDetailsForm.reset();
  }

  eventDetailsForm = this.formBuilder.group({

    theme: ['', [
      Validators.required,
      Validators.minLength(4),
      Validators.maxLength(50)
    ]],
    city: ['', [
      Validators.required
    ]],
    date: ['', [
      Validators.required,
    ]],
    amountPeople: [0, [
      Validators.required,
      Validators.min(1),
      Validators.max(500)
    ]],
    phone: ['', [
      Validators.required,
      Validators.minLength(11),
      Validators.maxLength(12)
    ]],
    email: ['', [
      Validators.required,
      Validators.email
    ]],
    imageURL: ['', [
      Validators.required
    ]]

  });

  inputValidator(formField: FormControl): any {
    return { 'is-invalid': formField.errors && formField.touched }
  }

  ngOnInit(): void {
    this.eventDetailsForm
  }
}
