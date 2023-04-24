import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrackProfileComponent } from './track-profile.component';

describe('TrackProfileComponent', () => {
  let component: TrackProfileComponent;
  let fixture: ComponentFixture<TrackProfileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TrackProfileComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TrackProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});