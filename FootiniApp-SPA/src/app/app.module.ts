import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule} from '@angular/forms';

import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { AlertifyService } from './_services/alertify.service';
import { BsDropdownModule } from 'ngx-bootstrap';
import { ViewboardsComponent } from './viewboards/viewboards.component';
import { ConfigureComponent } from './configure/configure.component';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { AuthGuard } from './_guards/auth.guard';
import { AdministratorComponent } from './Administrator/Administrator.component';
import { UserService } from './_services/user.service';
import { MemberListComponent } from './Administrator/member-list/member-list.component';
import { MemberCardComponent } from './Administrator/member-list/member-card/member-card.component';
import { JwtModule } from '@auth0/angular-jwt';
import { MemberdetailsComponent } from './Administrator/memberdetails/memberdetails.component';
import { MemberDetailResolver } from './_resolvers/member-detail-resolver';
import { MemberListResolver } from './_resolvers/member-list-resolver.';
import { EditProfileComponent } from './edit-profile/edit-profile.component';
import { EditResolver } from './_resolvers/edit-resolver';
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-changes.guard';
import { ImagesComponent } from './images/images.component';
import { ImageService } from './_services/Image.service';
import { ImageListResolver } from './_resolvers/image-list-resolver';
import { ImageCardComponent } from './images/Image-Card/Image-Card.component';

export function tokenGetter() {
    return localStorage.getItem('token');
}

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      ViewboardsComponent,
      ConfigureComponent,
      AdministratorComponent,
      MemberListComponent,
      MemberCardComponent,
      MemberdetailsComponent,
      EditProfileComponent,
      ImagesComponent,
      ImageCardComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      RouterModule.forRoot(appRoutes),
      JwtModule.forRoot({
          config: {
              tokenGetter: tokenGetter,
              whitelistedDomains: ['localhost:5000'],
              blacklistedRoutes: ['localhost:5000/api/auth'],
          }
      })

   ],
   providers: [
      AuthService,
      ErrorInterceptorProvider,
      AlertifyService,
      AuthGuard,
      PreventUnsavedChanges,
      UserService,
      ImageService,
      MemberDetailResolver,
      MemberListResolver,
      EditResolver,
      ImageListResolver
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
