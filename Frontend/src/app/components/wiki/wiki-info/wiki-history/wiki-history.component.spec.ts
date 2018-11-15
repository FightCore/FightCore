import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WikiHistoryComponent } from './wiki-history.component';

describe('WikiHistoryComponent', () => {
  let component: WikiHistoryComponent;
  let fixture: ComponentFixture<WikiHistoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WikiHistoryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WikiHistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
