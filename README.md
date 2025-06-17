## 1.Introdução

Este documento tem como objetivo detalhar os requisitos de um sistema de gerenciamento para uma loja de games. O sistema será desenvolvido com base nas necessidades identificadas durante uma entrevista realizada com o cliente, e atenderá os usuários definidos nesse processo.
Inicialmente, foi criada a identidade visual da empresa, incluindo nome, CNPJ e demais dados cadastrais. Também foram elaborados materiais promocionais, como cartão de visita e flyer interativo, com o intuito de tornar a empresa mais atraente no mercado de desenvolvimento. Todo o planejamento foi organizado em um cronograma bem estruturado, utilizando a plataforma Trello da empresa.
A empresa desenvolveu um site com cinco páginas (Home, Empresa, Portfólio, Serviços e Contato), disponível nos idiomas português e inglês. O site foi construído utilizando apenas HTML, CSS e JavaScript, e será divulgado por meio das redes sociais LinkedIn, Facebook e Instagram.
Para o desenvolvimento do sistema, foi feita toda a prototipação do site e do sistema, seguida da implementação com base na lógica e nos conhecimentos adquiridos ao longo do projeto. Foram criados os diagramas de caso de uso e de classes para análise do sistema, bem como a modelagem de dados, contemplando os modelos conceitual, lógico e físico, além da normalização dos dados.
Por fim, toda a documentação do projeto foi elaborada, juntamente com os testes do sistema e do site, visando a aprovação final do cliente.

__*OBS: Alguns dados são fictícios e têm apenas o objetivo de simular situações específicas. Eles não alteram o conteúdo final do projeto, servindo apenas como um complemento ilustrativo.*__

## 2.Empresa 

VS Tech é uma empresa de tecnologia dedicada a oferecer soluções inovadoras em software e consultoria em TI. Está localizada na Av. Paulista, 9999, São Paulo – SP.
CNPJ: 87.321.548/0001-44
Telefone: (11) 4002-8922
E-mail: vstechconsultoria@gmail.com

__Missão:__
	Empoderar negócios por meio de soluções tecnológicas personalizadas, impulsionando o crescimento e a inovação de nossos clientes.
 
__Visão:__
	Ser reconhecida como a principal referência em desenvolvimento de softwares e sites, entregando soluções digitais que superem as expectativas e transformem a forma como as empresas operam.
 
__Valores:__
Inovação: Buscar constantemente novas tecnologias e metodologias para oferecer soluções ágeis e eficazes.

__Personalização:__ Desenvolver soluções sob medida, atendendo às necessidades específicas de cada cliente.

__Qualidade:__ Garantir excelência em todos os nossos produtos e serviços, entregando soluções robustas e confiáveis.

__Colaboração:__ Trabalhar em parceria com nossos clientes, construindo relações de longo prazo baseadas na confiança e no respeito mútuo.

__Ética:__ Agir com integridade e transparência em todas as nossas relações.

## 3.Logo e slogan do projeto

