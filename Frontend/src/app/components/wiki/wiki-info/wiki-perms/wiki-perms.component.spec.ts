import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WikiPermsComponent } from './wiki-perms.component';

describe('WikiPermsComponent', () => {
  let component: WikiPermsComponent;
  let fixture: ComponentFixture<WikiPermsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WikiPermsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WikiPermsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
