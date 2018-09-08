import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CharacterPickerComponent } from './character-picker.component';

describe('CharacterPickerComponent', () => {
  let component: CharacterPickerComponent;
  let fixture: ComponentFixture<CharacterPickerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CharacterPickerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CharacterPickerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
