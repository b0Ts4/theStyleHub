import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  addUser(userData: any) {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
  
   return this.http.post<any>(this.apiUrl + "Usuarios", userData);
  }

  getUsuario(email: string) {
    return this.http.get<any>(this.apiUrl + "Usuarios/" + email);
  }

}
