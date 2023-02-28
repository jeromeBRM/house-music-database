import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Tracklist } from '../model/tracklist';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TracksService {
  private apiEndPoint = 'http://90.54.173.2/tracks/';

  constructor(private httpClient : HttpClient) { }

  getTracks() {
    return this.httpClient.get<Tracklist>(this.apiEndPoint);
  }
}