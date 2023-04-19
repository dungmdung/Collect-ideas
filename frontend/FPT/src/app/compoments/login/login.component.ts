import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppService } from 'src/app/services/app.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  user = {
    username: '',
    password: '',
  };
  isInvalid: boolean = false;
  constructor(private appService: AppService, private router: Router) {}

  ngOnInit(): void {}

  login() {
    this.appService.login(this.user).subscribe(
      (res: any) => {
        if (res.role=="Admin"){
        this.router.navigate(['/maina']);
        localStorage.setItem('token', res['token']);
      }
    if
    (res.role=="Staff"){
      this.router.navigate(['/mains']);
      localStorage.setItem('token', res['token']);
    }
    if
    (res.role=="QACoordinator"){
      this.router.navigate(['/mainc']);
      localStorage.setItem('token', res['token']);
    }
    if
    (res.role=="QAManager"){
      this.router.navigate(['/mainm']);
      localStorage.setItem('token', res['token']);
    }
  },
      (err) => {
        this.isInvalid = true;
      }
    );
  }
}
