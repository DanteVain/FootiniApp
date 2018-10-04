import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ConfigureComponent } from './configure/configure.component';
import { ViewboardsComponent } from './viewboards/viewboards.component';
import { AuthGuard } from './_guards/auth.guard';
import { AdministratorComponent } from './Administrator/Administrator.component';
import { MemberdetailsComponent } from './Administrator/memberdetails/memberdetails.component';
import { MemberDetailResolver } from './_resolvers/member-detail-resolver';
import { MemberListResolver } from './_resolvers/member-list-resolver.';
import { EditProfileComponent } from './edit-profile/edit-profile.component';
import { EditResolver } from './_resolvers/edit-resolver';
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-changes.guard';
import { ImagesComponent } from './images/images.component';
import { ImageListResolver } from './_resolvers/image-list-resolver';

export const appRoutes: Routes = [
        {path: '', component: HomeComponent},

        {
                path: '',
                runGuardsAndResolvers: 'always',
                canActivate: [AuthGuard],
                children: [
                        {path: 'admin', component: AdministratorComponent, resolve: {users: MemberListResolver}},
                        {path: 'admin/:id', component: MemberdetailsComponent, resolve: {user: MemberDetailResolver}},
                        {path: 'configure', component: ConfigureComponent},
                        {path: 'viewboards', component: ViewboardsComponent},
                        {path: 'edit', component: EditProfileComponent, resolve: {user: EditResolver},
                                canDeactivate: [PreventUnsavedChanges]},
                        {path: 'images', component: ImagesComponent, resolve: {images: ImageListResolver} },
                ]
        },

        {path: '**', redirectTo: '', pathMatch: 'full'},
];


