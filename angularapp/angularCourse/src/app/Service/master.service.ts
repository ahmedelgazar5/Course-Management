import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class MasterService {

  url: string = '';

  constructor(private http: HttpClient) {
    this.url = environment.UrlBase;
  }
  getAll(base: string): Observable<any> {
    return this.http.get<any>(this.url + base);
  }
  getById(base: string, id: any): Observable<any> {
    return this.http.get<any[]>(this.url + base + '/' + id);
  }

  Update(base: string, id: any, data: any): Observable<any> {
    return this.http.put<any>(this.url + base +'/'+ id, data);
  }
  Add(base: string, data: any): Observable<any> {
    return this.http.post<any>(this.url + base, data);
  }
  Delete(base: string, id: any): Observable<any> {
    return this.http.delete<any>(this.url + base + '/' + id);
  }
}
