import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from "ngx-spinner";
import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { EventService } from 'src/app/services/event.service';
import { Event } from 'src/app/models/event';
import { Router } from '@angular/router';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.scss']
})
export class EventListComponent implements OnInit {

  constructor(
    private eventService: EventService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.spinner.show();
    this.getEvents()
  }

  /* -------------- Calling Services -------------------- */

  public events: Event[] = [];

  public getEvents(): void {

    this.eventService.getEvents().subscribe(

      (eventsResponse: Event[]) => {
        this.events = eventsResponse;
        this.filteredEvents = eventsResponse;
      },

      (error: any) => {
        setTimeout(() => {
          this.spinner.hide();
          this.toastr.error('Error on load Events', 'Error');
        }, 500);
        console.error(error);
      },

      () => {
        setTimeout(() => { this.spinner.hide(); }, 500);
      }
    )
  }

  public deleteEvent(eventId: number) {

    this.spinner.show();

    this.eventService.deleteEvent(eventId).subscribe(

      () => {
        setTimeout(() => {
          this.spinner.hide();
          this.getEvents();
          this.toastr.success('Event deleted Successfully');
        }, 500);
      },

      (error: any) => {
        setTimeout(() => {
          this.spinner.hide();
          this.toastr.error('Error on delete this event', 'Error');
        }, 500);
        console.error(error);
      }
    )
  }

  /* -------------- Dynamic Filter -------------------- */

  public filteredEvents: Event[] = [];

  private _listFilter = '';

  public get listFilter() {
    return this._listFilter;
  }

  public set listFilter(value: string) {
    this._listFilter = value;

    this.filteredEvents = this.listFilter
      ? this.filterEvents(this.listFilter)
      : this.events;
  }

  public filterEvents(filterBy: string): Event[] {
    filterBy = filterBy.toLocaleLowerCase();

    return this.events.filter(
      event => event.theme.toLocaleLowerCase().indexOf(filterBy) !== - 1 ||
        event.city.toLocaleLowerCase().indexOf(filterBy) !== - 1
    )
  }

  /* ------------------- Modal ----------------------- */

  public modalRef?: BsModalRef;
  public eventId = 0;

  public openModal(event: any, template: TemplateRef<void>, eventId: number): void {
    event.stopPropagation();
    this.eventId = eventId;
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  public confirm(): void {
    this.modalRef?.hide();
    this.deleteEvent(this.eventId);
  }

  public decline(): void {
    this.modalRef?.hide();
  }

  /* ------------------- Others ----------------------- */

  public displayImage = true;

  public changeImageStatus(): void {
    this.displayImage = !this.displayImage;
  }

  public eventDetail(id: number) {
    this.router.navigate([`events/detail/${id}`]);
  }
}
