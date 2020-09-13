import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cliente } from "./cliente"

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  constructor(private http: HttpClient) {}

  // constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  //   http.get<Cliente[]>(baseUrl + 'api/cliente/obterTodos').subscribe(result => {
  //     this.clientes = result;
  //   }, error => console.error(error));
  // }
  
  protected UrlService: string = "http://localhost:44389/";

  salvarCadastro(cliente : Cliente){
    this.http.post(this.UrlService + "api/cliente/gravar", cliente)
  }

  obterPorClienteId(id : string) : Observable<Cliente> {
    return this.http.get<Cliente>(this.UrlService + "api/cliente/" + id);
  }

  obterTodos() : Observable<Cliente[]> {
    return this.http.get<Cliente[]>("http://localhost:3000/clientes"); 
    // return this.http.get<Cliente[]>(this.UrlService + "api/cliente/obterTodos"); 
  }

  excluirCliente(id: string) {
    return this.http.post(this.UrlService + "api/cliente/excluir", { "Id" : id });
  }
}
