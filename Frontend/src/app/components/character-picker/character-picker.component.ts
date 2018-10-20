import { Character } from '../../models/Character';
import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { CharacterInfo } from 'src/app/resources/character-info';

@Component({
  selector: 'character-picker',
  templateUrl: './character-picker.component.html',
  styleUrls: ['./character-picker.component.css']
})
export class CharacterPickerComponent implements OnInit {
  @Input("title") placeholderTitle = "Select a Character";
  @Input('showAsRequired') isRequired = false; // By default, don't show as required (asterisk)
  @Input('selectedCharacter') selectedCharacter: number = -1; // By default, initialize to None
  @Output('selectedCharacterChange') selectedCharEmitter = new EventEmitter<Number>(); // For two way binding

  @Output('onCharacterChange') onCharChange = new EventEmitter<Character>(); // For complex change handling
  
  characters: Character[] = CharacterInfo.getCharactersWithNone(1);

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
