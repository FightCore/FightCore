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

import {
  MatButtonModule,
  MatInputModule,
  MatRippleModule,
  MatTooltipModule
} from '@angular/material';
import { ComponentsModule } from '../components/components.module';

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
    ComponentsModule
  ],
  declarations: [
      HomeComponent,
      CharactersComponent,
      LibraryComponent,
      PlayersComponent,
      LoginComponent,
      NotFoundComponent
  ]
})

export class LayoutModule {}
