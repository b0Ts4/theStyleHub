import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastroProdutosComponent } from './cadastro-produtos/cadastro-produtos.component';
import { HomeComponent } from './home/home.component';
import { SearchComponent } from './search/search.component';
import { ProdutoComponent } from './produto/produto.component';
import { LoginComponent } from './login/login.component';
import { CadastroUsuarioComponent } from './cadastro-usuario/cadastro-usuario.component';
import { ProfileComponent } from './profile/profile.component';

const routes: Routes = [
  { path: 'cadastro-produtos', component: CadastroProdutosComponent },
  { path: 'home', component: HomeComponent},
  {path: 'search', component: SearchComponent},
  {path: 'produto/:id', component: ProdutoComponent},
  {path: '', component: HomeComponent},
  {path: 'login', component: LoginComponent},
  {path: 'cadastro', component: CadastroUsuarioComponent},
  {path: 'perfil', component: ProfileComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
