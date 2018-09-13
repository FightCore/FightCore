import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'character-picker',
  templateUrl: './character-picker.component.html',
  styleUrls: ['./character-picker.component.css']
})
export class CharacterPickerComponent implements OnInit {
  characters = [
    { name: "None"},
    { name: "Bayonetta"},
    { name: "Bowser"},
    { name: "Bowser Jr."},
    { name: "Captain Falcon"},
    { name: "Charizard"}
  ];

  constructor() { }

  ngOnInit() {
  }

}
