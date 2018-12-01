import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { H2hDisplayComponent } from './h2h-display.component';

describe('H2hDisplayComponent', () => {
  let component: H2hDisplayComponent;
  let fixture: ComponentFixture<H2hDisplayComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ H2hDisplayComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(H2hDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
