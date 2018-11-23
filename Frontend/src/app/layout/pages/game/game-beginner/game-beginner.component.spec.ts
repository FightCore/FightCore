import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GameBeginnerComponent } from './game-beginner.component';

describe('GameBeginnerComponent', () => {
  let component: GameBeginnerComponent;
  let fixture: ComponentFixture<GameBeginnerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GameBeginnerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GameBeginnerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
