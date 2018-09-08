import { CharacterPickerComponent } from './character-picker/character-picker.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { FooterComponent } from './footer/footer.component';
import { NavbarComponent } from './navbar/navbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { GameSwitcherComponent } from './game-switcher/game-switcher.component';
import { MatSelectModule } from '@angular/material';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    MatSelectModule
  ],
  declarations: [
    FooterComponent,
    NavbarComponent,
    SidebarComponent,
    GameSwitcherComponent, // Choosing not to export for now
    CharacterPickerComponent
  ],
  exports: [
    FooterComponent,
    NavbarComponent,
    SidebarComponent,
    CharacterPickerComponent
  ]
})
export class ComponentsModule { }
