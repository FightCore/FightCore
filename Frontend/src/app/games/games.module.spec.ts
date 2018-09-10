import { GamesModule } from './games.module';

describe('GamesModule', () => {
  let gamesModule: GamesModule;

  beforeEach(() => {
    gamesModule = new GamesModule();
  });

  it('should create an instance', () => {
    expect(gamesModule).toBeTruthy();
  });
});
