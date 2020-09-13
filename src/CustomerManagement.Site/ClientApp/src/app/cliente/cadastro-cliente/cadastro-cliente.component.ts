import { Component, OnInit } from '@angular/core';
import { Cliente } from '../cliente';
import { ClienteService } from '../cliente.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-cadastro-cliente',
  templateUrl: './cadastro-cliente.component.html',
})
export class CadastroClienteComponent implements OnInit {
  
  constructor(private route: ActivatedRoute, private service: ClienteService) { }

  public cliente: Cliente = new Cliente;

  ngOnInit() : void {
    const idCliente = this.route.snapshot.paramMap.get('id');
    this.service.obterPorIdCliente(idCliente)
    .subscribe(
      retorno => {
        this.cliente = retorno;
        console.log(retorno);
      },
      error => console.log(error)
    )
  }

}
