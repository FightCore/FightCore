import { ViewPostComponent } from './../pages/library/view-post/view-post.component';
import { NotificationsComponent } from './../pages/notifications/notifications.component';
import { Routes } from '@angular/router';

import { HomeComponent } from '../pages/home/home.component';
import { LoginPageComponent } from '../pages/login/login-page.component';
import { CharactersComponent } from '../pages/characters/characters.component';
import { PlayersComponent } from './../pages/players/players.component';
import { LibraryComponent } from '../pages/library/library.component';
import { AddPostComponent } from './../pages/library/add-post/add-post.component';
import { NotFoundComponent } from '../pages/not-found/not-found.component';

import { AuthGuard } from '../services/auth-guard.service';
import { ProfileComponent } from '../pages/profile/profile.component';
import { SignupComponent } from '../pages/signup/signup.component';
import { GroupComponent } from '../pages/group/group.component';

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
        path: 'library/add',
        component: AddPostComponent,
        canActivate: [AuthGuard]
    },
    { 
        path: 'library/:id',
        component: ViewPostComponent
    },
    { 
        path: 'library/:id/:postName',
        component: ViewPostComponent
    },
    { 
        path: 'players',
        component: PlayersComponent
    },
    {
        path: 'login',
        component: LoginPageComponent
    },
    {
        path: 'signup',
        component: SignupComponent
    },
    {
        path: 'group',
        component: GroupComponent
    },
    {
        path: 'group/:groupId',
        component: GroupComponent
    },
    {
        path: 'group/:groupId/:groupName',
        component: GroupComponent
    },
    {
        path: 'profile',
        component: ProfileComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'notifications',
        component: NotificationsComponent,
        canActivate: [AuthGuard]
    },
    {
        path: '**',
        component: NotFoundComponent
    }
    
];