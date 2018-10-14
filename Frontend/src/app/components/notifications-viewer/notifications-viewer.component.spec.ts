import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NotificationsViewerComponent } from './notifications-viewer.component';

describe('NotificationsViewerComponent', () => {
  let component: NotificationsViewerComponent;
  let fixture: ComponentFixture<NotificationsViewerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NotificationsViewerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NotificationsViewerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
