import { Component, Input } from '@angular/core';
import { TracksService } from '../../services/tracks/tracks.service';
import { TrackProfileService } from '../../services/track-profile/track-profile.service';
import { Track } from '../../model/track';
import { Scale } from '../../model/scale';
import { TrackProfile } from '../../model/trackProfile';
import { ScalesService } from '../../services/scales/scales.service';
import { PlayerComponent } from '../player/player.component';

@Component({
  selector: 'hmd-tracklist',
  templateUrl: './tracklist.component.html',
  styleUrls: ['./tracklist.component.css']
})
export class TracklistComponent {
  public properties : string[] = ['Name', 'Source', 'Deep', 'Dream', 'Decay', 'Shade'];

  public tracks : Track[] = [];
  public trackProfiles : TrackProfile[] = [];
  public scales : Scale[] = [];

  @Input() public player : PlayerComponent;

  constructor(private tracksService : TracksService, private trackProfileService : TrackProfileService, private scalesService : ScalesService) {}

  ready(){
    return this.tracks.length > 0 && this.trackProfiles.length > 0 && this.scales.length > 0;
  }

  selectTrack(track : Track) {
    this.player.setTrack(track);
  }

  get getTracksMethod() {
    return this.getTracks.bind(this);
  }

  getTracks() {
    this.tracks = [];
    this.trackProfiles = [];
    this.scales = [];

    this.tracksService.getTracks()
        .subscribe(response => {
          this.tracks = response;
        });
    
    this.trackProfileService.getTrackProfiles()
        .subscribe(response => {
          this.trackProfiles = response;
        });

    this.scalesService.getScales()
        .subscribe(response => {
          this.scales = response;
        });
  }

  getScale(trackProfileId : string, name : string) : any {
    let trackProfile = this.trackProfiles.find(tp => {
      return tp.id === trackProfileId;
    });

    return this.scales.find(scale => trackProfile?.scales.includes(scale.id) && scale.name === name);
  }

  getScales(trackProfileId : string) : any {
    let trackProfile = this.trackProfiles.find(tp => {
      return tp.id === trackProfileId;
    });

    return this.scales.filter(scale => trackProfile?.scales.includes(scale.id));
  }
}