import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { CadastroProdutosComponent } from './cadastro-produtos/cadastro-produtos.component';
import { ProductService } from './services/product.service';
import { AppRoutingModule } from './app-routing.module';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ToastrModule } from 'ngx-toastr';
import { HomeComponent } from './home/home.component';
import { SearchComponent } from './search/search.component';
import { ProdutoComponent } from './produto/produto.component';
import { LoginComponent } from './login/login.component';
import { CadastroUsuarioComponent } from './cadastro-usuario/cadastro-usuario.component';
import { ProfileComponent } from './profile/profile.component';
import { CarrinhoComponent } from './carrinho/carrinho.component';


@NgModule({
  declarations: [
    AppComponent,
    CadastroProdutosComponent,
    HomeComponent,
    SearchComponent,
    ProdutoComponent,
    LoginComponent,
    CadastroUsuarioComponent,
    ProfileComponent,
    CarrinhoComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    RouterModule,
    CommonModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    ToastrModule.forRoot()
  ],
  providers: [ProductService],
  bootstrap: [AppComponent]
})
export class AppModule { }