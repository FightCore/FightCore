import { MatchupsComponent } from './../pages/characters/matchups/matchups.component';
import { BasicsComponent } from './../pages/characters/basics/basics.component';
import { DashboardModule } from './../dashboard/dashboard.module';
import { AddPostComponent } from './../pages/library/add-post/add-post.component';
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
import { HeadToHeadComponent } from '../pages/head-to-head/head-to-head.component';

import { AuthGuard } from '../services/auth-guard.service';
import { UserService } from '../services/user.service';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';

import {
  MatButtonModule,
  MatInputModule,
  MatRippleModule,
  MatTooltipModule,
  MatPaginatorModule,
  MatSelectModule,
  MatProgressBarModule
} from '@angular/material';
import { ComponentsModule } from '../components/components.module';
import { PostService } from '../services/post.service';
import { ViewPostComponent } from '../pages/library/view-post/view-post.component';
import { CombosTechComponent } from '../pages/characters/combos-tech/combos-tech.component';
import { FrameDataComponent } from '../pages/characters/frame-data/frame-data.component';
import { OverviewComponent } from '../pages/characters/overview/overview.component';
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
    MatPaginatorModule,
    MatSelectModule,
    MatProgressBarModule,
    ComponentsModule,
    NgbDatepickerModule,
    DashboardModule,
    MatProgressBarModule,
    ComponentsModule
  ],
  declarations: [
      HomeComponent,
      CharactersComponent,
      LibraryComponent,
      AddPostComponent,
      ViewPostComponent,
      PlayersComponent,
      LoginComponent,
      NotFoundComponent,
      LoginComponent, 
      ProfileComponent,
      BasicsComponent,
      CombosTechComponent,
      MatchupsComponent,
      FrameDataComponent,
      OverviewComponent,
      SignupComponent,
      NotificationsComponent,
      HeadToHeadComponent

  ],
  entryComponents: [
    BasicsComponent,
    CombosTechComponent,
    MatchupsComponent,
    FrameDataComponent,
    OverviewComponent
  ],
  providers: [
    AuthGuard,
    UserService,
    PostService,
    NotificationService
  ]
})

export class LayoutModule {}
