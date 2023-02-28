import { Component, OnInit } from '@angular/core';
import { Tracklist } from './model/tracklist';
import { TracksService } from './services/tracks.service';

@Component({
  selector: 'hmd-app',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  title : string = 'hmd-app';
  tracks : string[] = [''];

  constructor(private service : TracksService) {}

  getTracks() {
    let response = this.service.getTracks();
    return response;
  }

  ngOnInit(): void {
    this.service.getTracks()
        .subscribe(response => {
          this.tracks = response.tracks;
        });
  }
}