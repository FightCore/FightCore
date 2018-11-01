import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PostSortComponent } from './post-sort.component';

describe('PostSortComponent', () => {
  let component: PostSortComponent;
  let fixture: ComponentFixture<PostSortComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PostSortComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PostSortComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
