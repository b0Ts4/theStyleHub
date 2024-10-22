import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent {
  userData: any;
  dados: any;
  searchQuery: any;

  constructor(private authService: AuthService, private userService: UserService, private router: Router) {}

  loadUserData() {
    this.userData = this.authService.getUserDataFromToken();
    console.log(this.userData);
  }

  ngOnInit() {
    this.loadUserData();
    const email = this.userData.email;

    this.userService.getUsuario(email).subscribe(
      (response) => {
        console.log("Dados usuario", response);
        this.dados = response;
      }, (err) => {
        console.log("Erro ao carregar dados do cliente", err);
      }
    )
  }

  onSearch() {
    this.router.navigate(["search"], {queryParams: { nome: this.searchQuery} })
  }







}
