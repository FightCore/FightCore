import { Routes } from '@angular/router';

import { HomeComponent } from '../home/home.component';
import { LoginComponent } from '../login/login.component';
import { AuthGuard } from '../services/auth-guard.service';
import { ProfileComponent } from '../profile/profile.component';

export const LayoutRoutes: Routes = [
    { 
        path: 'home',
        component: HomeComponent
    },
    {
        path: 'login',
        component: LoginComponent
    },
    {
        path: 'profile',
        component: ProfileComponent,
        canActivate: [AuthGuard]
    }
];