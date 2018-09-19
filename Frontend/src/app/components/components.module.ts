import { CharacterPickerComponent } from './character-picker/character-picker.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { FooterComponent } from './footer/footer.component';
import { NavbarComponent } from './navbar/navbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { GameSwitcherComponent } from './game-switcher/game-switcher.component';
import { MatSelectModule, MatTabsModule, MatStepperModule, MatInputModule, MatButtonModule, MatDialog, MatDialogModule, MatButtonToggleModule } from '@angular/material';
import { TabsComponent } from './tabs/tabs.component';
import { TabExampleComponent } from './tabs/tab-example/tab-example.component';
import { TabContentsComponent } from './tabs/tab/tab-contents.component';
import { TabDirective } from './tabs/tab/tab.directive';
import { PostEditorComponent } from './post-editor/post-editor.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { ConfirmDialogComponent } from './confirm-dialog/confirm-dialog.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    MatSelectModule,
    MatTabsModule,
    MatStepperModule,
    MatInputModule,
    MatButtonModule,
    MatDialogModule,
    MatButtonToggleModule,
    FormsModule,
    ReactiveFormsModule,
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
    PostEditorComponent,
    ConfirmDialogComponent
  ],
  entryComponents: [
    TabExampleComponent,
    ConfirmDialogComponent
  ],
  exports: [
    FooterComponent,
    NavbarComponent,
    SidebarComponent,
    CharacterPickerComponent,
    PostEditorComponent,
    TabsComponent,
    TabExampleComponent // for testing purposes
  ]
})
export class ComponentsModule { }
