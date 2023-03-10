import { Component, OnInit } from '@angular/core';
import { TracksService } from './services/tracks/tracks.service';

@Component({
  selector: 'hmd-app',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  public title : string = 'hmd';
  public tracks : string[] = [''];

  constructor(private service : TracksService) {}

  get getTracksMethod() {
    return this.ngOnInit.bind(this);
  }

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