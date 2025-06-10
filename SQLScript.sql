drop database db_vxgames;
create database db_vxgames;
use db_vxgames;

create table Tb_produto(
Id_prod int auto_increment,
Nome_prod varchar(50),
Descricao_prod varchar(250),
ValorCusto_prod numeric(10,2),
ValorVenda_prod numeric(10,2),
Desconto_prod numeric(10,2),
Tipo_prod varchar(50),
Marca_prod varchar(50),
QuantidadeEstoque_prod int,
img_path varchar(500) default '/assets/image/icones/404.svg',
VendaDisponivel_prod bool default 1,
primary key(Id_prod)
);

create table Tb_pagamento(
Id_pag int auto_increment primary key,
descricao_pag varchar(100)
);

create table Tb_estado(
Uf_est char(2),
Nome_est varchar(50),
primary key(Uf_est)
);

create table Tb_cliente(
Cpf_cli char(11),
Nome_cli varchar(100) not null,
primary key(Cpf_cli)
);

create table Tb_email(
Id_Email int auto_increment,
Cpf_cli char(11) not null,
Email varchar(50) not null default 'Sem Email',
primary key(Id_Email),
foreign key(Cpf_cli) references Tb_cliente(Cpf_cli) on delete cascade
);

create table Tb_usuario(
Id_usuario int auto_increment,
Cpf_cli char(11) not null,
Usuario_cli varchar(50),
Senha_cli varchar(50) not null,
Img_path longblob,
Img_caminho varchar(500) default '/assets/image/perfil-de-usuario.png',
Cargo_cli varchar (50) default'Cliente',
Ativo_cli bool default 1,
primary key(Id_usuario),
foreign key(Cpf_cli) references Tb_cliente(Cpf_cli) on delete cascade
);


create table Tb_telefone(
Id_telefone int auto_increment,
Cpf_cli char(11) not null,
Telefone varchar(50) not null default 'Sem Telefone',
DD varchar(10) not null default 'Sem DD',
primary key(Id_telefone),
foreign key(Cpf_cli) references Tb_cliente(Cpf_cli) on delete cascade
);

create table Tb_cep(
Cep varchar(8) primary key,
Bairro varchar(100) not null,
Cidade varchar(100) not null
);

create table Tb_endereco(
Cpf_cli varchar(11),
Cep varchar(8) not null,
Numero_residencia varchar(10) not null,
Uf_est char(2),
Endereco varchar(100) not null,
Complemento varchar(50),
primary key(Cep, Numero_residencia),
foreign key(Cep) references Tb_cep(Cep),
foreign key(Uf_est) references Tb_estado(Uf_est),
foreign key(Cpf_cli) references Tb_cliente(Cpf_cli) on delete cascade
);

create table Tb_carrinho(
Id_carrinho int auto_increment,
Id_pedido int,
Cpf_cli char(11) not null,
Id_prod int not null,
Id_pag int not null,
inforamacaoad_pag varchar(300) default 'Não informado',
quantidade int default '1',
preco_prod numeric(20,2) not null,
Data_pedido_car datetime,
Data_entrega_car datetime,
Tipo_entrega_car varchar(100),
Cep varchar(8),
Numero_residencia varchar(10),
primary key(id_carrinho),
foreign key(Cep, Numero_residencia) references Tb_endereco(Cep, Numero_residencia),
foreign key(Id_prod) references Tb_produto(Id_prod),
foreign key(Cpf_cli) references Tb_cliente(Cpf_cli),
foreign key(Id_pag) references Tb_pagamento(Id_pag)
);
