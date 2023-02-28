import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PostService {
  private apiEndPoint = 'http://90.54.173.2/tracks/';

  constructor(private httpClient : HttpClient) { }

  getPosts() {
    return this.httpClient.get(this.apiEndPoint);
  }
}