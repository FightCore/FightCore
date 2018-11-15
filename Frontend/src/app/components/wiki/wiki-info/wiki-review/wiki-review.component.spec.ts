import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WikiReviewComponent } from './wiki-review.component';

describe('WikiReviewComponent', () => {
  let component: WikiReviewComponent;
  let fixture: ComponentFixture<WikiReviewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WikiReviewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WikiReviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
