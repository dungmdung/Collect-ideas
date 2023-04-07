import { Component } from '@angular/core';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent {
  show: boolean = false;
  constructor() {

 }

 ngOnInit() {

 }
 pop(){
  this.show = !this.show;
  console.log(this.show)
 }
 clo(){
  this.show = false;
 }
}
