import { ComponentsModule } from './../components/components.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExampleWidgetComponent } from './example-widget/example-widget.component';
import { DashGeneratorComponent } from './dash-generator/dash-generator.component';

@NgModule({
  imports: [
    CommonModule,
    ComponentsModule
  ],
  declarations: [
    DashGeneratorComponent,
    ExampleWidgetComponent
  ],
  entryComponents: [
    DashGeneratorComponent
  ],
  exports: [
    DashGeneratorComponent,
    ExampleWidgetComponent
  ]
})
export class DashboardModule { }
