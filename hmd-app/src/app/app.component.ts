import { Component, ViewChild } from '@angular/core';
import { TracklistComponent } from './components/tracklist/tracklist.component';
import { PlayerComponent } from './components/player/player.component';

@Component({
  selector: 'hmd-app',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  public title : string = 'hmd';

  @ViewChild(TracklistComponent) tracklist : TracklistComponent;
  @ViewChild(PlayerComponent) player : PlayerComponent;

  get getTracksMethod() {
    return this.ngAfterViewInit.bind(this);
  }

  ngAfterViewInit(): void {
    this.tracklist.getTracks();
    this.tracklist.player = this.player;
  }
}