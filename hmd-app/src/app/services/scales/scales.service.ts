import { Injectable } from '@angular/core';
import { Service } from '../service';
import { Scale } from '../../model/scale';

@Injectable({
  providedIn: 'root'
})
export class ScalesService extends Service {
  private apiEndPoint = 'scales';

  getScales(id : string) {
    return this.httpClient.get<Scale[]>(this.inUse + this.apiEndPoint);
  }
}