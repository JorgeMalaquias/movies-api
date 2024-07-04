## Requisitos para rodar a aplicação

### .Net 8.0

### .Sql Server (preferencialmente última versão)

## Antes de rodar a aplicação

1. Rode o Sql Server, seja localmente ou via docker por exemplo, crie nele um banco de dados. É sugerido que o nome seja movies_api. Caso opte por outro deverá mudar o valor de Initial Catalog na connection string da propriedade "DefaultConnection" no arquivo appsettings.json.
2. Se você disponibilizar o sql server em uma porta diferente da usual (1433) e/ou não estiver acessando o banco como SA, deve atualizar a connection string já citada com sua senha e usuário. Também insira a senha do seu banco de dados na mesma connection string.
3. Após isso, execute o comando

```
dotnet ef database update

```

Esse comando criará as tabelas no banco de dados.

4. Finalmente, rode a aplicação com

```
dotnet run

```

ou

```
dotnet watch run

```

OBS: os passos 3 e 4 citados são para Linux. Para rodar em outro SO, consultar como rodar uma aplicação dotnet nestes ambientes.
