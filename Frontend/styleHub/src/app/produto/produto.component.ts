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
  mediaAvaliacao: number = 0;

  constructor(private ProductService: ProductService, private route: ActivatedRoute, private router: Router){
    
  }

  ngOnInit(): void{
    this.produtoId = Number(this.route.snapshot.paramMap.get('id'));

    this.ProductService.getUmProduto(this.produtoId).subscribe({
      next: (data) => {
        this.produto = data;
        this.mediaAvaliacoes();
        console.log( 'Produto:', this.produto );
      },
      error: (err) => {
        console.error('Erro ao carregar produto', err);
      }
    })
  }

  mediaAvaliacoes() {
    if(this.produto.avaliacoes.$values.length > 0){
      var i: number;
      var valorTotal: number = 0;
      for(i = 0; i < this.produto.avaliacoes.$values.length; i++){
        valorTotal += this.produto.avaliacoes.$values[i].nota;
      }
      this.mediaAvaliacao = valorTotal/i;
    } else{
      this.mediaAvaliacao = 0;
    }

    console.log("Media das avaliacoes: ", this.mediaAvaliacao);
  }

  onSearch() {
    this.router.navigate(["search"], {queryParams: { nome: this.searchQuery} })
  }

}
