import { Component } from '@angular/core';
import { CadServico } from './models/CadServico';
import { ServicesService } from './services/services.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']

  
})

export class AppComponent {
  title = 'Controle_de_costura';
  servico : CadServico[] = [];
  novoServico?: CadServico;

  constructor(private cadServicoService: ServicesService ){}

  ngOnInit(): void{
    this.cadServicoService.getServicos().subscribe((result:CadServico[])=>(this.servico = result));
  }

  initNewServico(){
    this.novoServico = new CadServico();
  }


}
