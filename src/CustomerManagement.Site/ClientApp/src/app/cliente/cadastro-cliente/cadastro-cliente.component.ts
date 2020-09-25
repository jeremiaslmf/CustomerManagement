import { Component, OnInit } from '@angular/core';
import { Cliente } from '../cliente';
import { ClienteService } from '../cliente.service';
import { ActivatedRoute } from '@angular/router';
import { Endereco } from '../endereco';
import { HttpErrorResponse } from '@angular/common/http';
import { PipeFormatDate } from 'src/app/app.component';
import { stringify } from 'querystring';

@Component({
  selector: 'app-cadastro-cliente',
  templateUrl: './cadastro-cliente.component.html',
})
export class CadastroClienteComponent implements OnInit {
  
  public mensagemSucesso: string = ":) Operação realizada com sucesso!";
  public mensagemErro: string = ":( Houve algum problema ao executar a operação!";
  
  isCadastroNovo: boolean = false;
  cliente: Cliente = new Cliente;
  endereco: Endereco = new Endereco;
  tiposSexo = [
    "Masculino",
    "Feminino",
    "Outro"
  ];
  dataNascimento: string;
  
  constructor(private route: ActivatedRoute, private clienteService: ClienteService, private pipeFormatDate: PipeFormatDate) { }

  ngOnInit() : void {
    const clienteId = this.route.snapshot.paramMap.get('id');
    this.isCadastroNovo = clienteId == null;
    if (clienteId == null){
      return;
    }
    
    this.clienteService.getById(clienteId)
    this.clienteService.getById(clienteId)
      .subscribe(
        retorno => {
           this.cliente = retorno;
           this.dataNascimento = new Date(retorno.dataNascimento).toLocaleString('pt').substring(0,10)
           this.endereco = this.cliente.endereco;
        },
        error => console.log(error)
      )
  }

  salvarCadastro(){
    this.cliente.endereco = this.endereco;
    this.cliente.dataNascimento = this.stringToDate(this.dataNascimento, "dd/MM/yyyy", "/");
    
    if (this.isCadastroNovo){
      console.log("Create");
      this.clienteService.create(this.cliente)
        .subscribe(
          () => {
            alert(this.mensagemSucesso);
          },
          (response: HttpErrorResponse) => {
            alert(this.mensagemErro);
          }
        );
    }
    else {
      console.log("Update");
      this.clienteService.update(this.cliente)
        .subscribe(
          () => {
            alert(this.mensagemSucesso);
          },
          (response: HttpErrorResponse) => {
            alert(this.mensagemErro);
          }
        );
    }
    
  }

  buscarCep(cep: string){
    this.clienteService.buscarCep(cep)
      .subscribe(
        retorno => {
          this.endereco.logradouro = retorno.logradouro;
          this.endereco.bairro = retorno.bairro;
          if (retorno.complemento == null){
            this.endereco.complemento = retorno.complemento;
          }
          this.endereco.localidade = retorno.localidade;
          this.endereco.uf = retorno.uf;
        },
        error => console.log(error)
      );
  }

  formatDate(dataNascimento: string){
    this.dataNascimento = this.pipeFormatDate.transform(dataNascimento);
  }

  stringToDate(_date, _format, _delimiter)
  {
    var formatLowerCase=_format.toLowerCase();
    var formatItems=formatLowerCase.split(_delimiter);
    var dateItems=_date.split(_delimiter);
    var monthIndex=formatItems.indexOf("mm");
    var dayIndex=formatItems.indexOf("dd");
    var yearIndex=formatItems.indexOf("yyyy");
    var month=parseInt(dateItems[monthIndex]);
    month-=1;
    var formatedDate = new Date(dateItems[yearIndex],month,dateItems[dayIndex]);
    return formatedDate;
  }
}
