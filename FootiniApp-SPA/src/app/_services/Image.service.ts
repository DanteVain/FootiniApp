import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { ReturnedImage } from '../_models/returnedimage';

@Injectable({
  providedIn: 'root'
})
export class ImageService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getImages(id: number): Observable<ReturnedImage[]> {
    return this.http.get<ReturnedImage[]>(this.baseUrl + 'users/' + id + '/images/');
  }

  getImage(id: number): Observable<ReturnedImage> {
    return this.http.get<ReturnedImage>(this.baseUrl + 'users/' + id);
  }

  updateImage(id: number, File: ReturnedImage) {
    console.log('Updating Image');
    // return this.http.put(this.baseUrl + 'users/' + id, File);
  }

  uploadImage(id: number, returnedimage: ReturnedImage) {
    console.log('uploading image');
    // return this.http.put(this.baseUrl + 'user/' + id, returnedimage);
  }


}
