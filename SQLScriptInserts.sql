use db_vxgames;

INSERT INTO Tb_produto 
(Nome_prod, Descricao_prod, ValorCusto_prod, ValorVenda_prod, Desconto_prod, Tipo_prod, Marca_prod, QuantidadeEstoque_prod, VendaDisponivel_prod, img_path) 
VALUES 
('PlayStation 5', 'Console de última geração', 4500.00, 4050.00, 10.00, 'Console', 'Sony', 15, 1, 'https://m.media-amazon.com/images/I/51VZErxKwkL._AC_UF1000,1000_QL80_.jpg'),
('Xbox Series X', 'Console com desempenho de ponta', 4300.00, 3870.00, 10.00, 'Console', 'Xbox', 10, 1,'https://cms-assets.xboxservices.com/assets/bc/40/bc40fdf3-85a6-4c36-af92-dca2d36fc7e5.png?n=642227_Hero-Gallery-0_A1_857x676.png'),
('Placa de Vídeo RTX 3060', 'GPU para jogos', 2800.00, 2380.00, 15.00, 'Hardware', 'NVIDIA', 20, 1,'https://images.kabum.com.br/produtos/fotos/180539/placa-de-video-gigabyte-geforce-rtx-3060-gaming-oc-12g-12-gb-gddr6-rev-2-0-ray-tracing-gv-3060gaming_1626461646_g.jpg'),
('Processador Ryzen 7', 'Processador Octa-Core', 1800.00, 1530.00, 15.00, 'Hardware', 'AMD', 30, 1,'https://media.pichau.com.br/media/catalog/product/cache/2f958555330323e505eba7ce930bdf27/1/0/100-100000926wof.jpg'),
('Notebook Gamer', 'Alto desempenho para jogos', 5200.00, 4420.00, 15.00, 'Notebook', 'ASUS', 8, 1,'https://images.kabum.com.br/produtos/fotos/sync_mirakl/462294/xlarge/Notebook-Gamer-Acer-Nitro-5-Intel-Core-i5-11400h-4-50GHz-8GB-GTX-1650-SSD-512GB-Tela-15-6-144Hz-Windows-11-AN515-57-59AT_1744223446.jpg'),
('Teclado Mecânico', 'RGB com switches azuis', 250.00, 200.00, 20.00, 'Acessórios', 'Logitech', 50, 1,'https://static.mundomax.com.br/produtos/84138/100/1.webp'),
('Mouse Gamer G903', 'Alto DPI com RGB', 150.00, 120.00, 20.00, 'Acessórios', 'Logitech', 40, 1,'https://supricom.com/wp-content/uploads/2024/04/mouse-gamer-logitech-g903-hero-ligthspeed-wireless-rgb-black-910-005670.jpg'),
('Jogo God of War Ragnarok', 'Mídia física', 300.00, 255.00, 15.00, 'Midia Fisica', 'Sony', 25, 1,'https://i.zst.com.br/thumbs/12/20/2a/-1340719298.jpg'),
('Jogo Forza Horizon 5', 'Mídia digital', 250.00, 200.00, 20.00, 'Midia Digital', 'Xbox', 30, 1,'https://down-br.img.susercontent.com/file/2cf48df41ad2d68719929499bcf4b26d'),
('Placa-Mãe B450', 'Compatível com Ryzen', 600.00, 480.00, 20.00, 'Hardware', 'ASUS', 18, 1,'https://www.fgtec.com.br/media/catalog/product/cache/6630b9e112ee13f7d501bef37f6e88ec/b/d/bd73b3cc597fff90293a71f91151d35e.jpeg');

INSERT INTO Tb_produto 
(Nome_prod, Descricao_prod, ValorCusto_prod, ValorVenda_prod, Desconto_prod, Tipo_prod, Marca_prod, QuantidadeEstoque_prod, VendaDisponivel_prod, img_path) 
VALUES
-- Smartphones
('Smartphone Microsoft', 'Lumia 220 com 4G, 64GB de Armazenamento e Tela HD', 3289.95, 3289.95, 0.00, 'Smartphone', 'Microsoft', 23, 1, '/assets/image/itens/FotoSmartFone.png'),
('Smartphone Positivo', 'Android 10, 64GB e Câmera 13MP', 2803.24, 2522.92, 10.00, 'Smartphone', 'Positivo', 29, 1, '/assets/image/itens/SmartphonePOSITIVO-4.png'),
('Smartphone Microsoft', 'Tela de 6.5", 128GB e desempenho aprimorado', 2415.80, 2415.80, 0.00, 'Smartphone', 'Microsoft', 28, 1, '/assets/image/itens/SmartphoneASUS-2.png'),
('Smartphone Positivo', 'Compacto com 32GB, ideal para uso diário', 732.64, 732.64, 0.00, 'Smartphone', 'Positivo', 31, 1, '/assets/image/itens/TabletPOSITIVO-2.png'),
('Console Sony', ' qualidade de som premium e 128GB de armazenamento', 1971.71, 1774.54, 10.00, 'Smartphone', 'Sony', 19, 1, '/assets/image/itens/SonyProdutoremoto2.png'),

