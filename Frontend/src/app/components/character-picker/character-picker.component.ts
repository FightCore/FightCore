import { Character } from '../../models/Character';
import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { CharacterInfo } from 'src/app/resources/character-info';

@Component({
  selector: 'character-picker',
  templateUrl: './character-picker.component.html',
  styleUrls: ['./character-picker.component.scss']
})
export class CharacterPickerComponent implements OnInit {
  // TODO: In search bar, entering space will choose an option and close. Want enter not space!

  @Input('placeholder') placeholderTitle = 'Select a Character';
  @Input('showAsRequired') isRequired = false; // By default, don't show as required (asterisk vs close button)
  @Input('multiple') isMultiple = false;
  @Input('defaultChar') defaultChar: number = -1;
  @Input('defaultMultiChars') defaultMultipleChar: number[] = [];

  @Output('onCharChange') onCharChange = new EventEmitter<Character>();
  @Output('onMultiCharChange') onMultiCharChange = new EventEmitter<Character[]>();

  fullCharList: Character[];
  displayCharacters: Character[];

  selection: number | number[];
  searchVal = '';

  constructor() { }

  ngOnInit() {
    this.fullCharList = CharacterInfo.getCharacters(1); // Just a shortcut
    this.displayCharacters = this.fullCharList; // Display all by default

    if (this.isMultiple) {
      this.selection = this.defaultMultipleChar;
    } else {
      this.selection = this.defaultChar;
    }
  }

  /**
   * Called when user selects a character (or clears selection) from selector
   */
  onSelectionChange() {
    // Pass the selected character to the parent depending on selection type
    let typeCheckedSel; // Make the compiler happy, could also use typeof checking instead
    if (this.isMultiple) {
      typeCheckedSel = this.selection as number[];

      // Build the list of selected characters and output it
      let selectedChars: Character[] = [];
      typeCheckedSel.forEach(id => {
        selectedChars.push(this.fullCharList[id]);
      });
      this.onMultiCharChange.emit(selectedChars);
    } else {
      typeCheckedSel = this.selection as number;
      this.onCharChange.emit(this.fullCharList[typeCheckedSel]);
    }
  }

  onClearCatSelect() {
    if (this.isMultiple) {
      this.selection = [];
    } else {
      this.selection = -1;
    }
    this.onSelectionChange();
  }

  onSearchChange() {
    // TODO: Make sure performance here is alright on mobile devices with full char list
    this.displayCharacters = this.fullCharList.filter(
      char => char.name.includes(this.searchVal)
    );
  }

  onSearchClear() {
    this.searchVal = '';
    this.onSearchChange();
  }

}
