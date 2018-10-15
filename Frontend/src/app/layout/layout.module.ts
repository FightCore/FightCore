import { SignupComponent } from './../pages/signup/signup.component';
import { NotFoundComponent } from './../pages/not-found/not-found.component';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { LayoutRoutes } from './layout.routing'
import { HomeComponent } from '../pages/home/home.component';
import { CharactersComponent } from '../pages/characters/characters.component';
import { LibraryComponent } from '../pages/library/library.component';
import { PlayersComponent } from './../pages/players/players.component';
import { LoginComponent } from '../pages/login/login.component';
import { ProfileComponent } from '../pages/profile/profile.component';

import { AuthGuard } from '../services/auth-guard.service';
import { UserService } from '../services/user.service';

import {
  MatButtonModule,
  MatInputModule,
  MatRippleModule,
  MatTooltipModule,
  MatProgressBarModule
} from '@angular/material';
import { ComponentsModule } from '../components/components.module';
import { NotificationsComponent } from '../pages/notifications/notifications.component';
import { NotificationService } from '../services/notification.service';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(LayoutRoutes),
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatRippleModule,
    MatInputModule,
    MatTooltipModule,
    MatProgressBarModule,
    ComponentsModule
  ],
  declarations: [
      HomeComponent,
      CharactersComponent,
      LibraryComponent,
      PlayersComponent,
      LoginComponent,
      NotFoundComponent,
      LoginComponent, 
      ProfileComponent,
      SignupComponent,
      NotificationsComponent
  ],
  providers: [
    AuthGuard,
    UserService,
    NotificationService
  ]
})

export class LayoutModule {}
