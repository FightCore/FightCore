import { Component, OnInit } from '@angular/core';
import { CharacterIcon } from 'src/app/models/characterIcon';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-character-picker',
  templateUrl: './character-picker.component.html',
  styleUrls: ['./character-picker.component.scss']
})
export class CharacterPickerComponent implements OnInit {
  constructor() { }
  readonly baseURL = 'https://i.fightcore.org/ultimate/stocks/';
  icons: CharacterIcon[];
  ngOnInit() {
    this.icons = this.getIcons();
  }
  //TODO: Move to a seperate service.
  getIcons() : CharacterIcon[] {
    return [
      new CharacterIcon('Bayonetta', 'bayonetta'),
      new CharacterIcon('Bowser', 'bowser'),
      new CharacterIcon('Bowser Jr.', 'bowser_jr'),
      new CharacterIcon('Captain Falcon', 'captain_falcon'),
      new CharacterIcon('Chrom', 'chrom'),
      new CharacterIcon('Cloud', 'cloud')
    ];
  }

  protected createIconUrl(name: string): string {
    return this.createImageUrl(name, 'ultimate', 'stocks');
  }
  private createImageUrl(name: string, game: string, type: string): string {
    return `${environment.imageUrl}${game}/${type}/${name}.png`;
  }
}
