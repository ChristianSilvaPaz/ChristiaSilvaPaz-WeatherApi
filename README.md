# WeatherApi

Este projeto trata-se de uma API como parte do teste técnico do processo seletivo para a vaga de .NET Developer JR na Fasters.

# :rocket: Começando

Essas instruções permitirão que você obtenha uma cópia do projeto em operação na sua máquina local para fins de desenvolvimento e teste.

:clipboard: Pré-requisitos

<ul>
  <li> <a href="https://dotnet.microsoft.com/pt-br/download/dotnet/7.0"> .NET 7 ou superior </li>
  <li> <a href="https://www.mysql.com/downloads/"> MySQL 8 ou superior </li>
</ul>

## 1. Obtendo uma cópia e configurando
Abra um terminal e clone este repositório em qualquer diretório da sua máquina (recomendado c:\ no Windows) utilizando o comando: git clone https://github.com/ChristianSilvaPaz/ChristianSilvaPaz-WeatherApi.git

Acesse o diretório do projeto em: WeatherApi/WeatherApi.API

Localize e abra o arquivo de configuração: appsettings.Development.json

Altere a seção ConnectionStrings com as informações de conexão com o MySqlWorkbench:

"ConnectionStrings": {
"DefaultConnection": "Server=localhost;Database=weather_database;Uid=root;Pwd=;AllowZeroDateTime=true"
}

## 2. Preparando o banco de dados
O projeto está configurado para usar um banco de dados MySql. Verifique se a cadeia de conexão DefaultConnection em appsettings.json aponta para uma instância válida do MySql.
Abaixo está o código para criação da tabela que o projeto utiliza:

<img width="230" alt="Captura de tela 2023-10-11 162012" src="https://github.com/ChristianSilvaPaz/ChristiaSilvaPaz-WeatherApi/assets/62564760/7e3fd2db-fb50-4b6c-b16c-adfe7d0a9ac3">

## 3. Subindo o Backend
Observação: os passos abaixo foram realizados utilizando um ambiente de desenvolvimento integrado como o Microsoft Visual Studio, basta abrir a solução WeatherApi.sln que está na pasta src e executar o projeto WeatherApi.API
Abra a aba Gerenciador de Testes do Visual Studio para executar os testes, ou se preferir, no terminal: 

Acesse a pasta do código fonte do projeto com:
```
cd ChristianSilvaPaz-WeatherApi
```
Restaure as dependências:
```
donet restore
```
Compile utilizando:
```
donet build
```
Rode os testes de unidade (caso queira):
```
dotnet test
```
Em seguida rode o servidor:
```
dotnet run --project .\WeatherApi\
```
Após isto, a Web API estará em pleno funcionamento. É possível visualizar a documentação e testar API, essa tela deverá aparecer na aba do seu navegador:
 
<img width="630" alt="Captura de tela 2023-10-12 164058" src="https://github.com/ChristianSilvaPaz/ChristiaSilvaPaz-WeatherApi/assets/62564760/7d7f53f1-2f53-40d2-b059-467839662a3a">

## 4. Utilizando a Api
Para receber dados climáticos de uma cidade, faça uma requisição GET para /api/WeatherCity/ conforme imagem abaixo:
<img width="603" alt="Captura de tela 2023-10-12 173533" src="https://github.com/ChristianSilvaPaz/ChristiaSilvaPaz-WeatherApi/assets/62564760/a58766f7-9455-4185-b523-f86d98585e24">

# :hammer_and_wrench: Construído com:
Ferramentas/tecnologias utilizadas para construção deste projeto

  <ul>
    <li> <a href="https://dotnet.microsoft.com/pt-br/download/dotnet/7.0">.NET 7 - Backend e Web API</li>
    <li> <a href="https://learn.microsoft.com/pt-br/ef/core/">Entity Framework Core - Mapeamento objeto-relacionalI </li>
    <li> <a href="https://www.microsoft.com/pt-br/sql-server/sql-server-downloads">SQL Server - Banco de dados relacional</li>
    <li> <a href="https://learn.microsoft.com/pt-br/ef/ef6/modeling/code-first/fluent/types-and-properties"> Fluent API - Configuração e o mapeamento no EF</li>
    <li> <a href="https://visualstudio.microsoft.com/pt-br/vs/"> Visual Studio 2022 - IDE C# / .NET</li>
    <li> <a href="https://swagger.io/"> Swagger - Documentação e teste da API</li>
  </ul>

# :books: Arquitetura
Arquitetura limpa refere-se à **organização do projeto** de forma que ele seja fácil de **entender**, fácil de **testar**, fácil de **manter** e fácil de **mudar** conforme o projeto cresce.
**A Regra de Dependência** afirma que a dependência do código-fonte só pode apontar para o **interior do aplicativo**.
Dessa forma o **domínio** é independente e não faz referência a recursos externos.
![image](https://github.com/ChristianSilvaPaz/ChristianSilvaPaz-MecEnxovaisApi/assets/62564760/41abc3a3-adc4-4d01-9e4c-9d1d7a618569)



