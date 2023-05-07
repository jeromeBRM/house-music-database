import { Injectable } from '@angular/core';
import { Service } from '../service';
import { TrackProfile } from '../../model/trackProfile';

@Injectable({
  providedIn: 'root'
})
export class TrackProfileService extends Service {
  private apiEndPoint = 'track-profiles?id=';

  getTrackProfile(id : string) {
    return this.httpClient.get<TrackProfile>(this.inUse + this.apiEndPoint + id);
  }

  getTrackProfiles() {
    return this.httpClient.get<TrackProfile[]>(this.inUse + this.apiEndPoint);
  }
}