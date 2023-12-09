import {  NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ServicoComponent } from './servico/servico.component';
import { NovoServicoComponent } from './novo-servico/novo-servico.component';
import { ServicoConcluidoComponent } from './servico-concluido/servico-concluido.component';



const routes: Routes = [
  {path: 'servico', component: ServicoComponent},
  {path: 'novo-servico', component: NovoServicoComponent},
  {path: 'concluido', component: ServicoConcluidoComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
