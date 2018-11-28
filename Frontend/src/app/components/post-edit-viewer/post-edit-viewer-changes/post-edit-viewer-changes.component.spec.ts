import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PostEditViewerChangesComponent } from './post-edit-viewer-changes.component';

describe('PostEditViewerChangesComponent', () => {
  let component: PostEditViewerChangesComponent;
  let fixture: ComponentFixture<PostEditViewerChangesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PostEditViewerChangesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PostEditViewerChangesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
