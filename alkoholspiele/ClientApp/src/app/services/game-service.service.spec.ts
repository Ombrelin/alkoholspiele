import { TestBed } from '@angular/core/testing';

import { GameServiceService } from './game-service.service';

describe('GameServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: GameServiceService = TestBed.get(GameServiceService);
    expect(service).toBeTruthy();
  });
});
