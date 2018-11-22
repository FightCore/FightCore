import { ComponentsModule } from './../components/components.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashGeneratorComponent } from './dash-generator/dash-generator.component';
import { NewsWidgetComponent } from './news-widget/news-widget.component';
import { PostsWidgetComponent } from './posts-widget/posts-widget.component';

@NgModule({
  imports: [
    CommonModule,
    ComponentsModule
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
  ]
})
export class DashboardModule { }
