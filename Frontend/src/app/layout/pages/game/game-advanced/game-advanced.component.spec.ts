import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GameAdvancedComponent } from './game-advanced.component';

describe('GameAdvancedComponent', () => {
  let component: GameAdvancedComponent;
  let fixture: ComponentFixture<GameAdvancedComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GameAdvancedComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GameAdvancedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
