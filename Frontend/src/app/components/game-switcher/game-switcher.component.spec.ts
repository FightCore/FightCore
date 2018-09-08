import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GameSwitcherComponent } from './game-switcher.component';

describe('GameSwitcherComponent', () => {
  let component: GameSwitcherComponent;
  let fixture: ComponentFixture<GameSwitcherComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GameSwitcherComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GameSwitcherComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
