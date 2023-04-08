import { Component } from '@angular/core';

@Component({
  selector: 'app-ideas',
  templateUrl: './ideas.component.html',
  styleUrls: ['./ideas.component.scss']
})
export class IdeasComponent {
  showc: boolean = false;
  showp: boolean = false;
  constructor() {}

  ngOnInit() {}
  cr() {
    this.showc = !this.showc;
    console.log(this.showc);
  }
  po() {
    this.showp = !this.showp;
    console.log(this.showp);
  }
  clo() {
    this.showc = false;
    this.showp = false;
  }
}
