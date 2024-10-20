import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
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

  constructor(private router: Router, private authService: AuthService, private fb: FormBuilder, private toastr: ToastrService){
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

    this.authService.login(loginData).subscribe(response => {
      console.log("Usuario logado com sucesso", response);

      if (response.token) {
        this.authService.saveToken(response.token);  
        this.router.navigate(['/pagina-protegida']); 
      } else {
        console.error('Token JWT não encontrado na resposta');
      }

      this.router.navigate(['/home']);
    }, err => {
      console.log("Erro ao fazer login", err);
      this.toastr.error("Email ou senha incorretos", "Erro ao fazer login");
    })
  }
  
}
