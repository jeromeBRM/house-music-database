import { Component, OnInit } from '@angular/core';
import { TracksService } from '../../services/tracks/tracks.service';
import { Track } from '../../model/track';

@Component({
  selector: 'hmd-tracklist',
  templateUrl: './tracklist.component.html',
  styleUrls: ['./tracklist.component.css']
})
export class TracklistComponent {
  public tracks : Track[];

  constructor(private service : TracksService) {}

  getTracks() {
    this.service.getTracks()
        .subscribe(response => {
          this.tracks = response;
        });
  }
}