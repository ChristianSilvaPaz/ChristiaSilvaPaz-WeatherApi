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
  
Após isto, a Web API estará em pleno funcionamento. É possível visualizar a documentação e testar API, essa tela deverá aparecer na aba do seu navegador:
 
![image](https://github.com/ChristianSilvaPaz/ChristianSilvaPaz-MecEnxovaisApi/assets/62564760/443d920e-ff54-4653-be0d-bdaa05c1d84f)

