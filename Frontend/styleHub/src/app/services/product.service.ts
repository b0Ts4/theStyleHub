import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private apiUrl = environment.apiUrl;  

  constructor(private http: HttpClient) {}

  addProduct(productData: any): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    return this.http.post<any>(this.apiUrl + "Produtos", productData);
  }

  getProdutos(): Observable<any> {
    return this.http.get<any>(this.apiUrl + "Produtos");
  } 

}
