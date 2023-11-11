import { Component, EventEmitter, Input, OnInit, Output, NgZone } from '@angular/core';
import { CadServico } from '../models/CadServico';
import { ServicesService } from '../services/services.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-novo-servico',
  templateUrl: './novo-servico.component.html',
  styleUrls: ['./novo-servico.component.css']
})
export class NovoServicoComponent implements OnInit {
  @Output() servico: CadServico = new CadServico();
  formSubmitted: boolean = false;

  constructor(private service: ServicesService, private zone: NgZone){}

  ngOnInit(): void {
    this.servico = new CadServico();
      
  }

  createServico(form: NgForm) {
    this.formSubmitted = true;

    if (form.valid) {
      this.service.addServicos(this.servico).subscribe(
        () => {
          alert('Serviço adicionado com sucesso!');
        },
        (error) => {
          console.error('Erro ao adicionar serviço:', error);
        }
      );
    }
  }
}

