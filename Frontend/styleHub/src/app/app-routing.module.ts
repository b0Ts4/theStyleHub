import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastroProdutosComponent } from './cadastro-produtos/cadastro-produtos.component';
import { HomeComponent } from './home/home.component';
import { SearchComponent } from './search/search.component';
import { ProdutoComponent } from './produto/produto.component';

const routes: Routes = [
  { path: 'cadastro-produtos', component: CadastroProdutosComponent },
  { path: 'home', component: HomeComponent},
  {path: 'search', component: SearchComponent},
  {path: 'produto/:id', component: ProdutoComponent},
  {path: '', component: HomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
