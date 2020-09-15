# CustomerManagement
Aplicação criada com o objetivo de atender um cenário fictício de execução das rotinas básicas de um cadastro de cliente (CRUD), inicialmente com dois componentes, sendo eles cadastro e listagem.
O cadastro possui integração com WebService de ceps ViaCEP (https://viacep.com.br/ws) realizando a consulta e retornando o endereço caso o cep seja válido;

--> Para acessar os requisitos solicitados para o teste, acesse o diretório raiz/docs/testData.txt

### Tech

* [ASP.NET Core] 3.1
* [MySql] 8.0.21 (root provider)
* [Sqlite] Core 3.1.8 (provider utilizado para execução de testes automatizados 'inmemory')
* [Entity Framework Core] para MySql 3.1.8
* [Angular] 8
* [TinyMapper] 3.0.3
* [Fluent Validation] Core 9.2.0
* [MSTest] 2.1 
* [Bogus] 31.0.2 (fake data - https://github.com/bchavez/Bogus)

### Installation
Requisitos necessários:

* SDK .NET Core 3.1;
* MySql 5.7 ou superior.
* Node.JS 10 ou superior;
* DotNet CLI

### Start

Excecutar o seguinte comando na raiz:

```sh
$ dotnet run --project .\src\CustomerManagement.Site\ --urls=https://localhost:44389/
```
- Compatível com IDEs VSCode e VisualStudio 2019
