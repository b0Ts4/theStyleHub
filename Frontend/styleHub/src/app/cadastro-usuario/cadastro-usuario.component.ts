import { Component } from '@angular/core';
import { ProductService } from '../services/product.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { CepApiService } from '../services/cep-api.service';
import { FormGroup, FormBuilder, AbstractControl, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';

@Component({
  selector: 'app-cadastro-usuario',
  templateUrl: './cadastro-usuario.component.html',
  styleUrls: ['./cadastro-usuario.component.css']
})
export class CadastroUsuarioComponent {

  formulario: FormGroup;
  formSubmitted: boolean = false;
  searchQuery: string = '';
  validator: number = 0;

  constructor(
    private ProductService: ProductService,
    private toastr: ToastrService, 
    private router: Router, 
    private fb: FormBuilder ,
    private cepApiService: CepApiService
  ){
    this.formulario = this.fb.group({
      nome: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      senha: ['', [Validators.required, Validators.minLength(6)]],
      confirmaSenha: ['', Validators.required],
      cpf: ['', [Validators.required, Validators.minLength(11), Validators.maxLength(11)]],
      cep: ['', Validators.required],
      estado: ['', Validators.required],
      cidade: ['', Validators.required],
      logradouro: ['', Validators.required],
      bairro: ['', Validators.required],
      complemento: ['']
  },  { validators: this.senhaIgualValidator });
  }
  
  senhaIgualValidator(formGroup: AbstractControl): ValidationErrors | null {
    const senha = formGroup.get('senha')?.value;
    const confirmaSenha = formGroup.get('confirmaSenha')?.value;
    return senha === confirmaSenha ? null : { senhasNaoCorrespondem: true };
  }

  verificarErroSenhas(): boolean {
    const confirmaSenhaField = this.formulario.get('confirmaSenha');

    const senhasNaoCorrespondem = this.formulario.hasError('senhasNaoCorrespondem') && (confirmaSenhaField?.touched || false);
    const senhaIncorreta = (confirmaSenhaField?.invalid || false) && (confirmaSenhaField?.touched || false);
    if (senhasNaoCorrespondem && this.validator==0) {
      this.toastr.error("Senhas não são semelhantes!", "Senha");
      this.validator = 1;
    }

    
    return senhasNaoCorrespondem || senhaIncorreta;
  }


  onCepChange() {
    console.log("Dados form: ", this.formulario.value);
    console.log("Input CEP saiu do foco");
    const cep = this.formulario.get('cep')?.value;
    if (cep && cep.length === 8) {
      this.cepApiService.buscarCEP(cep).subscribe(dados => {
        if (dados) {
          console.log( "Dados via CEP: ", dados );
          this.formulario.patchValue({
            logradouro: dados.logradouro,
            bairro: dados.bairro,
            cidade: dados.localidade,
            estado: dados.uf
          });
        }
      }, err => {
        console.error('Erro ao buscar CEP', err);
      });
  }
}


  onSubmit() {
    const cep = this.formulario.get('cep')?.value;
    const logradouro = this.formulario.get('logradouro')?.value;
    const bairro = this.formulario.get('bairro')?.value;
    const cidade = this.formulario.get('cidade')?.value;
    const estado = this.formulario.get('estado')?.value;
    const complemento = this.formulario.get('complemento')?.value;
    const endereco = `${logradouro}, ${complemento} - ${bairro}, ${cidade} - ${estado}, ${cep}`;
    
    const userData = {
      cpf: this.formulario.get('cpf')?.value,
      nome: this.formulario.get('nome')?.value,
      endereco: endereco,
      email: this.formulario.get('email')?.value,
      hash_senha: this.formulario.get('senha')?.value, 
      carrinho: [],
      wishlist: [],
      avaliacoes: [],
      pedidos: []
    }

    this.formSubmitted = true;
    if (this.formulario.invalid) {
      this.toastr.error('Preencha todos os campos obrigatórios corretamente!', 'Erro no cadastro');
    }
      
    this.ProductService.addUser(userData).subscribe(response => {
      console.log("Usuário cadastrado com sucesso!", response);
      this.toastr.success("Cadastro realizado com sucesso", "Cadastro");
      this.router.navigate(['/home']);
    }, error => {
      console.log("Erro ao cadastrar usuário", error);
      this.toastr.error("Verifique se você preencheu os dados corretamente", "Erro no cadastro")
    })
  }

  isFieldInvalid(field: string): boolean {
    const control = this.formulario.get(field);
    return (control?.invalid && (control?.touched || this.formSubmitted)) || false;
  }

  onSearch() {
    this.router.navigate(["search"], {queryParams: { nome: this.searchQuery} })
  }

  
}

