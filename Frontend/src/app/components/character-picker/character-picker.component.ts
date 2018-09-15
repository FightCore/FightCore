import { CharacterInterface } from '../../common/character.interface';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'character-picker',
  templateUrl: './character-picker.component.html',
  styleUrls: ['./character-picker.component.css']
})
export class CharacterPickerComponent implements OnInit {
  @Output('onCharacterChange') onCharChange: EventEmitter<CharacterInterface> = new EventEmitter();
  
  characters: CharacterInterface[] = [  // Mockup data of characters, should be retrieved from a service
    { id: 0, name: "None"},
    { id: 1, name: "Bayonetta"},
    { id: 2, name: "Bowser"},
    { id: 3, name: "Bowser Jr."},
    { id: 4, name: "Captain Falcon"},
    { id: 5, name: "Charizard"}
  ];

  selectedCharacter: number = 0; // Initialize to None

  constructor() { }

  ngOnInit() {
  }

  
  /**
   * Called when user selects a character (or None) from selector
   */
  onSelectionChange() {
    // TODO: Safety check that this.selectedCharacter is within characters array

    // Pass the selected character to the parent
    this.onCharChange.emit(this.characters[this.selectedCharacter]);
  }

}
