import { Component } from '@angular/core';

@Component({
  selector: 'app-eventa',
  templateUrl: './eventa.component.html',
  styleUrls: ['./eventa.component.scss']
})
export class EventaComponent {
  showc: boolean = false;
  constructor() {}

  ngOnInit() {}
  cr() {
    this.showc = !this.showc;
    console.log(this.showc);
  }
  clo() {
    this.showc = false;
  }
}
