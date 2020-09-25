import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cliente } from "./cliente"
import { Endereco } from './endereco';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  constructor(private http: HttpClient) {}
  
  protected UrlService: string = "https://localhost:44389/";

  salvarCadastro(cliente : Cliente) : Observable<Object> {
    console.log(cliente);
    return this.http.post(this.UrlService + "api/cliente/gravar", cliente);    
  }

  obterPorClienteId(id : string) : Observable<Cliente> {
    return this.http.get<Cliente>(this.UrlService + "api/cliente/" + id);
  }

  obterTodos() : Observable<Cliente[]> {
    // return this.http.get<Cliente[]>("http://localhost:3000/clientes"); 
    return this.http.get<Cliente[]>(this.UrlService + "api/cliente/obterTodos"); 
  }

  excluirCliente(id: string) {
    return this.http.post(this.UrlService + "api/cliente/excluir", { "Id" : id.trim() });
  }

  buscarCep(cep: string) : Observable<Endereco>{
    return this.http.get<Endereco>(this.UrlService + "api/cep/" + cep);
  }
}
