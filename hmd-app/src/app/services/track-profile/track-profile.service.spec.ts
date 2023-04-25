import { TestBed } from '@angular/core/testing';

import { TrackProfileService } from './track-profile.service';

describe('TrackProfileService', () => {
  let service: TrackProfileService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TrackProfileService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});