import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactsComponent } from './components/contacts/contacts.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { EventsComponent } from './components/events/events.component';
import { ProfileComponent } from './components/profile/profile.component';
import { SpeakersComponent } from './components/speakers/speakers.component';

const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full', data: { title: 'Home' } },
  { path: 'events', component: EventsComponent, data: { title: 'Events' } },
  { path: 'speakers', component: SpeakersComponent, data: { title: 'Speakers' } },
  { path: 'contacts', component: ContactsComponent, data: { title: 'Contacts' } },
  { path: 'profile', component: ProfileComponent, data: { title: 'Profile' } },
  { path: 'dashboard', component: DashboardComponent, data: { title: 'Dashboard' } },
  { path: '**', redirectTo: 'dashboard', pathMatch: 'full', data: { title: 'Home' } }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
