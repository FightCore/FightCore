import { TestBed, inject } from '@angular/core/testing';

import { BaseAuthGuard } from './base-auth-guard.service';

describe('BaseAuthGuardService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BaseAuthGuard]
    });
  });

  it('should be created', inject([BaseAuthGuard], (service: BaseAuthGuard) => {
    expect(service).toBeTruthy();
  }));
});
