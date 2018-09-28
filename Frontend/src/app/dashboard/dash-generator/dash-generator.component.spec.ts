import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashGeneratorComponent } from './dash-generator.component';

describe('DashGeneratorComponent', () => {
  let component: DashGeneratorComponent;
  let fixture: ComponentFixture<DashGeneratorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashGeneratorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashGeneratorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
