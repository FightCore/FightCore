import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GameJourneymenComponent } from './game-journeymen.component';

describe('GameJourneymenComponent', () => {
  let component: GameJourneymenComponent;
  let fixture: ComponentFixture<GameJourneymenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GameJourneymenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GameJourneymenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
