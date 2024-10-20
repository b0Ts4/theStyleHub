import { Component } from '@angular/core';
import { ProductService } from '../services/product.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css'] 
})
export class SearchComponent {
  constructor(
    private ProductService: ProductService, 
    private route: ActivatedRoute, 
    private router: Router,
    private authService: AuthService
  ){}
  searchQuery: string = '';
  dados: any = [];
  activePanel: string = '';  
  panelHeight: string = '200px';

  filterQuery: any = {
    genero: [],
    categoria: [],
    cor: []
  };
  onSearch() {
    this.router.navigate(["search"], {queryParams: { nome: this.searchQuery} })
  }

  toggleAccordion(panel: string): void {
    if (this.activePanel === panel) {
      this.activePanel = '';  
    } else {
      this.activePanel = panel;
    }
  }

  onColorChange(cor: string, event: any): void {
    const isChecked = event?.target.checked;
    
    if (isChecked) {
      this.filterQuery.cor.push(cor);
    } else {
      const index = this.filterQuery.cor.indexOf(cor);
      if (index > -1) {
        this.filterQuery.cor.splice(index, 1);
      }
    }
  }

  onCategoriaChange(categoria: string, event: any): void {
    const isChecked = event?.target.checked;
    
    if (isChecked) {
      this.filterQuery.categoria.push(categoria);
    } else {
      const index = this.filterQuery.categoria.indexOf(categoria);
      if (index > -1) {
        this.filterQuery.categoria.splice(index, 1);
      }
    }
  }

  onGeneroChange(genero: string, event: any): void {
    const isChecked = event?.target.checked;
    
    if (isChecked) {
      this.filterQuery.genero.push(genero);
    } else {
      const index = this.filterQuery.genero.indexOf(genero);
      if (index > -1) {
        this.filterQuery.genero.splice(index, 1);
      }
    }
  }
  
  onFilter() {

    const queryParams = {
      nome: this.searchQuery || null,  
      genero: this.filterQuery.genero.length > 0 ? this.filterQuery.genero : null,  
      categoria: this.filterQuery.categoria.length > 0 ? this.filterQuery.categoria : null,  
      cor: this.filterQuery.cor.length > 0 ? this.filterQuery.cor : null
    };

    this.router.navigate([], {
      relativeTo: this.route,
      queryParams: queryParams,
      queryParamsHandling: ''
    });
  }

  verifyToken(): boolean{
    if(!this.authService.getToken()){
      console.log("token nao ta aqui");
      return false;
    }
    console.log("token ta aqui");
    //this.authService.logout();
    return true;
  }

  ngOnInit(): void{

    this.route.queryParams.subscribe(params => {
    this.searchQuery = params['nome'];
    this.filterQuery.genero = params['genero'] ? [].concat(params['genero']) : [];
      this.filterQuery.categoria = params['categoria'] ? [].concat(params['categoria']) : [];
      this.filterQuery.cor = params['cor'] ? [].concat(params['cor']) : [];


    this.ProductService.getProdutos(
      this.searchQuery,
      this.filterQuery.genero,
      this.filterQuery.categoria,
      this.filterQuery.cor
    ).subscribe(
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
