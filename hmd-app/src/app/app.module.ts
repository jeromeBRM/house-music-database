import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TrackComponent } from './components/track/track.component';
import { TracklistComponent } from './components/tracklist/tracklist.component';
import { UploadComponent } from './components/upload/upload.component';
import { UpdaterComponent } from './components/updater/updater.component';

@NgModule({
  declarations: [
    AppComponent,
    TrackComponent,
    UploadComponent,
    TracklistComponent,
    UpdaterComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }