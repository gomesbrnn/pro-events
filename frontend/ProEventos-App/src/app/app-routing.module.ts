import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventsComponent } from './@events/events.component';
import { SpeakersComponent } from './speakers/speakers.component';

const routes: Routes = [
  { path: '', redirectTo: '/events', pathMatch: 'full', data: { title: 'Home' } },
  { path: 'events', component: EventsComponent, data: { title: 'Events' } },
  { path: 'speakers', component: SpeakersComponent, data: { title: 'Speakers' } }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
