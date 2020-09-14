import { Endereco } from "./endereco";

export class Cliente {
    id: string;
    nome: string;
    sobrenome: string;
    dataNascimento : string;
    tipoSexo: string;
    email: string;
    telefone: string;
    endereco: Endereco;
  }