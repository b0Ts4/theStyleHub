import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  addProduct(productData: any): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });

    return this.http.post<any>(this.apiUrl + 'Produtos', productData);
  }

  getProdutos(
    nome?: string,
    genero?: string[],
    categoria?: string[],
    cor?: string[]
  ): Observable<any> {
    let params = new HttpParams();

    if (nome) {
      params = params.append('nome', nome);
    }

    if (cor && cor.length > 0) {
      cor.forEach((cores) => {
        params = params.append('cor', cores);
      });
    }

    if (genero && genero.length > 0) {
      genero.forEach((gen) => {
        params = params.append('genero', gen);
      });
    }

    if (categoria && categoria.length > 0) {
      categoria.forEach((cat) => {
        params = params.append('categoria', cat);
      });
    }

    return this.http.get<any[]>(this.apiUrl + 'Produtos', { params });
  }

  getUmProduto(id: number) {
    return this.http.get<any>(this.apiUrl + `Produtos/${id}`);
  }

  addCart(userId: number, productId: number) {
    const params = new HttpParams()
      .set('userId', userId)
      .set('productId', productId);

    console.log('Parametros recebidos pela url', params.toString());

    return this.http.post<any>(`${this.apiUrl}ItensCarrinhoes`, null, {
      params,
    });
  }

  addWishlist(idProduto: number, idUser: number) {
    let params = new HttpParams();

    params = params.append('idProduto', idProduto);
    params = params.append('idUser', idUser);

    return this.http.put<any>(this.apiUrl + 'Produtos/addWishlist', { params });
  }
}
