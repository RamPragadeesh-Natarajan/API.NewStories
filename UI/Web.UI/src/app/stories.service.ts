import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
  
@Injectable({
  providedIn: 'root'
})
export class StoriesService {
  private url = 'https://localhost:7210/getNewStories';
   
  constructor(private httpClient: HttpClient) { }
  
  getNewStories(id:any){
    return this.httpClient.get(this.url+'/'+id);
  }
  
}