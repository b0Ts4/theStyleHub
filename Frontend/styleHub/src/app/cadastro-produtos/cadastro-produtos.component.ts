import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ProductService } from '../services/product.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-product-create',
  templateUrl: './cadastro-produtos.component.html',
  styleUrls: ['./cadastro-produtos.component.css']
})
export class CadastroProdutosComponent {
  constructor(private ProductService: ProductService, private toastr: ToastrService) {}
  selectedImages: any[] = [];  // Array para armazenar as imagens em base64

  // Captura múltiplas imagens selecionadas e as converte para base64
  onImagesSelected(event: Event) {
    const files = (event.target as HTMLInputElement).files;
    if (files) {
      Array.from(files).forEach(file => {
        const reader = new FileReader();
        reader.onload = () => {
          // Armazenamos a imagem em base64 no array
          this.selectedImages.push({
            fileName: file.name,
            fileType: file.type,
            base64Value: reader.result?.toString().split(',')[1]  // Pega a parte base64
          });
        };
        reader.readAsDataURL(file);  // Converte a imagem para base64
      });
    }
  }

  onSubmit(form: NgForm) {
    if (form.invalid) {
      return;
    }
  
    // Criando um objeto JSON para enviar os dados do produto e as imagens em base64
    const productData = {
      id: 0,
      nome: form.value.nome,
      descricao: form.value.descricao,
      categoria: form.value.categoria,
      cor: form.value.cor,
      genero: form.value.genero,
      valor: form.value.valor,
      promocao: form.value.promocao ? form.value.promocao : 0,
      imagensBase64: this.selectedImages.map(image => image.base64Value),  // Mapeia as imagens base64
      usuariosCarrinho: [],
      usuariosWishlist: [],
      avaliacoes: [],
      imagens: []
    };
  
    // Verifica os dados enviados
    console.log(productData);
  
    this.ProductService.addProduct(productData).subscribe(response => {
      console.log('Produto cadastrado com sucesso!', response);
      this.toastr.success('Realizado com sucesso', 'Cadastro de Produto');
    }, error => {
      console.error('Erro ao cadastrar produto', error);
    });
  }
}