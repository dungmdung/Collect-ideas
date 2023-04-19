import { Component, OnInit } from '@angular/core';
import { AppService } from 'src/app/services/app.service';
import { UserService } from 'src/app/services/user.service';

interface User {
  id: number;
  userName: string;
  fullName: string;
  doB: string;
  email: string;
  phoneNumber: number;
  role: string;
  department: string;
}

@Component({
  selector: 'app-navbars',
  templateUrl: './navbars.component.html',
  styleUrls: ['./navbars.component.scss']
})
export class NavbarsComponent implements OnInit{
  showp: boolean = false;
  showc: boolean = false;
  showe: boolean = false;
  showl: boolean = false;
  constructor(public appService: AppService, private userService: UserService) {}
  ngOnInit() {}
  po() {
    this.showp = !this.showp;
    console.log(this.showp);
  }
  ch() {
    this.showc = !this.showc;
    console.log(this.showc);
  }
  ed() {
    this.showe = !this.showe;
    console.log(this.showe);
  }
  lo() {
    this.showl = !this.showl;
    console.log(this.showl);
  }
  cl() {
    this.showp = false;
    this.showc = false;
    this.showe = false;
    this.showl = false;
  }
}
