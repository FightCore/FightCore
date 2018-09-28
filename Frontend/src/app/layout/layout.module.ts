import { MatchupsComponent } from './../pages/characters/matchups/matchups.component';
import { MovesComponent } from './../pages/characters/moves/moves.component';
import { BasicsComponent } from './../pages/characters/basics/basics.component';
import { DashboardModule } from './../dashboard/dashboard.module';
import { AddPostComponent } from './../pages/library/add-post/add-post.component';
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
import { LoginComponent } from '../login/login.component';
import { ProfileComponent } from '../profile/profile.component';

import { AuthGuard } from '../services/auth-guard.service';
import { UserService } from '../services/user.service';
import {NgbModule, NgbDatepickerModule, NgbModalModule} from '@ng-bootstrap/ng-bootstrap';

import {
  MatButtonModule,
  MatInputModule,
  MatRippleModule,
  MatTooltipModule
} from '@angular/material';
import { ComponentsModule } from '../components/components.module';
import { PostService } from '../services/post.service';
import { ViewPostComponent } from '../pages/library/view-post/view-post.component';
import { CombosTechComponent } from '../pages/characters/combos-tech/combos-tech.component';

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
    ComponentsModule,
    NgbDatepickerModule,
    NgbModalModule,
    DashboardModule
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
      MovesComponent,
      CombosTechComponent,
      MatchupsComponent
  ],
  entryComponents: [
    BasicsComponent,
    MovesComponent,
    CombosTechComponent,
    MatchupsComponent
  ],
  providers: [
    AuthGuard,
    UserService,
    PostService
  ]
})

export class LayoutModule {}
