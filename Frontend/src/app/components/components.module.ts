import { CharacterPickerComponent } from './character-picker/character-picker.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { FooterComponent } from './footer/footer.component';
import { NavbarComponent } from './navbar/navbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { GameSwitcherComponent } from './game-switcher/game-switcher.component';
import { MatSelectModule, MatTabsModule, MatProgressBarModule, MatPaginatorModule, MatToolbarModule } from '@angular/material';
import { TabsComponent } from './tabs/tabs.component';
import { TabExampleComponent } from './tabs/tab-example/tab-example.component';
import { TabContentsComponent } from './tabs/tab/tab-contents.component';
import { TabDirective } from './tabs/tab/tab.directive';
import { NotificationsViewerComponent } from './notifications-viewer/notifications-viewer.component';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    MatSelectModule,
    MatTabsModule,
    MatProgressBarModule,
    MatPaginatorModule,
    MatToolbarModule,
    ToastrModule.forRoot()
  ],
  declarations: [
    FooterComponent,
    NavbarComponent,
    SidebarComponent,
    GameSwitcherComponent, // No reason to export for now
    CharacterPickerComponent,
    TabsComponent,
    TabExampleComponent,
    TabContentsComponent,
    TabDirective,
    NotificationsViewerComponent
  ],
  entryComponents: [TabExampleComponent],
  exports: [
    FooterComponent,
    NavbarComponent,
    SidebarComponent,
    CharacterPickerComponent,
    TabsComponent,
    TabExampleComponent, // for testing purposes
    NotificationsViewerComponent
  ]
})
export class ComponentsModule { }
