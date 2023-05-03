import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router'; import { Router } from '@angular/router';
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
    private actRoute: ActivatedRoute,
    private router: Router,
    private eventService: EventService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
  ) { }

  ngOnInit(): void {
    this.spinner.show();
    this.getEventById();
    if (this.saveMode == 'post') setTimeout(() => { this.spinner.hide(); }, 400);
  }

  /* -------------- Reactive Form -------------------- */

  get form() {
    return this.eventDetailsForm.controls;
  }

  public inputValidator(formField: FormControl): any {
    return { 'is-invalid': formField.errors && formField.touched }
  }

  public resetForm(): void {
    this.eventDetailsForm.reset();
  }

  public saveChanges() {
    this.saveMode == 'post'
      ? this.createEvent()
      : this.updateEvent();
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
      Validators.maxLength(15)
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
  public saveMode = 'post';

  public getEventById() {
    const eventId = this.actRoute.snapshot.paramMap.get('id');

    if (eventId != null) {
      this.saveMode = 'put'
      this.eventService.getEventById(+eventId).subscribe(

        (eventResponse: Event) => {
          this.event = { ...eventResponse };
          this.eventDetailsForm.patchValue(this.event);
        },

        (error: any) => {
          this.toastr.error('Error on load Event', 'Error');
          console.error(error);
        }
      ).add(() => setTimeout(() => { this.spinner.hide() }, 400))
    }
  }

  public createEvent() {
    this.spinner.show();

    if (this.eventDetailsForm.valid) {
      this.event = { ... this.eventDetailsForm.value } as Event
      this.eventService.createEvent(this.event).subscribe(

        () => {
          this.toastr.success('Event creeated', 'Success');
          this.router.navigate(['/events/list'])
        },

        (error) => {
          this.toastr.error('Error on create Event', 'Error');
          console.error(error);
        }
      ).add(() => setTimeout(() => { this.spinner.hide() }, 400))
    }
  }

  public updateEvent() {
    this.spinner.show();

    if (this.eventDetailsForm.valid) {
      this.event = { id: this.event.id, ... this.eventDetailsForm.value } as Event
      this.eventService.updateEvent(this.event, this.event.id).subscribe(

        () => {
          this.toastr.success('Event updated', 'Success');
          this.router.navigate(['/events/list'])
        },

        (error) => {
          this.toastr.error('Error on create Event', 'Error');
          console.error(error);
        }
      ).add(() => setTimeout(() => { this.spinner.hide() }, 400))
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
