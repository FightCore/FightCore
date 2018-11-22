import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CombosTechComponent } from './combos-tech.component';

describe('CombosTechComponent', () => {
  let component: CombosTechComponent;
  let fixture: ComponentFixture<CombosTechComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CombosTechComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CombosTechComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
