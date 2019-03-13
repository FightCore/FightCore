import { CharacterPickerComponent } from './character-picker/character-picker.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { FooterComponent } from './footer/footer.component';
import { NavbarComponent } from './navbar/navbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { GameSwitcherComponent } from './game-switcher/game-switcher.component';
import { MatSelectModule, MatTabsModule, MatStepperModule, MatInputModule, MatButtonModule,
  MatDialogModule, MatButtonToggleModule, MatGridListModule, MatIconModule, MatProgressBarModule,
  MatProgressSpinnerModule, MatPaginatorModule, MatToolbarModule } from '@angular/material';
import { TabsComponent } from './tabs/tabs.component';
import { TabExampleComponent } from './tabs/tab-example/tab-example.component';
import { TabContentsComponent } from './tabs/tab/tab-contents.component';
import { TabDirective } from './tabs/tab/tab.directive';
import { PostEditorComponent } from './post-editor/post-editor.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { ConfirmDialogComponent } from './confirm-dialog/confirm-dialog.component';
import { PostViewerComponent } from './post-viewer/post-viewer.component';
import { PostFiltersComponent } from './post-filters/post-filters.component';
import { PostSortComponent } from './post-sort/post-sort.component';
import { WikiPostsComponent } from './wiki/wiki-posts/wiki-posts.component';
import { PostPopupComponent } from './post-popup/post-popup.component';
import { PopupComponent } from './popup/popup.component';
import { EditorComponent } from './editor/editor.component';
import { NotificationsViewerComponent } from './notifications-viewer/notifications-viewer.component';
// import { ToastrModule } from 'ngx-toastr';
import { NgbModalModule, NgbTooltipModule } from '@ng-bootstrap/ng-bootstrap';
import { NotificationService } from '../services/notification.service';
import { CovalentTextEditorModule } from '@covalent/text-editor';
import { QuillModule } from 'ngx-quill';
import { MarkdownModule } from 'ngx-markdown';

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
    MatGridListModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    FormsModule,
    ReactiveFormsModule,
    MatIconModule,
    MatProgressBarModule,
    MatPaginatorModule,
    MatToolbarModule,
    // ToastrModule.forRoot(),
    MarkdownModule.forRoot(),
    NgbModalModule, // Yes this is necessary for popups even if not directly used anywhere
    NgbTooltipModule,
    CovalentTextEditorModule,
    QuillModule,
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
    ConfirmDialogComponent,
    PostViewerComponent,
    PostFiltersComponent,
    PostSortComponent,
    WikiPostsComponent,
    PostPopupComponent,
    PopupComponent,
    EditorComponent,
    NotificationsViewerComponent
  ],
  entryComponents: [
    TabExampleComponent,
    ConfirmDialogComponent,
    PostViewerComponent,
    NotificationsViewerComponent
  ],
  exports: [
    FooterComponent,
    NavbarComponent,
    SidebarComponent,
    CharacterPickerComponent,
    PostEditorComponent,
    PostViewerComponent,
    PostFiltersComponent,
    PostSortComponent,
    TabsComponent,
    TabExampleComponent, // for testing purposes
    WikiPostsComponent,
    PostPopupComponent,
    PopupComponent,
    EditorComponent, // TODO: Not sure if this should be external
    NotificationsViewerComponent
  ],
  providers: [
    NotificationService
  ]
})
export class ComponentsModule { }
