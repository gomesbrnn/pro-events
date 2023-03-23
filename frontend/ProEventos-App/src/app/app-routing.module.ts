import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactsComponent } from './components/contacts/contacts.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { EventDetailComponent } from './components/events/event-detail/event-detail.component';
import { EventListComponent } from './components/events/event-list/event-list.component';
import { EventsComponent } from './components/events/events.component';
import { ProfileComponent } from './components/profile/profile.component';
import { SpeakersComponent } from './components/speakers/speakers.component';
import { LoginComponent } from './components/user/login/login.component';
import { UserComponent } from './components/user/user.component';

const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full', data: { title: 'Home' } },
  { path: 'dashboard', component: DashboardComponent, data: { title: 'Dashboard' } },
  { path: 'events', redirectTo: 'events/list' },
  {
    path: 'events', component: EventsComponent, data: { title: 'Events' },
    children: [
      { path: 'list', component: EventListComponent },
      { path: 'detail', component: EventDetailComponent },
      { path: 'detail/:id', component: EventDetailComponent }
    ]
  },
  {
    path: 'user', component: UserComponent,
    children: [
      { path: 'login', component: LoginComponent }
    ]
  },
  { path: 'speakers', component: SpeakersComponent, data: { title: 'Speakers' } },
  { path: 'contacts', component: ContactsComponent, data: { title: 'Contacts' } },
  { path: 'profile', component: ProfileComponent, data: { title: 'Profile' } },
  { path: '**', redirectTo: 'dashboard', pathMatch: 'full', data: { title: 'Home' } }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
