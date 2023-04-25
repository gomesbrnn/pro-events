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

  /* -------------- Calling Services -------------------- */

  public events: Event[] = [];

  public getEvents(): void {

    this.eventService.getEvents().subscribe(

      (eventsResponse: Event[]) => {
        this.events = eventsResponse;
        this.filteredEvents = eventsResponse;
        setTimeout(() => { this.spinner.hide(); }, 500);
      },

      (error: any) => {
        this.spinner.hide();
        this.toastr.error('Error on load Events', 'Error');
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

  modalRef?: BsModalRef;

  public openModal(template: TemplateRef<void>): void {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  public confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('Deleted Successfully!');
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

  ngOnInit(): void {
    this.spinner.show();
    this.getEvents()
  }
}
