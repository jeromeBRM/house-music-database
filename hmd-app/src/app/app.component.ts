import { Component, OnInit, ViewChild } from '@angular/core';
import { TracklistComponent } from './components/tracklist/tracklist.component';

@Component({
  selector: 'hmd-app',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  public title : string = 'hmd';

  @ViewChild(TracklistComponent) tracklist : TracklistComponent;

  get getTracksMethod() {
    return this.ngAfterViewInit.bind(this);
  }

  ngAfterViewInit(): void {
    this.tracklist.getTracks();
  }
}