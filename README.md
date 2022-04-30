<h1> BRQ Digital Solution </h1>
API Restful criada para cadastro de candidatos para processos seletivos dentro da BRQ, onde são enviadas requisições HTTP para cadastro, atualização e pesquisas.

No sistema há 3 endpoints divididos em: 

<h3> Candidato </h3>
<ul>
  <li>Get</li> Retorna o cadastro de determinado candidato, permitindo também a busca por candidatos por campo-chave (Nome, Email, CPF, Skills e Certificações).
  <li>Post</li> Cadastra um candidato. 
  <li>Update</li> Atualiza o cadastro de um candidato.
</ul>
</br>
Para verificar a documentação da utilização dessas API'S, complete o tópico de <a href="#instalacao"> 🔧 Instalação </a>. O Swagger informará os parâmetros e rotas necessárias.
<img src="https://media.discordapp.net/attachments/908865516016390156/969784991812841482/unknown.png?width=1020&height=347"></img>

<h1> 🚀 Começando </h1>
Essas instruções permitirão que você obtenha uma cópia do projeto na sua máquina local para fins de desenvolvimento e teste.

<h1> 📋 Pré-requisitos </h1>
O que é necessário para a instalação?
</br>
<pre> 
Visual Studio
PostgreSQL 
</pre>

<h1 id="instalacao"> 🔧 Instalação </h1>
Uma série de exemplos passo-a-passo que informam o que você deve executar para ter um ambiente de desenvolvimento em execução.

<pre>   
1. Abra o 'appsettings.json' e insira a string de conexão da base de dados que você criou. 
</br>
2. Compile a solução. O Swagger informará os endpoints do projeto e como utilizá-los.
</pre>  

<h1> 🛠️ Construído com </h1>
Tecnologia: .NET 6

Swagger - Ferramenta para criação da documentação da API.
</br>
Entity Framework Core 6 - ORM utilizado para criação de relação entre o modelo físico e o modelo lógico da aplicação.

 by LiftOff 🚀
