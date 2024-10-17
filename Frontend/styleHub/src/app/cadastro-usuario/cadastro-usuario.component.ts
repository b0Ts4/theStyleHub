import { Component } from '@angular/core';
import { ProductService } from '../services/product.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-cadastro-usuario',
  templateUrl: './cadastro-usuario.component.html',
  styles: ``
})
export class CadastroUsuarioComponent {
  constructor(private ProductService: ProductService, private toastr: ToastrService){}


  
}
