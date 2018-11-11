import { TestBed, inject } from '@angular/core/testing';

import { GameInfoService } from './game-info.service';

describe('GameInfoService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [GameInfoService]
    });
  });

  it('should be created', inject([GameInfoService], (service: GameInfoService) => {
    expect(service).toBeTruthy();
  }));
});
