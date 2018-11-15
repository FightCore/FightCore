import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WikiInfoComponent } from './wiki-info.component';

describe('WikiInfoComponent', () => {
  let component: WikiInfoComponent;
  let fixture: ComponentFixture<WikiInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WikiInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WikiInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
