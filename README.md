# WeatherApi

Este projeto trata-se do desenvolvimento de uma API como parte do processo seletivo para a vaga de .NET Developer JR na Fasters.


<b>O objetivo é demonstrar conhecimento e por isso foi cometido o excesso de engenharia de forma proposital.</b>

# :rocket: Começando

Essas instruções permitirão que você obtenha uma cópia do projeto em operação na sua máquina local para fins de desenvolvimento e teste.

:clipboard: Pré-requisitos

<ul>
  <li> <a href="https://dotnet.microsoft.com/pt-br/download/dotnet/7.0"> .NET 7 ou superior </li>
  <li> <a href="https://dev.mysql.com/downloads/installer/"> MySQL 8 ou superior </li>
</ul>

## 1. Obtendo uma cópia e configurando
Abra um terminal e clone este repositório em qualquer diretório da sua máquina (recomendado c:\ no Windows) utilizando o comando: git clone https://github.com/ChristianSilvaPaz/ChristianSilvaPaz-WeatherApi.git

Acesse o diretório do projeto em: WeatherApi/WeatherApi

Localize e abra o arquivo de configuração: appsettings.Development.json

Altere a seção ConnectionStrings com as informações de conexão com o MySqlWorkbench:

```
"ConnectionStrings": {
"DefaultConnection": "Server=localhost;Database=weather_database;Uid=root;Pwd=;AllowZeroDateTime=true"
}
```

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
Para receber dados climáticos de uma cidade, faça uma requisição GET para /api/WeatherCity/GetByName conforme imagem abaixo:

<img width="604" alt="Captura de tela 2023-10-12 174124" src="https://github.com/ChristianSilvaPaz/ChristiaSilvaPaz-WeatherApi/assets/62564760/65bfbcf0-ba63-4adc-93f5-50472cc82a6b">


# :hammer_and_wrench: Construído com:
Ferramentas/tecnologias utilizadas para construção deste projeto

  <ul>
    <li> <a href="https://dotnet.microsoft.com/pt-br/download/dotnet/7.0">.NET 7 - Backend e Web API</li>
    <li> <a href="https://github.com/DapperLib/Dapper">Dapper Micro ORM </li>
    <li> <a href="https://dev.mysql.com/downloads/installer/">MySql - Banco de dados relacional</li>
    <li> <a href="https://visualstudio.microsoft.com/pt-br/vs/"> Visual Studio 2022 - IDE C# / .NET</li>
    <li> <a href="https://automapper.org/">AutoMaper - Mapeador Objeto-Objeto</li>
    <li> <a href="https://xunit.net/">XUnit - Ferramenta de Teste</li>
    <li> <a href="https://fluentassertions.com/">Fluent Assertions - Asserts</li>
    <li> <a href="https://nsubstitute.github.io/">NSubstitute - Mocking Test</li>
    <li> <a href="https://swagger.io/">Swagger - Documentação e teste da API</li>
  </ul>

# :books: Arquitetura
O estilo de arquitetura Vertical Slice trata da organização do código por recursos e fatias verticais, em vez de organização por questões técnicas. Trata-se de agrupar o código de acordo com a funcionalidade do negócio e reunir todos os códigos relevantes. A arquitetura Vertical Slice pode ser um ponto de partida e pode evoluir posteriormente, quando um aplicativo se tornar mais sofisticado.




