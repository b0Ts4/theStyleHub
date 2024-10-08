import { Component, OnInit } from '@angular/core';
import { ApiService } from './services/api.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  usuarios: any[] = [];

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.apiService.getUsuarios().subscribe(response => {
      console.log('Dados recebidos da API:', response);
      this.usuarios = response.$values;
    }, error => {
      console.error('Erro ao buscar usuários', error);
    });
  }
}
