import {  NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ServicoComponent } from './servico/servico.component';
import { NovoServicoComponent } from './novo-servico/novo-servico.component';
import { ServicoConcluidoComponent } from './servico-concluido/servico-concluido.component';
import { LoginComponent } from './pages/login/login.component';



const routes: Routes = [
  {path: 'login', component:LoginComponent},
  {path:'',redirectTo:'login', pathMatch:'full' },
  {path: 'servico', component: ServicoComponent},
  {path: 'novo-servico', component: NovoServicoComponent},
  {path: 'concluido', component: ServicoConcluidoComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
