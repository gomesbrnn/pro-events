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

  public exibirImagem: boolean = true;
  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];
  private _filtroLista: string = '';

  alterarImagem() {
    this.exibirImagem = !this.exibirImagem;
  }

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;

    this.eventosFiltrados = this.filtroLista
      ? this.filtrarEventos(this.filtroLista)
      : this.eventos;
  }

  public filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();

    return this.eventos.filter(
      evento => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== - 1 ||
        evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== - 1
    )
  }

  public getEventos() {
    this.eventoService.getEventos().subscribe(
      eventos => {
        this.eventos = eventos;
        this.eventosFiltrados = eventos;
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
