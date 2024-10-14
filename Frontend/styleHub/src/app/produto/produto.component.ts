import { Component, OnInit } from '@angular/core';
import { ProductService } from '../services/product.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-produto',
  templateUrl: './produto.component.html',
  styleUrls: ['./produto.component.css']
})
export class ProdutoComponent {

  produto: any;
  produtoId: any;
  searchQuery: string = '';

  constructor(private ProductService: ProductService, private route: ActivatedRoute, private router: Router){}

  ngOnInit(): void{
    this.produtoId = Number(this.route.snapshot.paramMap.get('id'));

    this.ProductService.getUmProduto(this.produtoId).subscribe({
      next: (data) => {
        this.produto = data;
        console.log( 'Produto:', this.produto );
      },
      error: (err) => {
        console.error('Erro ao carregar produto', err);
      }
    })
  }

  onSearch() {
    this.router.navigate(["search"], {queryParams: { nome: this.searchQuery} })
  }

}
