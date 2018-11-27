import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PostEditAddContentsComponent } from './post-edit-add-contents.component';

describe('PostEditAddContentsComponent', () => {
  let component: PostEditAddContentsComponent;
  let fixture: ComponentFixture<PostEditAddContentsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PostEditAddContentsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PostEditAddContentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
