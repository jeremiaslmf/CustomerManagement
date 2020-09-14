import { Component, OnInit } from '@angular/core';
import { Cliente } from '../cliente';
import { ClienteService } from '../cliente.service';
import { ActivatedRoute } from '@angular/router';
import { Endereco } from '../endereco';
import { Sexo } from '../sexo';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-cadastro-cliente',
  templateUrl: './cadastro-cliente.component.html',
})
export class CadastroClienteComponent implements OnInit {
  
  constructor(private route: ActivatedRoute, private clienteService: ClienteService) { }

  public cliente: Cliente = new Cliente;
  public endereco: Endereco = new Endereco;
  public sexo: Sexo = new Sexo;

  ngOnInit() : void {
    const clienteId = this.route.snapshot.paramMap.get('id');
    this.clienteService.obterPorClienteId(clienteId)
      .subscribe(
        retorno => {
          this.cliente = retorno;
          this.endereco = this.cliente.endereco;
          this.sexo.selectedValue = this.cliente.tipoSexo;
        },
        error => console.log(error)
      )
  }

  salvarCadastro(){
    this.cliente.endereco = this.endereco;
    console.log(this.cliente);
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
}
