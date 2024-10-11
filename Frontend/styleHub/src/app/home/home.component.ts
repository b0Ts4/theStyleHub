import { AfterViewInit, Component } from '@angular/core';
import { ProductService } from '../services/product.service';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment.development';
declare var $: any;

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  constructor(private ProductService: ProductService, private router: Router){}
  
  dados: any = [];
  searchQuery: string = '';


  onSearch() {
    this.router.navigate(["search"], {queryParams: { nome: this.searchQuery} })
  }
  
  ngOnInit(): void{
    this.ProductService.getProdutos().subscribe(
      (response) => {
        console.log(response);
        this.dados = response.$values;
        this.initSlickCarousel();
      },
      (error) => {
        console.error('Erro ao receber dados', error);
      }
    )
  }
  
  initSlickCarousel() {
    if (this.dados.length > 0) {
      setTimeout(() => { 
        $('.products-row').slick({
          infinite: true,
          slidesToShow: 4,  
          slidesToScroll: 1, 
          arrows: false,      
          dots: true,
          responsive: [
            {
              breakpoint: 1024,
              settings: {
                slidesToShow: 3,
                slidesToScroll: 1,
                infinite: true,
                dots: true
              }
            },
            {
              breakpoint: 600,
              settings: {
                slidesToShow: 2,
                slidesToScroll: 1
              }
            },
            {
              breakpoint: 480,
              settings: {
                slidesToShow: 1,
                slidesToScroll: 1
              }
            }
          ]
        });
      }, 0); // Tempo para garantir que os dados e o DOM estejam prontos
    }
  }


}
