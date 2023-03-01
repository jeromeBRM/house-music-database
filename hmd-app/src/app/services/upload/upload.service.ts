import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UploadResponse } from '../../model/uploadResponse';

@Injectable({
  providedIn: 'root'
})
export class UploadService {
  private apiEndPoint = 'http://90.54.173.2/upload/';

  constructor(private httpClient : HttpClient) { }

  postFiles(formData : any) {
    return this.httpClient.post<UploadResponse>(this.apiEndPoint, formData);
  }
}