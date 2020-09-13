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
    const clienteId = this.route.snapshot.paramMap.get('id');
    this.service.obterPorClienteId(clienteId)
    .subscribe(
      retorno => {
        this.cliente = retorno;
        console.log(retorno);
      },
      error => console.log(error)
    )
  }

}
