import { NgModule } from '@angular/core';
import { CommonModule, } from '@angular/common';
import { BrowserModule  } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';

import { LayoutComponent } from './layout/layout.component';

const routes: Routes =[
    {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full',
      },
    {
    path: '',
    component: LayoutComponent,
    children: [
        {
      path: '',
      loadChildren: './layout/layout.module#LayoutModule'
  }]}
];

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    RouterModule.forRoot(routes)
  ],
  exports: [
  ],
})
export class AppRoutingModule { }