-- Computadores
('Computador Asus', 'Monitor LED 21", 8GB RAM e SSD 256GB', 2817.65, 2817.65, 0.00, 'Computador', 'Asus', 35, 1, '/assets/image/itens/ComputadorCompleto.png'),
('Computador Positivo', 'PC com gabinete slim, ideal para escritório, com SSD 240GB', 2327.33, 1861.86, 20.00, 'Computador', 'Positivo', 38, 1, '/assets/image/itens/ComputadorPOSITIVO-5.png'),
('Computador Intel', 'Intel Core i5, 8GB RAM, 500GB HD', 2517.84, 2517.84, 0.00, 'Computador', 'Intel', 30, 1, '/assets/image/itens/Intel Core i3.png'),
('Computador Asus', 'PC com monitor 24", 16GB RAM e placa de vídeo dedicada', 2994.53, 2545.35, 15.00, 'Computador', 'Asus', 33, 1, '/assets/image/itens/MonitorGamerASUS-5.png'),
('Computador Positivo', 'Computador com Windows 10 e 4GB RAM', 1845.27, 1845.27, 0.00, 'Computador', 'Positivo', 39, 1, '/assets/image/itens/KitCasaConectadaPOSITIVO-3.png'),

-- Acessórios
('Adaptador Logitech', 'Para dispositivos USB-C com entrada HDMI', 129.90, 129.90, 0.00, 'Acessório', 'Logitech', 50, 1, '/assets/image/itens/AdaptadorLOGITECH-3.png'),
('Fone de Ouvido', 'Com microfone, ideal para chamadas e música', 89.90, 149.90, 10.00, 'Acessório', 'Genérico', 100, 1, '/assets/image/itens/FoneAcessorio.png'),
('Mouse Logitech', 'Sem fio com design ergonômico e alta precisão', 79.90, 79.90, 0.00, 'Acessório', 'Logitech', 75, 1, '/assets/image/itens/MouseSemFioLOGITECH-2.png'),
('Teclado Logitech', 'Mecânico com retroiluminação RGB', 199.90, 199.90, 0.00, 'Acessório', 'Logitech', 60, 1, '/assets/image/itens/TecladoGamerLOGITECH-5.png'),
('Placa de Vídeo ASUS', 'RTX 3090 para jogos em 4K', 4999.90, 7999.90, 15.00, 'Acessório', 'ASUS', 20, 1, '/assets/image/itens/PlacaDeVideoASUS-4.png'),

-- Consoles (mantém o desconto)
('PlayStation 5', '1TB de armazenamento e controle sem fio', 4999.90, 5999.90, 10.00, 'Console', 'Sony', 40, 1, '/assets/image/itens/PlayStation 5.png'),
('Xbox Series X', '1TB de armazenamento e suporte a 4K', 4999.90, 5999.90, 10.00, 'Console', 'Microsoft', 45, 1, '/assets/image/itens/XboxSeriesX1.png'),
('Controle Xbox Elite', 'com botões personalizáveis e alta precisão', 499.90, 499.90, 0.00, 'Acessório', 'Microsoft', 50, 1, '/assets/image/itens/XboxControlerElite5.png'),

-- Softwares
('Pacote Windows e Office', 'Windows 11 Pro e Office 2021 para uso profissional', 799.90, 999.90, 15.00, 'Software', 'Microsoft', 100, 1, '/assets/image/itens/PacoteWindowsEOffice-5.png'),
('Windows 10', 'Windows 10 Home para uso doméstico', 199.90, 199.90, 0.00, 'Software', 'Windows', 200, 1, '/assets/image/itens/Window10-2.png'),
('Windows 11', 'Windows 11 Home com interface moderna', 249.90, 249.90, 0.00, 'Software', 'Windows', 150, 1, '/assets/image/itens/Window11-1.png');

insert into Tb_pagamento(descricao_pag) values
('sem forma de pagamento'),
('Cartao de Debito'),
('Cartao de Credito'),
('Boleto'),
('PIX'),
('Outro');

insert into Tb_cliente values('00000000000','Admin');
insert into Tb_usuario(Cpf_cli,Usuario_cli,Senha_cli,Cargo_cli) values
('00000000000','admin','admin','ADMIN');
insert into Tb_telefone(Cpf_cli) values ('00000000000');
insert into Tb_Email(Cpf_cli) values ('00000000000');