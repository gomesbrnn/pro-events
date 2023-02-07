import { Component, OnInit } from '@angular/core';
import { Console } from 'console';
import { Evento } from '../models/evento';
import { EventoService } from '../services/evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  constructor(private eventoService: EventoService) { }

  public eventos: Evento[] = [];

  public getEventos() {
    this.eventoService.getEventos().subscribe(
      eventos => {
        this.eventos = eventos;
        console.log(eventos);
      },
      error => {
        console.log(error);
      }
    )
  }

  ngOnInit(): void {
    this.getEventos()
  }
}
