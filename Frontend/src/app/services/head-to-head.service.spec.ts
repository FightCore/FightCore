import { TestBed, inject } from '@angular/core/testing';

import { HeadToHeadService } from './head-to-head.service';

describe('HeadToHeadService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [HeadToHeadService]
    });
  });

  it('should be created', inject([HeadToHeadService], (service: HeadToHeadService) => {
    expect(service).toBeTruthy();
  }));
});
