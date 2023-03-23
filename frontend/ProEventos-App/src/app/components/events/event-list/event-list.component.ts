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
export class EventListComponent {
  constructor(
    private eventService: EventService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private router: Router
  ) { }

  modalRef?: BsModalRef;
  public events: Event[] = [];
  public filteredEvents: Event[] = [];
  private _listFilter = '';
  public displayImage = true;

  public changeImageStatus(): void {
    this.displayImage = !this.displayImage;
  }

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

  public getEvents(): void {
    this.eventService.getEvents().subscribe(
      response => {
        this.events = response;
        this.filteredEvents = response;
        setTimeout(() => { this.spinner.hide(); }, 1000);
      },
      error => {
        this.spinner.hide();
        this.toastr.error('Error on load Events', 'Error');
        console.log(error);
      }
    )
  }

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

  public eventDetail(id: number) {
    this.router.navigate([`events/detail/${id}`]);
  }

  ngOnInit(): void {
    this.spinner.show();
    this.getEvents()
  }
}
