import { AuthBridgeService } from './../services/auth-bridge.service';
import { AboutUsComponent } from './pages/home/about-us/about-us.component';
import { MatchupsComponent } from './pages/characters/matchups/matchups.component';
import { BasicsComponent } from './pages/characters/basics/basics.component';
import { AddPostComponent } from './pages/library/add-post/add-post.component';
import { SignupComponent } from './pages/signup/signup.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { LayoutRoutes } from './layout.routing'
import { HomeComponent } from './pages/home/home.component';
import { CharactersComponent } from './pages/characters/characters.component';
import { LibraryComponent } from './pages/library/library.component';
import { PlayersComponent } from './pages/players/players.component';
import { LoginPageComponent } from './pages/login/login-page.component';
import { ProfileComponent } from './pages/profile/profile.component';

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
import { ViewPostComponent } from './pages/library/view-post/view-post.component';
import { CombosTechComponent } from './pages/characters/combos-tech/combos-tech.component';
import { FrameDataComponent } from './pages/characters/frame-data/frame-data.component';
import { OverviewComponent } from './pages/characters/overview/overview.component';
import { NotificationsComponent } from './pages/notifications/notifications.component';
import { NotificationService } from '../services/notification.service';
import { SiteNewsComponent } from './pages/home/site-news/site-news.component';
import { GroupComponent } from './pages/group/group.component';
import { DashboardModule } from '../dashboard/dashboard.module';
import { HomeDashComponent } from './pages/home/home-dash/home-dash.component';

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
      LoginPageComponent,
      NotFoundComponent,
      ProfileComponent,
      BasicsComponent,
      CombosTechComponent,
      MatchupsComponent,
      FrameDataComponent,
      OverviewComponent,
      SignupComponent,
      NotificationsComponent,
      SiteNewsComponent,
      AboutUsComponent,
      GroupComponent,
      HomeDashComponent
  ],
  entryComponents: [
    BasicsComponent,
    CombosTechComponent,
    MatchupsComponent,
    FrameDataComponent,
    OverviewComponent,
    SiteNewsComponent,
    AboutUsComponent,
    HomeDashComponent
  ],
  providers: [
    AuthBridgeService,
    AuthGuard,
    UserService,
    PostService,
    NotificationService
  ]
})

export class LayoutModule {}
