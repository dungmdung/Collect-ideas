import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './compoments/admin/user/user.component';
import { NavbarComponent } from './compoments/admin/navbar/navbar.component';
import { RouterModule } from '@angular/router';
import { MainComponent } from './compoments/main/main.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { EventsComponent } from './compoments/admin/events/events.component';
import { AccountComponent } from './compoments/admin/account/account.component';
import { EventComponent } from './compoments/admin/event/event.component';
import { ProfileComponent } from './compoments/admin/profile/profile.component';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    NavbarComponent,
    MainComponent,
    EventsComponent,
    AccountComponent,
    EventComponent,
    ProfileComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot([
      {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full',
      },
      {
        path: 'user',
        component: UserComponent,
      },
      {
        path: 'events',
        component: EventsComponent,
      },
      {
        path: 'profile',
        component: ProfileComponent,
      },
      {
        path: 'account',
        component: AccountComponent,
      },
    ]),
    NgbModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
