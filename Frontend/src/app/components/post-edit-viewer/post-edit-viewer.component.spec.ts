import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PostEditViewerComponent } from './post-edit-viewer.component';

describe('PostEditViewerComponent', () => {
  let component: PostEditViewerComponent;
  let fixture: ComponentFixture<PostEditViewerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PostEditViewerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PostEditViewerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
