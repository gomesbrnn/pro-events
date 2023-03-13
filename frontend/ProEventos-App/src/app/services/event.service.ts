import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Event } from '../models/event';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  protected baseUrl: string = "https://localhost:5001/api/v1/events/"

  constructor(private http: HttpClient) { }

  getEvents(): Observable<Event[]> {
    return this.http.get<Event[]>(this.baseUrl)
  }

  getEventsByTheme(theme: string): Observable<Event[]> {
    return this.http.get<Event[]>(this.baseUrl + `theme/${theme}`)
  }

  getEventById(id: number): Observable<Event> {
    return this.http.get<Event>(this.baseUrl + `${id}`)
  }

  createEvent(event: Event): Observable<Event> {
    return this.http.post<Event>(this.baseUrl, event)
  }

  updateEvent(event: Event, eventId: number): Observable<Event> {
    return this.http.put<Event>(this.baseUrl + `${eventId}`, event)
  }

  deleteEvent(eventId: number): Observable<Event> {
    return this.http.delete<Event>(this.baseUrl + `${eventId}`)
  }
}
