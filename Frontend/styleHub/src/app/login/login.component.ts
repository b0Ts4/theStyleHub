import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../services/user.service';
import { FormGroup, FormBuilder, AbstractControl, ValidationErrors, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {


  formulario: FormGroup;
  searchQuery: string ='';

  constructor(private router: Router, private userService: UserService, private fb: FormBuilder, private toastr: ToastrService){
    this.formulario = this.fb.group({
      email: [''],
      senha: ['']
    })
  }

  
  onSubmit() {
    const loginData = {
      email: this.formulario.get('email')?.value,
      senha: this.formulario.get('senha')?.value
    }

    this.userService.login(loginData).subscribe(response => {
      console.log("Usuario logado com sucesso");
      this.router.navigate(['/home']);
    }, err => {
      console.log("Erro ao fazer login", err);
      this.toastr.error("Email ou senha incorretos", "Erro ao fazer login");
    })
  }

  onSearch() {
    this.router.navigate(["search"], {queryParams: { nome: this.searchQuery} })
  }

  
}
