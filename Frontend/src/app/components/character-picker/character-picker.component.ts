import { Character } from '../../models/Character';
import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';

@Component({
  selector: 'character-picker',
  templateUrl: './character-picker.component.html',
  styleUrls: ['./character-picker.component.css']
})
export class CharacterPickerComponent implements OnInit {
  @Input("title") placeholderTitle = "Select a Character";
  @Input('showAsRequired') isRequired = false; // By default, don't show as required (asterisk)
  @Input('selectedCharacter') selectedCharacter: number = 0; // By default, initialize to None
  @Output('selectedCharacterChange') selectedCharEmitter = new EventEmitter<Number>(); // For two way binding

  @Output('onCharacterChange') onCharChange = new EventEmitter<Character>(); // For complex change handling
  
  characters: Character[] = [  // Mockup data of characters, should be retrieved from a service
    { id: 0, name: "None"},
    { id: 1, name: "Bayonetta"},
    { id: 2, name: "Bowser"},
    { id: 3, name: "Bowser Jr."},
    { id: 4, name: "Captain Falcon"},
    { id: 5, name: "Charizard"}
  ];

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
