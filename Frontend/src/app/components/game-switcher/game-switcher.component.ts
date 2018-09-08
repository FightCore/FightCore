import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'game-switcher',
  templateUrl: './game-switcher.component.html',
  styleUrls: ['./game-switcher.component.css']
})
export class GameSwitcherComponent implements OnInit {
  games = [
    "Smash 4",
    "Melee",
    "Rivals of Aether"
  ];

  constructor() { }

  ngOnInit() {
  }

}
