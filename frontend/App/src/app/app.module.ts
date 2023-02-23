import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

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
  imports: [BrowserModule, AppRoutingModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
