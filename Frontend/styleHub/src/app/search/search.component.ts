import { Component } from '@angular/core';
import { ProductService } from '../services/product.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css'] 
})
export class SearchComponent {
  constructor(private ProductService: ProductService, private route: ActivatedRoute, private router: Router){}
  searchQuery: string = '';
  dados: any = [];

  onSearch() {
    this.router.navigate(["search"], {queryParams: { nome: this.searchQuery} })
  }

  ngOnInit(): void{

    this.route.queryParams.subscribe(params => {
    this.searchQuery = params['nome'];

    this.ProductService.getProdutos(this.searchQuery).subscribe(
      (response) => {
        console.log(response);
        this.dados = response.$values;
      },
      (error) => {
        console.error('Erro ao receber dados', error);
      }
    )
  }
)
  }
}
