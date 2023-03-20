import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-title',
  templateUrl: './title.component.html',
  styleUrls: ['./title.component.scss']
})
export class TitleComponent implements OnInit {
  @Input() iconClass = '';
  @Input() title = '';
  @Input() subtitle?= '';
  @Input() listButton = false;

  constructor(private router: Router) { }

  public list(): void {
    this.router.navigate([`/${this.title.toLocaleLowerCase()}/list`])
  }

  ngOnInit(): void {
    ''
  }
}
