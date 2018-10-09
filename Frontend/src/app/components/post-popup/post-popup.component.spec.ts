import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PostPopupComponent } from './post-popup.component';

describe('PostPopupComponent', () => {
  let component: PostPopupComponent;
  let fixture: ComponentFixture<PostPopupComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PostPopupComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PostPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
