import { Endereco } from "./endereco";

export class Cliente {
    id: string;
    nome: string;
    sobrenome: string;
    dataNascimento : Date;
    tipoSexo: string;
    email: string;
    telefone: string;
    endereco: Endereco;
  }