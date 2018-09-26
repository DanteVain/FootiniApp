import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ConfigureComponent } from './configure/configure.component';
import { ViewboardsComponent } from './viewboards/viewboards.component';
import { AuthGuard } from './_guards/auth.guard';
import { AdministratorComponent } from './Administrator/Administrator.component';
import { MemberdetailsComponent } from './Administrator/memberdetails/memberdetails.component';
import { MemberDetailResolver } from './_resolvers/member-detail-resolver';
import { MemberListResolver } from './_resolvers/member-list-resolver.';

export const appRoutes: Routes = [
        {path: '', component: HomeComponent},

        {
                path: '',
                runGuardsAndResolvers: 'always',
                canActivate: [AuthGuard],
                children: [
                        {path: 'admin', component: AdministratorComponent, resolve {users: MemberListResolver}},
                        {path: 'admin/:id', component: MemberdetailsComponent, resolve: {user: MemberDetailResolver}},
                        {path: 'configure', component: ConfigureComponent},
                        {path: 'viewboards', component: ViewboardsComponent},
                ]
        },

        {path: '**', redirectTo: '', pathMatch: 'full'},
];