![logo](https://github.com/user-attachments/assets/47107e08-55c4-4292-bb6d-330b3399729c)

## 5. Visão geral do projeto

| Nº | Módulo                   | Descrição                                                                                                                                             |
|----|--------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1  | Análise do sistema do Projeto | Entrevista com o cliente, caso de uso e diagrama de classe para entender melhor como vão ser as funcionalidades do sistema.                           |
| 2  | Modelagem do sistema     | Normalização até a 4ª forma normal, diagrama de entidade e relacionamento com cardinalidades e dicionário de dados.                                   |
| 3  | Protótipo do sistema     | Criação das telas do projeto como modelo para desenvolver.                                                                                             |
| 4  | Desenvolvimento do Projeto | Desenvolvimento das telas do projeto seguindo como base os protótipos, utilizando frontend, backend e banco de dados.                               |

## 6. Cronograma(Trello)

Para controle e melhor desenpenho das atividades da equipe, a ferramenta utilizada foi o Trello.

![image](https://github.com/user-attachments/assets/4bd99fc1-b609-4d47-b226-207181eb476d)

## 9. Levantamento de Requisitos

**Entrevista com o Cliente**

- **Atualmente é utilizado algum sistema?**  
  Não possuo nenhum sistema no momento.

- **Que tipo de sistema deseja?**  
  Um sistema de e-commerce online que permita atender clientes remotamente, exibindo os produtos disponíveis.  
  O sistema também deve armazenar os dados dos clientes em um banco de dados.

- **O que o cliente deve poder fazer no sistema?**  
  O cliente deverá acessar sua conta, consultar seus últimos pedidos e realizar novos.

- **Quais funcionalidades o sistema precisa ter?**
  - Login de usuários cadastrados (CPF, nome e senha)
  - Cadastro de produtos (código, nome do produto, tipo, preço, imagem)
  - Registro dos carrinhos de compra (código do carrinho, data, descrição)

- **Quais produtos serão comercializados?**  
  Produtos de tecnologia e itens relacionados a jogos eletrônicos.

- **É necessário login para usar o sistema?**  
  Sim, apenas para os usuários.

- **Todos os funcionários utilizarão o sistema?**  
  Sim.

- **O sistema terá níveis de acesso?**  
  Sim. Haverá dois níveis:
  - Usuário (cliente)
  - Usuário (funcionário)

- **Em qual plataforma o sistema deve rodar?**  
  Windows.

- **O sistema funcionará em rede?**  
  Inicialmente, o sistema será local para testes.  
  Posteriormente, será disponibilizado online para acesso público.


## 6. ANÁLISE DE REQUISITOS  

### Requisitos Funcionais  

| ID    | Descrição |  
|-------|-----------|  
| RF01  | Efetuar Login |  
| RF02  | Cadastrar Usuário |  
| RF03  | Consultar Produtos |  
| RF04  | Colocar Produtos no Carrinho |  
| RF05  | Poder escolher a forma de Pagamento |  
| RF06  | Realizar compra de produtos |  
| RF07  | Consultar a última compra realizada |  
| RF08  | Consultar Todas as compras de forma detalhada |  
| RF09  | Poder Cadastrar e Editar os dados de Endereço |  
| RF10  | Exibir dados Cadastrais e Possibilitar sua mudança |  
| RF11  | Mostrar os Produtos em destaque na página inicial |  

---

### Requisitos Não Funcionais  

| ID     | Descrição                                                                 | Categoria      |  
|--------|---------------------------------------------------------------------------|----------------|  
| RFN01  | Somente usuários cadastrados podem acessar o sistema                     | Segurança      |  
| RFN02  | Informar erros relacionados ao Login/Cadastro ao usuário                 | Usabilidade    |  
| RFN03  | Telas simples com cores branco, azul e preto; fontes pretas ou brancas   | Compatibilidade|  
| RFN04  | Sistema deve rodar em Windows                                            | Usabilidade    |  
| RFN05  | Pesquisa por nome ou descrição do produto                                | Usabilidade    |  
| RFN06  | Usuário precisa estar logado para adicionar itens ao carrinho            | Usabilidade    |  
| RFN07  | Não permitir cadastro de endereços de outras contas                      | Segurança      |  
| RFN08  | Exibir imagem padrão se o usuário não tiver foto de perfil               | Usabilidade    |  
| RFN09  | Redirecionar para Login ao tentar comprar sem estar logado               | Segurança      |  

---

### Restrições  

| ID   | Descrição                                      |  
|------|------------------------------------------------|  
| R01  | Sistema não roda em Linux ou Mac               |  
| R02  | Processador mínimo: Celeron Dual Core          |  
| R03  | Memória RAM mínima: 1 GB                       |  
| R04  | Espaço em disco mínimo: 3 GB                   |  
| R05  | Compatível apenas a partir do Windows 7        |  


## 8. MODELAGEM DE DADOS

 * MODELO CONCEITUAL

![image](https://github.com/user-attachments/assets/61dbf596-1792-4d08-98a5-af6705db5dc7)

 * MODELO LÓGICO

![image](https://github.com/user-attachments/assets/bf870fa4-0940-43bc-ab1b-9467f584594f)

* MODELO FISICO


<details>
  <summary>📌 Script do MySQL</summary>
/* Criando o Banco de Dados do Ecomercy */
<br>
create database db_vxgames;

/* Usando o Banco de dados */
<br>use db_vxgames;

<br>create table Tb_produto(
<br>Id_prod int auto_increment,
<br>Nome_prod varchar(50),
<br>Descricao_prod varchar(250),
<br>ValorCusto_prod numeric(10,2),
<br>ValorVenda_prod numeric(10,2),
<br>Desconto_prod numeric(10,2),
<br>Tipo_prod varchar(50),
<br>Marca_prod varchar(50),
<br>QuantidadeEstoque_prod int,
<br>img_path varchar(500) default '/assets/image/icones/404.svg',
<br>VendaDisponivel_prod bool default '1',
<br>primary key(Id_prod)
<br>);
<br>create table Tb_pagamento(
<br>Id_pag int auto_increment primary key,
<br>descricao_pag varchar(100)
<br>);
<br>create table Tb_estado(
<br>Uf_est char(2),
<br>Nome_est varchar(50),
<br>primary key(Uf_est)
<br>);
<br>create table Tb_cliente(
<br>Cpf_cli char(11),
<br>Nome_cli varchar(100) not null,
<br>primary key(Cpf_cli)
<br>);
<br>create table Tb_email(
<br>Id_Email int auto_increment,
<br>Cpf_cli char(11) not null,
<br>Email varchar(50) not null default 'Sem Email',
<br>primary key(Id_Email),
<br>foreign key(Cpf_cli) references Tb_cliente(Cpf_cli) on delete cascade
<br>);
<br>create table Tb_usuario(
<br>Id_usuario int auto_increment,
<br>Cpf_cli char(11) not null,
<br>Usuario_cli varchar(50),
<br>Senha_cli varchar(50) not null,
<br>Img_path longblob,
<br>Img_caminho varchar(500) default '/assets/image/perfil-de-usuario.png',
<br>Cargo_cli varchar (50) default 'Cliente',
<br>Ativo_cli bool default '1',
<br>primary key(Id_usuario),
<br>foreign key(Cpf_cli) references Tb_cliente(Cpf_cli) on delete cascade
<br>);
<br>create table Tb_telefone(
<br>Id_telefone int auto_increment,
<br>Cpf_cli char(11) not null,
<br>Telefone varchar(50) not null default 'Sem Telefone',
<br>DD varchar(10) not null default 'Sem DD',
<br>primary key(Id_telefone),
<br>foreign key(Cpf_cli) references Tb_cliente(Cpf_cli) on delete cascade
<br>);
<br>create table Tb_cep(
<br>Cep varchar(8) primary key,
<br>Bairro varchar(100) not null,
<br>Cidade varchar(100) not null
<br>);
<br>create table Tb_endereco(
<br>Cpf_cli varchar(11),
<br>Cep varchar(8) not null,
<br>Numero_residencia varchar(10) not null,
<br>Uf_est char(2),
<br>Endereco varchar(100) not null,
<br>Complemento varchar(50),
<br>primary key(Cep, Numero_residencia),
<br>foreign key(Cep) references Tb_cep(Cep),
<br>foreign key(Uf_est) references Tb_estado(Uf_est),
<br>foreign key(Cpf_cli) references Tb_cliente(Cpf_cli) on delete cascade
<br>);
<br>create table Tb_carrinho(
<br>Id_carrinho int auto_increment,
<br>Id_pedido int,
<br>Cpf_cli char(11) not null,
<br>Id_prod int not null,
<br>Id_pag int not null,
<br>inforamacaoad_pag varchar(300) default 'Não informado',
<br>quantidade int default '1',
<br>preco_prod numeric(20,2) not null,
<br>Data_pedido_car datetime,
<br>Data_entrega_car datetime,
<br>Tipo_entrega_car varchar(100),
<br>Cep varchar(8),
<br>Numero_residencia varchar(10),
<br>primary key(id_carrinho),
<br>foreign key(Cep, Numero_residencia) references Tb_endereco(Cep, Numero_residencia),
<br>foreign key(Id_prod) references Tb_produto(Id_prod),
<br>foreign key(Cpf_cli) references Tb_cliente(Cpf_cli),
<br>foreign key(Id_pag) references Tb_pagamento(Id_pag)
<br>);

</details>

## 9. PROTOTIPO

 * HOME PAGE

![image](https://github.com/user-attachments/assets/339df31f-af7b-4ef1-a09a-b26d980d1835)

* PESQUISA DE PRODUTOS

![image](https://github.com/user-attachments/assets/037e8612-a089-4a8c-9976-54c8ea3624ec)

* MINHA CONTA

![image](https://github.com/user-attachments/assets/074c7d2d-df68-44a2-b7b6-05b5c43b8e03)

* MINHA CONTA(ENDEREÇO)

![image](https://github.com/user-attachments/assets/9f432093-4e21-4649-b9da-6738ac5515db)

* CARRINHO DE COMPRA

![image](https://github.com/user-attachments/assets/4507e10d-c0e5-4c6c-90bc-cd8cd7178366)

* PAGINA DE PAGAMENTO

![image](https://github.com/user-attachments/assets/9d6aa4ee-06a3-4176-b9db-540af9955cd0)

# COMO TESTAR

## Requisitos: 
* MySQL Workbrench 8.0 instalado.
* Browser Google Crome, Mozila FireFox, entre outros.

## Passo a Passo

### 1 - BAIXE A DEMO DO SISTEMA(.zip)
![Tutoria2](https://github.com/user-attachments/assets/b5d72396-6723-4830-9e30-70f655c2d79d)

### 2 - EXTRAIA OS ARQUIVOS DO ZIP 
![image](https://github.com/user-attachments/assets/714a3b71-b3ac-4256-ba9e-7f0bca1f0b85)
-----------------------------------------------------------------------------------------
![image](https://github.com/user-attachments/assets/ed9200a1-0c85-404f-820c-c3124a59d776)

### 3 - CONFIGURANDO O BANCO DE DADOS

#### 3.1 - Abra a pasta MySqlScript.
![image](https://github.com/user-attachments/assets/4c95ccfd-277a-42a9-b15a-bd431700ee9b)
#### 3.2 - Dentro do seu MySql Workbrench, coloque os dois scripts. Primeiro selecione o 'create database db_vxgames;' e execute ele, logo em seguida execute a linha abaixo 'use db_vxgames;'
![image](https://github.com/user-attachments/assets/62a91859-ba2e-444e-a080-837af0feb343)
#### 3.3 - Selecione todo o script a partir da linha 5 e execute ele.
![image](https://github.com/user-attachments/assets/873fec17-0712-49e1-a4ab-c3d4489806df)
#### 3.4 - Agora no segundo script 'MySqlScriptInserts' selecione todos os itens a partir da 3 linha e execute eles.

### 4 - ABRINDO O SISTEMA
Para abrir o sistema basta executar o 'VX-GAMES.bat'
![image](https://github.com/user-attachments/assets/526f2f81-c7e9-4e63-8704-4792f776ce6b)
## COM ISSO O SISTEMA IRA ABRIR, E VOCÊ PODERA TESTAR ELE.







