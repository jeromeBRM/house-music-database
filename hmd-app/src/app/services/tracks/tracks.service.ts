import { Service } from '../service';
import { Injectable } from '@angular/core';
import { Track } from '../../model/track';

@Injectable({
  providedIn: 'root'
})
export class TracksService extends Service {
  private apiEndPoint = 'tracks';

  getTracks() {
    return this.httpClient.get<Track[]>(this.inUse + this.apiEndPoint);
  }
}