import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PostEditAddComponent } from './post-edit-add.component';

describe('PostEditAddComponent', () => {
  let component: PostEditAddComponent;
  let fixture: ComponentFixture<PostEditAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PostEditAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PostEditAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
