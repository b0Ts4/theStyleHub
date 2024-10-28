import { Component, OnInit } from '@angular/core';
import { ProductService } from '../services/product.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { UserService } from '../services/user.service';

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
  tokenData: any;
  userData: any;
  userId: any;

  constructor(
    private ProductService: ProductService, 
    private route: ActivatedRoute, 
    private router: Router,
    private authService: AuthService,
    private userService: UserService
  ){}

  addCart() {
    this.tokenData = this.authService.getUserDataFromToken();
    console.log("Dados no token:",this.tokenData);

    const email = this.tokenData.email;
    
    this.userService.getUsuario(email).subscribe(
      (response) => {
          console.log("Dados usuario:", response);
          this.userData = response;

          
          this.ProductService.addCart(this.produto.id, this.userData.clerk_id).subscribe({
              next: (res) => {
                  if (res && res.success) {
                      console.log("Produto adicionado ao carrinho com sucesso.");
                      
                  } else {
                      console.error("Falha ao adicionar produto ao carrinho");
                      
                  }
              },
              error: (err) => {
                  console.error("Erro ao adicionar produto ao carrinho", err);
                  
              }
          });
      },
      (err) => {
          console.error("Erro ao carregar dados do cliente", err);
      }
  );
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

  verifyToken(): boolean{
    if(!this.authService.getToken()){
      console.log("token nao ta aqui");
      return false;
    }
    console.log("token ta aqui");
    //this.authService.logout();
    return true;
  }



  onSearch() {
    this.router.navigate(["search"], {queryParams: { nome: this.searchQuery} })
  }

}
