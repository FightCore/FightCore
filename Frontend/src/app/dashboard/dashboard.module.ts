import { ComponentsModule } from './../components/components.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashGeneratorComponent } from './dash-generator/dash-generator.component';
import { NewsWidgetComponent } from './news-widget/news-widget.component';
import { PostsWidgetComponent } from './posts-widget/posts-widget.component';
import { MatProgressBarModule } from '@angular/material';
import { DashboardService } from '../services/dashboard.service';

@NgModule({
  imports: [
    CommonModule,
    ComponentsModule,
    MatProgressBarModule
  ],
  declarations: [
    DashGeneratorComponent,
    NewsWidgetComponent,
    PostsWidgetComponent
  ],
  entryComponents: [
    DashGeneratorComponent
  ],
  exports: [
    DashGeneratorComponent,
    NewsWidgetComponent,
    PostsWidgetComponent
  ],
  providers: [
    DashboardService
  ]
})
export class DashboardModule { }
