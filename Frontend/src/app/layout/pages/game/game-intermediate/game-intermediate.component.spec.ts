import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GameIntermediateComponent } from './game-intermediate.component';

describe('GameIntermediateComponent', () => {
  let component: GameIntermediateComponent;
  let fixture: ComponentFixture<GameIntermediateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GameIntermediateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GameIntermediateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
