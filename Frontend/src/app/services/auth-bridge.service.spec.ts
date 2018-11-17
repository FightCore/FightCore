import { TestBed, inject } from '@angular/core/testing';

import { AuthBridgeService } from './auth-bridge.service';

describe('AuthBridgeService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AuthBridgeService]
    });
  });

  it('should be created', inject([AuthBridgeService], (service: AuthBridgeService) => {
    expect(service).toBeTruthy();
  }));
});
