import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-event-detail',
  templateUrl: './event-detail.component.html',
  styleUrls: ['./event-detail.component.scss']
})
export class EventDetailComponent {
  constructor(private formBuilder: FormBuilder) { }

  eventDetailsForm = this.formBuilder.group({
    city: ['', Validators.required],
    date: ['', Validators.required],
    theme: ['', Validators.required],
    amountPeople: [0, Validators.required],
    imageURL: ['', Validators.required],
    phone: ['', Validators.required],
    email: ['', Validators.required]
  });
}
