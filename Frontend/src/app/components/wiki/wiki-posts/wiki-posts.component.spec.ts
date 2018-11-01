import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WikiPostsComponent } from './wiki-posts.component';

describe('WikiPostsComponent', () => {
  let component: WikiPostsComponent;
  let fixture: ComponentFixture<WikiPostsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WikiPostsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WikiPostsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
