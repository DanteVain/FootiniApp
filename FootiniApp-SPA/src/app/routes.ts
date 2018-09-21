import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ConfigureComponent } from './configure/configure.component';
import { ViewboardsComponent } from './viewboards/viewboards.component';
import { AuthGuard } from './_guards/auth.guard';

export const appRoutes: Routes = [
        {path: '', component: HomeComponent},

        {
                path: '',
                runGuardsAndResolvers: 'always',
                canActivate: [AuthGuard],
                children: [
                        {path: 'configure', component: ConfigureComponent},
                        {path: 'viewboards', component: ViewboardsComponent},
                ]
        },

        {path: '**', redirectTo: '', pathMatch: 'full'},
];


