import { Component, OnInit } from '@angular/core';
import { CadServico } from '../models/CadServico';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ServicesService } from '../services/services.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-servico',
  templateUrl: './servico.component.html',
  styleUrls: ['./servico.component.css']
})
export class ServicoComponent implements OnInit{
  public servicoForm: FormGroup;
  titulo = 'Serviços';
  public servicoSelecionado: CadServico;
  public mostrarBotaoEditar: boolean = false;

 //servicos:CadServico[] = []
 servicos$ = new Observable<CadServico[]>();
  

  constructor( private services :ServicesService ){
    this.obterServicos();
  }

  ngOnInit(): void {
    
  }

  obterServicos(){
    this.servicos$ = this.services.getServicos();
  }


  voltar(){
    this.servicoSelecionado = null;
  }

}