import { TestBed } from '@angular/core/testing';

import { AgServiceService } from './ag-service.service';

describe('AgServiceService', () => {
  let service: AgServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AgServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
