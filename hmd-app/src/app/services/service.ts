import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export abstract class Service {
  private apiUrls : { [key: string]: string } = {
    'pre-development' : 'https://localhost:44388/',
    'development' : 'http://localhost/',
    'production' : 'http://90.54.173.2/'
  }
  public inUse : string;

  constructor(protected httpClient : HttpClient) {
    this.inUse = this.apiUrls['development'];
  }
}