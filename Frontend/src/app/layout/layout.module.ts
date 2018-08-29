import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { LayoutRoutes } from './layout.routing'
import { HomeComponent } from '../home/home.component';
import { LoginComponent } from '../login/login.component';

import {
  MatButtonModule,
  MatInputModule,
  MatRippleModule,
  MatTooltipModule,
} from '@angular/material';
@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(LayoutRoutes),
    FormsModule,
    MatButtonModule,
    MatRippleModule,
    MatInputModule,
    MatTooltipModule,
  ],
  declarations: [
      HomeComponent,
      LoginComponent
  ]
})

export class LayoutModule {}
