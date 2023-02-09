import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventosComponent } from './eventos/eventos.component';

const routes: Routes = [
  { path: '', redirectTo: '/eventos', pathMatch: 'full', data: { title: 'Home' } },
  { path: 'eventos', component: EventosComponent, data: { title: 'Eventos' } }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
