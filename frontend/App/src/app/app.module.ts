import { AuthInterceptor } from './auth.interceptor';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
// import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './compoment/navbar/navbar.component';
import { LoginComponent } from './compoment/login/login.component';
import { MainComponent } from './compoment/main/main.component';
import { FooterComponent } from './compoment/footer/footer.component';
import { RegisterComponent } from './compoment/register/register.component';
import { PasswordComponent } from './compoment/password/password.component';
import { ChangeComponent } from './compoment/change/change.component';
import { DocumentComponent } from './compoment/document/document.component';
import { PopularComponent } from './compoment/popular/popular.component';
import { ProfileComponent } from './compoment/profile/profile.component';
import { SubmitComponent } from './compoment/submit/submit.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    LoginComponent,
    MainComponent,
    FooterComponent,
    RegisterComponent,
    PasswordComponent,
    ChangeComponent,
    DocumentComponent,
    PopularComponent,
    ProfileComponent,
    SubmitComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    // NgbModule,
    HttpClientModule,
    RouterModule.forRoot([
      {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full',
      },
      {
        path: 'home',
        component: MainComponent,
      },
      {
        path: 'login',
        component: LoginComponent,
      },
      {
        path: 'register',
        component: RegisterComponent,
      },
      {
        path: 'pass',
        component: PasswordComponent,
      },
      {
        path: 'change',
        component: ChangeComponent,
      },
      {
        path: 'document',
        component: DocumentComponent,
      },
      {
        path: 'popular',
        component: PopularComponent,
      },
      {
        path: 'profile',
        component: ProfileComponent,
      },
      {
        path: 'submit',
        component: SubmitComponent,
      },
    ]),
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
