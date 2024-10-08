import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private apiUrl = 'http://localhost:5255/api/';  // Defina aqui a URL da sua API backend

  constructor(private http: HttpClient) { }

  // Método para buscar usuários da API
  getUsuarios(): Observable<any> {
    return this.http.get(this.apiUrl + "Usuarios");
  }
}
