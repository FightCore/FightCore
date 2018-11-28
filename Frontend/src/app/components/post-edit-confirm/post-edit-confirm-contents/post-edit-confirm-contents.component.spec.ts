import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PostEditConfirmContentsComponent } from './post-edit-confirm-contents.component';

describe('PostEditConfirmContentsComponent', () => {
  let component: PostEditConfirmContentsComponent;
  let fixture: ComponentFixture<PostEditConfirmContentsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PostEditConfirmContentsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PostEditConfirmContentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
