import { Component, OnInit } from '@angular/core';
import { CadServico } from '../models/CadServico';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

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


  public servicos= [
    {id:1, nome: 'Jô', descricao: 'feito uma blusa e uma jaqueta'     ,valor:20, data:this.formatarData(new Date()),numero:'99949512'},
    {id:2, nome: 'Talita', descricao: 'feito uma blusa e uma jaqueta' ,valor:20, data:this.formatarData(new Date()),numero:'99949513'},
    {id:3, nome: 'Nathi', descricao: 'feito uma blusa e uma jaqueta'  ,valor:20, data:this.formatarData(new Date()),numero:'99949514'},
    {id:4, nome: 'Hericles', descricao:'feito uma blusa e uma jaqueta',valor:20, data:this.formatarData(new Date()),numero:'99949515'},
    {id:5, nome: 'Heraldo', descricao: 'feito uma blusa e uma jaqueta',valor:20, data:this.formatarData(new Date()),numero:'99949516'},
  ];

  constructor( private fb: FormBuilder){
    this.criarForm();
  }

  ngOnInit(): void {
    
  }

  criarForm(){
    this.servicoForm = this.fb.group({
      nome:['', Validators.required],
      valor: ['',Validators.required],
      numero:['',Validators.required],
      descricao:['',Validators.required,]
  });
  }
  servicoEdit(){
    //this.servicoForm.value;
    this.servicoForm.patchValue(CadServico);
    
    
  }
  Edit(servico: CadServico) {
    this.servicoSelecionado = servico;
    this.servicoForm.patchValue(servico);
    this.mostrarBotaoEditar = false; 
    
  }
  

  servicoSelect(servico:CadServico){
    this.servicoSelecionado = servico;
    this.servicoForm.patchValue(servico);
    this.mostrarBotaoEditar = true;
  }
  voltar(){
    this.servicoSelecionado = null;
  }
  excluir(servico: CadServico): void {
    const index = this.servicos.findIndex(s => s.id === servico.id);
    if (index !== -1) {
      this.servicos.splice(index, 1);
    }
    
    if (this.servicoSelecionado && this.servicoSelecionado.id === servico.id) {
      this.servicoSelecionado = null;
    }
  }
  

  formatarData(data: Date): string {
    return data.toLocaleDateString('pt-BR'); 
  }

}