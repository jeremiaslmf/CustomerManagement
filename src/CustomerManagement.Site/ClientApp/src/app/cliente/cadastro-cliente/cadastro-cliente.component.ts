import { Component, OnInit } from '@angular/core';
import { Cliente } from '../cliente';
import { ClienteService } from '../cliente.service';
import { ActivatedRoute } from '@angular/router';
import { Endereco } from '../endereco';
import { HttpErrorResponse } from '@angular/common/http';
import { PipeFormatDate } from 'src/app/app.component';

@Component({
  selector: 'app-cadastro-cliente',
  templateUrl: './cadastro-cliente.component.html',
})
export class CadastroClienteComponent implements OnInit {
  
  cliente: Cliente = new Cliente;
  endereco: Endereco = new Endereco;
  tiposSexo = [
    "Masculino",
    "Feminino",
    "Outro"
  ];
  dataNascimento: string;
  selectedValue: string;
  
  constructor(private route: ActivatedRoute, private clienteService: ClienteService, private pipeFormatDate: PipeFormatDate) { }

  ngOnInit() : void {
    const clienteId = this.route.snapshot.paramMap.get('id');
    if (clienteId == null){
      return;
    }
    this.clienteService.obterPorClienteId(clienteId)
      .subscribe(
        retorno => {
           this.cliente = retorno;
           this.dataNascimento = new Date(retorno.dataNascimento).toLocaleString('pt').substring(0,10)
           this.endereco = this.cliente.endereco;
           this.selectedValue = this.cliente.tipoSexo;
           console.log(this.selectedValue);
        },
        error => console.log(error)
      )
  }

  salvarCadastro(){
    this.cliente.endereco = this.endereco;
    this.cliente.dataNascimento = this.stringToDate(this.dataNascimento, "dd/MM/yyyy", "/");
    this.clienteService.salvarCadastro(this.cliente)
    .subscribe(
      () => {
        alert(":) Operação realizada com sucesso!");
      },
      (response: HttpErrorResponse) => {
        alert(":( Houve algum problema ao executar a operação!");
      }
    );
  }

  buscarCep(cep: string){
    this.clienteService.buscarCep(cep)
      .subscribe(
        retorno => {
          this.endereco = retorno;
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
