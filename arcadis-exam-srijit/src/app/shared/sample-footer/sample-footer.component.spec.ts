import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SampleFooterComponent } from './sample-footer.component';

describe('SampleFooterComponent', () => {
  let component: SampleFooterComponent;
  let fixture: ComponentFixture<SampleFooterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SampleFooterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SampleFooterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
