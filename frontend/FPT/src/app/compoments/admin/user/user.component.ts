import { Component } from '@angular/core';
import { UserService } from 'src/app/services/user.service';

interface infor{
  id: number,
        userName: string,
        fullName: string,
        doB: string,
        email: string,
        phoneNumber: number,
        role: string,
        department: string
}

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss'],
})
export class UserComponent {
  showc: boolean = false;
  showf: boolean = false;
  showd: boolean = false;
  id: number = 0;
  user: infor = {
    id: 0,
        userName: '',
        fullName: '',
        doB: '',
        email: '',
        phoneNumber: 0,
        role: '',
        department: ''
  }
  allUser: infor[] = []
  constructor(private UserSer:UserService) {

  }

  ngOnInit() {
    this.UserSer.getAllUser().subscribe((repon)=>{
      this.allUser = repon
    })
  }

  cr() {
    this.showc = !this.showc;
    console.log(this.showc);
  }
  clo() {
    this.showc = false;
    this.showd = false;
  }
  cl(){
    this.showf = false;

  }
  ic(id:number) {
    this.showf = !this.showf;
    if (this.showf){
      this.UserSer.getUser(id).subscribe((repon)=>{
        this.user = repon.data
      })
    }
  }
  tr(id:number) {
    this.showd = !this.showd;
    this.id = id;
  }
  dl(){
    if(this.id){
      this.UserSer.deleteUser(this.id).subscribe((repon)=>{
        console.log(repon);
      })
    }
  }
}
