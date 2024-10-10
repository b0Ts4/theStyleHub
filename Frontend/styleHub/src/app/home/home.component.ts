import { AfterViewInit, Component } from '@angular/core';
import { ProductService } from '../services/product.service';
declare var $: any;

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  constructor(private ProductService: ProductService){}
  
  dados: any = [];
  
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
      setTimeout(() => { // Garantir que o DOM foi atualizado
        $('.products-row').slick({
          infinite: true,
          slidesToShow: 4,  /* Número de produtos visíveis ao mesmo tempo */
          slidesToScroll: 1, /* Número de produtos movidos por vez */
          arrows: false,      /* Mostra setas de navegação */
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
