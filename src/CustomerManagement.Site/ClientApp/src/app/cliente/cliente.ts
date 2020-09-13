import { Endereco } from "./endereco";

export class Cliente {
    id: string;
    nome: string;
    sobreNome: string;
    dataNascimento : Date;
    tipoSexo: string;
    email: string;
    telefone: string;
    Enderecos: Endereco[];
  }