import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-carrinho',
  templateUrl: './carrinho.component.html',
  styleUrls: ['./carrinho.component.css'],
})
export class CarrinhoComponent {
  constructor(
    private ProductService: ProductService,
    private router: Router,
    private authService: AuthService
  ) {}

  searchQuery: string = '';

  onSearch() {
    this.router.navigate(['search'], {
      queryParams: { nome: this.searchQuery },
    });
  }
}
