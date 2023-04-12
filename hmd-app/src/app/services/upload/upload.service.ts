import { Service } from '../service';
import { UploadResponse } from '../../model/uploadResponse';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UploadService extends Service {
  private apiEndPoint = 'upload';

  postFiles(formData : any) {
    return this.httpClient.post<UploadResponse>(this.inUse + this.apiEndPoint, formData);
  }
}