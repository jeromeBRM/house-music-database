import { Component, Input, ViewChild } from '@angular/core';
import { Track } from '../../model/track';

@Component({
  selector: 'hmd-player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.css']
})
export class PlayerComponent {
  @Input() public inPlay : Track;

  @ViewChild('audio') audio : any;

  public setTrack(track : Track) {
    this.inPlay = track;
    this.audio.nativeElement.load();
    this.audio.nativeElement.currentTime = 0;
    this.audio.nativeElement.play();
  }
}