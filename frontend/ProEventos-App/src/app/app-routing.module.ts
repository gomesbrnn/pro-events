import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventsComponent } from './components/events/events.component';
import { SpeakersComponent } from './components/speakers/speakers.component';

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
