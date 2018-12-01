import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HeadToHeadComponent } from './head-to-head.component';

describe('HeadToHeadComponent', () => {
  let component: HeadToHeadComponent;
  let fixture: ComponentFixture<HeadToHeadComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HeadToHeadComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HeadToHeadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
