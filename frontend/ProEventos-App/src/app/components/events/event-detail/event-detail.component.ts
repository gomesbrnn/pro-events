import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Event } from 'src/app/models/event';
import { EventService } from 'src/app/services/event.service';

@Component({
  selector: 'app-event-detail',
  templateUrl: './event-detail.component.html',
  styleUrls: ['./event-detail.component.scss']
})
export class EventDetailComponent implements OnInit {

  constructor(
    private formBuilder: FormBuilder,
    private router: ActivatedRoute,
    private eventService: EventService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
  ) { }

  ngOnInit(): void {
    this.spinner.show();
    this.getEventById();
  }

  /* -------------- Reactive Form -------------------- */

  get form() {
    return this.eventDetailsForm.controls;
  }

  public resetForm(): void {
    this.eventDetailsForm.reset();
  }

  inputValidator(formField: FormControl): any {
    return { 'is-invalid': formField.errors && formField.touched }
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


  /* -------------- Calling Services -------------------- */

  public event = {} as Event;

  public getEventById() {

    const eventId = this.router.snapshot.paramMap.get('id');

    if (eventId != null) {

      this.eventService.getEventById(+eventId).subscribe(

        (eventResponse: Event) => {
          this.event = { ...eventResponse };
          this.eventDetailsForm.patchValue(this.event);
        },

        (error: any) => {
          setTimeout(() => {
            this.spinner.hide();
            this.toastr.error('Error on load Event', 'Error');
          }, 500);
          console.error(error);
        },

        () => {
          setTimeout(() => { this.spinner.hide(); }, 500);
        }
      )
    }
  }

  /* ------------------- Others ----------------------- */

  get bsConfig() {
    return {
      isAnimated: true,
      adaptivePosition: true,
      dateInputFormat: 'DD/MM/YYYY hh:mm a',
      containerClass: 'theme-default',
      showWeekNumbers: false
    }
  }


}
