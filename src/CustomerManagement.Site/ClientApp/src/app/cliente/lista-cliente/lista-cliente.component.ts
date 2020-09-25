import { Component, OnInit } from '@angular/core';
import { Cliente } from "../cliente";
import { ClienteService } from '../cliente.service';

@Component({
  selector: 'app-lista-cliente',
  templateUrl: './lista-cliente.component.html'
})
export class ListaClienteComponent implements OnInit {
  public clientes: Cliente[];

  constructor(private clienteService : ClienteService) { }

  ngOnInit(): void {
    this.clienteService.getAll()
      .subscribe(
        retorno => {
          this.clientes = retorno;
          console.log(retorno);
        },
        error => console.log(error)
      )
  }

  excluirCliente(id : string){
    if (!confirm("Confirmar exclusão ?")){
      return;
    }

    this.clienteService.delete(id)
    .subscribe(
      retorno => {
        this.clientes = this.clientes.filter(x => x.id != id);
      },
      error => {
        alert(":( Por algum motivo, o cliente não pode ser excluído!");
        console.log(error);
      } 
    )
  }
}
