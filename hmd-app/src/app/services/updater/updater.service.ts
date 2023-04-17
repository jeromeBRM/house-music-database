import { Injectable } from '@angular/core';
import { Service } from '../service';

@Injectable({
  providedIn: 'root'
})
export class UpdaterService extends Service {
  private apiEndPoint = 'update';

  update(formData : any) {
    return this.httpClient.post(this.inUse + this.apiEndPoint, formData);
  }
}