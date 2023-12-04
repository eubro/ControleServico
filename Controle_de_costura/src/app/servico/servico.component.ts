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
  public mostrarBotaoEditar: boolean = true;

 //servicos:CadServico[] = []
 servicos$ = new Observable<CadServico[]>();
  

  constructor( private services :ServicesService, private fb: FormBuilder  ){
    this.obterServicos();
    this.criarForm();
  }

  ngOnInit(): void {
    
  }

  obterServicos(){
    this.servicos$ = this.services.getServicos();

  }

  criarForm(){
    this.servicoForm = this.fb.group({
      nome:['', Validators.required],
      valor: ['',Validators.required],
      numero:['',Validators.required],
      descricao:['',Validators.required,]
  });
  }

  selecionarServico(servico: CadServico) {
    this.servicoSelecionado = servico;
    this.mostrarBotaoEditar = true;
    
    this.servicoForm.patchValue({
      nome: servico.nome,
      valor: servico.valor,
      numero: servico.numero,
      descricao: servico.descricao,
    });
  }

  iniciarEdicao(servico: CadServico) {
    this.servicoSelecionado = servico;
    this.mostrarBotaoEditar = true;
    this.servicoForm.patchValue({
      nome: servico.nome,
      valor: servico.valor,
      numero: servico.numero,
      descricao: servico.descricao,
    });
  }
  servicoSelect(servico:CadServico){
    this.servicoSelecionado = servico;
    this.servicoForm.patchValue(servico);
    this.mostrarBotaoEditar = false;
  }

  atualizarServico() {
    // Atualizar os dados do serviço selecionado com os valores do formulário
    this.servicoSelecionado.nome = this.servicoForm.value.nome;
    this.servicoSelecionado.valor = this.servicoForm.value.valor;
    this.servicoSelecionado.numero = this.servicoForm.value.numero;
    this.servicoSelecionado.descricao = this.servicoForm.value.descricao;

    // Chamar o método de edição no serviço
    this.services.editServico(this.servicoSelecionado).subscribe(() => {
      // Atualizar a lista de serviços após a edição
      this.obterServicos();
      // Limpar o formulário e redefinir a seleção
      this.servicoForm.reset();
      this.servicoSelecionado = null;
      this.mostrarBotaoEditar = true;
    });
  }
  excluirServico(servico: CadServico) {
    if (servico) {
      this.services.removerServico(servico.id).subscribe(() => {
        this.obterServicos();
      });
    }
  }

  marcarComoConcluido(servico: CadServico) {
    if (servico) {
        // Alterar o estado concluído no objeto localmente
        servico.concluido = true;

        // Chamar o método no serviço para atualizar o estado no backend
        this.services.marcarComoConcluido(servico.id).subscribe(() => {
            // Atualizar a lista de serviços após a conclusão
            this.obterServicos();
        });
    }
}
  

  
  
  
}