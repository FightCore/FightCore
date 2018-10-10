import { Routes } from '@angular/router';

import { HomeComponent } from '../pages/home/home.component';
import { LoginComponent } from '../pages/login/login.component';
import { CharactersComponent } from '../pages/characters/characters.component';
import { PlayersComponent } from './../pages/players/players.component';
import { LibraryComponent } from '../pages/library/library.component';
import { NotFoundComponent } from '../pages/not-found/not-found.component';

import { AuthGuard } from '../services/auth-guard.service';
import { ProfileComponent } from '../pages/profile/profile.component';
import { SignupComponent } from '../pages/signup/signup.component';

export const LayoutRoutes: Routes = [
    { 
        path: 'home',
        component: HomeComponent
    },
    { 
        path: 'characters',
        component: CharactersComponent
    },
    { 
        path: 'library',
        component: LibraryComponent
    },
    { 
        path: 'players',
        component: PlayersComponent
    },
    {
        path: 'login',
        component: LoginComponent
    },
    {
        path: 'signup',
        component: SignupComponent
    },
    {
        path: 'profile',
        component: ProfileComponent,
        canActivate: [AuthGuard]
    },
    {
        path: '**',
        component: NotFoundComponent
    }
    
];