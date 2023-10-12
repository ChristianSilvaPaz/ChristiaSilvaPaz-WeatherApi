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

## 2. Subindo o Backend
Observação: os passos abaixo foram realizados utilizando um ambiente de desenvolvimento integrado como o Microsoft Visual Studio, basta abrir a solução WeatherApi.sln que está na pasta src e executar o projeto WeatherApi.API
Abra a aba Gerenciador de Testes do Visual Studio para executar os testes, ou se preferir, no terminal: acesse a pasta do código fonte do projeto com:

```
function test() {
  console.log("notice the blank line before this function?");
}
```
  
Após isto, a Web API estará em pleno funcionamento. É possível visualizar a documentação e testar API, essa tela deverá aparecer na aba do seu navegador:
 
<img width="630" alt="Captura de tela 2023-10-12 164058" src="https://github.com/ChristianSilvaPaz/ChristiaSilvaPaz-WeatherApi/assets/62564760/7d7f53f1-2f53-40d2-b059-467839662a3a">



