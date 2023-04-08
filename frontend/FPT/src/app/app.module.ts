import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './compoments/admin/user/user.component';
import { NavbarComponent } from './compoments/admin/navbar/navbar.component';
import { RouterModule } from '@angular/router';
import { MainComponent } from './compoments/main/main.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CategoryComponent } from './compoments/staff/category/category.component';
import { NavbarSComponent } from './compoments/staff/navbar-s/navbar-s.component';
import { IdeasComponent } from './compoments/staff/ideas/ideas.component';
import { EventaComponent } from './compoments/admin/eventa/eventa.component';
import { EventsComponent } from './compoments/staff/events/events.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    NavbarComponent,
    MainComponent,
    CategoryComponent,
    NavbarSComponent,
    IdeasComponent,
    EventaComponent,
    EventsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full',
      },
      {
        path: 'category',
        component: CategoryComponent,
      },
      {
        path: 'ideas',
        component: IdeasComponent,
      },
      {
        path: 'user',
        component: UserComponent,
      },
      {
        path: 'eventa',
        component: EventaComponent,
      },
      {
        path: 'events',
        component: EventsComponent,
      },
    ]),
    NgbModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
