import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CadServico } from '../models/CadServico';
import { ServicesService } from '../services/services.service';

@Component({
  selector: 'app-novo-servico',
  templateUrl: './novo-servico.component.html',
  styleUrls: ['./novo-servico.component.css']
})
export class NovoServicoComponent implements OnInit {
  @Input() servico?: CadServico;
  @Output() servicosUpdated = new EventEmitter<CadServico[]>();

  constructor(private service: ServicesService){}

  ngOnInit(): void {
      
  }

  createServico(servico: CadServico) {
    this.service
      .addServicos(servico)
      ;
  }

}
