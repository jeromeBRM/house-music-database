import { Component, Input } from '@angular/core';
import { Scale } from '../../model/scale';
import { ScalesService } from '../../services/scales/scales.service';
import { TrackProfileService } from '../../services/track-profile/track-profile.service';
import { TrackProfile } from '../../model/trackProfile';

@Component({
  selector: 'hmd-track-profile',
  templateUrl: './track-profile.component.html',
  styleUrls: ['./track-profile.component.css']
})
export class TrackProfileComponent {
  @Input() public id : string;

  public trackProfile : TrackProfile;

  /*
  * to refactor :
  */

  public scales : Scale[] = [];
  
  constructor(private service : TrackProfileService, private service2 : ScalesService) {}

  getTrackProfile() {
    let response = this.service.getTrackProfile(this.id);
    return response;
  }

  ngOnInit(): void {
    this.service.getTrackProfile(this.id)
        .subscribe(response => {
          this.trackProfile = response;
          this.trackProfile.scales.forEach(scale => {
            this.service2.getScale(scale)
                .subscribe(response => {
                  this.scales.push(response);
                });
          });
        });
  }
}