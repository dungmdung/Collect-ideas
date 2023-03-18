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
import { ChangeComponent } from './compoment/staff/change/change.component';
import { DocumentComponent } from './compoment/staff/document/document.component';
import { PopularComponent } from './compoment/popular/popular.component';
import { ProfileComponent } from './compoment/staff/profile/profile.component';
import { RouterModule } from '@angular/router';
import { UserComponent } from './compoment/admin/user/user.component';
import { SystemComponent } from './compoment/admin/system/system.component';
import { SubmissionComponent } from './compoment/staff/submission/submission.component';
import { RecoveryComponent } from './compoment/staff/recovery/recovery.component';
import { AdminComponent } from './compoment/admin/admin/admin.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    LoginComponent,
    MainComponent,
    FooterComponent,
    ChangeComponent,
    DocumentComponent,
    PopularComponent,
    ProfileComponent,
    UserComponent,
    SystemComponent,
    SubmissionComponent,
    RecoveryComponent,
    AdminComponent,
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
        path: 'user',
        component: UserComponent,
      },
      {
        path: 'system',
        component: SystemComponent,
      },
      {
        path: 'submit',
        component: SubmissionComponent,
      },
      {
        path: 'recovery',
        component: RecoveryComponent,
      },
      {
        path: 'admin',
        component: AdminComponent,
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
