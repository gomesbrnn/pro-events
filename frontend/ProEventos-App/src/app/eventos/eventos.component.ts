import { Component, OnInit } from '@angular/core';
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
  exibirImagem: boolean = true;
  filtroEventos: string = '';

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

  alterarImagem() {
    this.exibirImagem = !this.exibirImagem;
  }
}
