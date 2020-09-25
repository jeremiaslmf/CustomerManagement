import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cliente } from "./cliente"
import { Endereco } from './endereco';

var httpOptions = {headers: new HttpHeaders({"Content-Type" : "application/json"})}

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  constructor(private http: HttpClient) {}
  
  protected urlAPI: string = "https://localhost:44389/";
  protected apiCliente: string = this.urlAPI + "api/cliente/";
  protected apiCep: string = this.urlAPI + "api/cep/";

  create(cliente : Cliente) : Observable<Cliente> {
    console.log("passou")
    let retorno = this.http.post<Cliente>(this.apiCliente, cliente, httpOptions);
    console.log(retorno);
    return retorno; 
  }

  update(cliente : Cliente) : Observable<Cliente> {
    return this.http.put<Cliente>(this.apiCliente + cliente.id, cliente, httpOptions);
  }
 
  delete(id: string) : Observable<Object>{
    return this.http.delete<Cliente>(this.apiCliente + id);
  }

  getById(id : string) : Observable<Cliente> {
    return this.http.get<Cliente>(this.apiCliente + id);
  }

  getAll() : Observable<Cliente[]> {
    // return this.http.get<Cliente[]>("http://localhost:3000/clientes"); 
    return this.http.get<Cliente[]>(this.apiCliente); 
  }

  buscarCep(cep: string) : Observable<Endereco>{
    return this.http.get<Endereco>(this.apiCep + cep);
  }
}
