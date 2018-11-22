import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FrameDataComponent } from './frame-data.component';

describe('FrameDataComponent', () => {
  let component: FrameDataComponent;
  let fixture: ComponentFixture<FrameDataComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FrameDataComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FrameDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
