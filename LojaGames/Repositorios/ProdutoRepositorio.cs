using MySql.Data.MySqlClient;
using LojaGames.Models;
using System.Configuration;
using System.Data;
using LojaGames.Repositorios;
using MySqlX.XDevAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mysqlx.Crud;
using System.Runtime.ConstrainedExecution;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace LojaGames.Repositorios
{
    public class ProdutoRepositorio(IConfiguration configuration)
    {
        public ListasProdutos listadeprodutoserdados = new ListasProdutos();
        private readonly string _connectionString = configuration.GetConnectionString("MySQLConnection");


        public void AdicionarProduto(Tb_produto produto)
        {
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();

                cmd.CommandText = "INSERT INTO Tb_produto (Nome_prod, Descricao_prod, ValorCusto_prod,ValorVenda_prod, Desconto_prod, Tipo_prod, Marca_prod, QuantidadeEstoque_prod) VALUES (@Nome,@Descricao,@Custo,@Venda,@Desconto,@tipo,@marca,@quantidade)";
                cmd.Parameters.AddWithValue("@Nome", produto.Nome_prod);
                cmd.Parameters.AddWithValue("@Descricao", produto.Descricao_prod);
                cmd.Parameters.AddWithValue("@Custo", produto.ValorCusto_prod);
                cmd.Parameters.AddWithValue("@Venda", (produto.Desconto_prod) * (produto.ValorCusto_prod));
                cmd.Parameters.AddWithValue("@Desconto", produto.Desconto_prod);
                cmd.Parameters.AddWithValue("@tipo", produto.Tipo_prod);
                cmd.Parameters.AddWithValue("@marca", produto.Marca_prod);
                cmd.Parameters.AddWithValue("@quantidade", produto.QuantidadeEstoque_prod);
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Tb_produto> ListaProdutos(string pesquisa)
        {

            if (pesquisa == "Xbox" || pesquisa == "Playstation" || pesquisa == "Informatica" || pesquisa == "Smartphone" || pesquisa == "xbox" || pesquisa == "playstation" || pesquisa == "informatica" || pesquisa == "smartphone")
            {
                using (var db = new Conexao(_connectionString))
                {
                    List<Tb_produto> listaproduto = new List<Tb_produto>();
                    var Prompt = db.MySqlCommand();
                    Prompt.CommandText = "Select * from Tb_produto";

                    using (var reader = Prompt.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Tb_produto produto = new Tb_produto
                            {
                                Id_prod = reader.GetInt32("Id_prod"),
                                Nome_prod = reader.GetString("Nome_prod"),
                                Descricao_prod = reader.GetString("Descricao_prod"),
                                ValorCusto_prod = reader.GetDecimal("ValorCusto_prod"),
                                ValorVenda_prod = reader.GetDecimal("ValorVenda_prod"),
                                Desconto_prod = reader.GetDecimal("Desconto_prod"),
                                Tipo_prod = reader.GetString("Tipo_prod"),
                                Marca_prod = reader.GetString("Marca_prod"),
                                QuantidadeEstoque_prod = reader.GetInt32("QuantidadeEstoque_prod"),
                                VendaDisponivel_prod = reader.GetBoolean("VendaDisponivel_prod"),
                                img_path = reader.GetString("img_path"),
                            };

                            listaproduto.Add(produto);
                        }

                        return listaproduto;
                    }

                }
            }
            else
            {
                using (var db = new Conexao(_connectionString))
                {
                    List<Tb_produto> listaproduto = new List<Tb_produto>();
                    var Prompt = db.MySqlCommand();
                    Prompt.CommandText = $"select * from Tb_produto where Nome_prod like '%{pesquisa}%' or Descricao_prod like '%{pesquisa}%';";

                    using (var reader = Prompt.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Tb_produto produto = new Tb_produto
                            {
                                Id_prod = reader.GetInt32("Id_prod"),
                                Nome_prod = reader.GetString("Nome_prod"),
                                Descricao_prod = reader.GetString("Descricao_prod"),
                                ValorCusto_prod = reader.GetDecimal("ValorCusto_prod"),
                                ValorVenda_prod = reader.GetDecimal("ValorVenda_prod"),
                                Desconto_prod = reader.GetDecimal("Desconto_prod"),
                                Tipo_prod = reader.GetString("Tipo_prod"),
                                Marca_prod = reader.GetString("Marca_prod"),
                                QuantidadeEstoque_prod = reader.GetInt32("QuantidadeEstoque_prod"),
                                VendaDisponivel_prod = reader.GetBoolean("VendaDisponivel_prod"),
                                img_path = reader.GetString("img_path"),
                            };

                            listaproduto.Add(produto);
                        }

                        return listaproduto;
                    }

                }
            }


        }

        public Tb_produto ObterProduto(int id)
        {
            using (var db = new Conexao(_connectionString))
            {
                var Prompt = db.MySqlCommand();
                Prompt.CommandText = $"Select * from Tb_produto where Id_prod={id}";

                using (var reader = Prompt.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Tb_produto produto = new Tb_produto
                        {
                            Id_prod = reader.GetInt32("Id_prod"),
                            Nome_prod = reader.GetString("Nome_prod"),
                            Descricao_prod = reader.GetString("Descricao_prod"),
                            ValorCusto_prod = reader.GetDecimal("ValorCusto_prod"),
                            ValorVenda_prod = reader.GetDecimal("ValorVenda_prod"),
                            Desconto_prod = reader.GetDecimal("Desconto_prod"),
                            Tipo_prod = reader.GetString("Tipo_prod"),
                            Marca_prod = reader.GetString("Marca_prod"),
                            QuantidadeEstoque_prod = reader.GetInt32("QuantidadeEstoque_prod"),
                            VendaDisponivel_prod = reader.GetBoolean("VendaDisponivel_prod"),
                            img_path = reader.GetString("img_path"),
                        };

                        return produto;
                    }

                    return new Tb_produto();
                }

            }
        }

        public IEnumerable<Tb_carrinho> listaCarrinho(string id)
        {
            Console.WriteLine(id);
            using (var db = new Conexao(_connectionString))
            {
                string pedido = id;

                List<Tb_carrinho> listacarrinho = new List<Tb_carrinho>();
                var Prompt = db.MySqlCommand();
                Prompt.CommandText = $"Select * from Tb_carrinho where Id_pedido={pedido};";

                using (var reader = Prompt.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tb_carrinho carrinho = new Tb_carrinho
                        {
                            Id_carrinho = reader.GetInt32("Id_carrinho"),
                            Cpf_cli = reader.GetString("Cpf_cli"),
                            Id_prod = reader.GetInt32("Id_prod"),
                            preco_prod = reader.GetDecimal("preco_prod"),
                            tb_Produto = ObterProduto(reader.GetInt32("Id_prod"))
                        };

                        listacarrinho.Add(carrinho);
                    }

                    return listacarrinho;
                }

            }
        }


        public string novoPedido()
        {
            using (var db = new Conexao(_connectionString))
            {
                var Prompt = db.MySqlCommand();
                Prompt.CommandText = "select max(Id_pedido) as 'max' from Tb_carrinho";

                using (var reader = Prompt.ExecuteReader())
                {
                    if (reader.Read() && reader.IsDBNull("max") == false)
                    {
                        return Convert.ToString(reader.GetInt32("max") + 1); 
                    }
                    else
                    {
                        return "0";
                    }
                }

            }
        }

        public void carrinhoNovoProd(Tb_carrinho tb_Carrinho)
        {
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();

                cmd.CommandText = "INSERT INTO Tb_carrinho (Id_pedido, Cpf_cli, Id_prod,Id_pag, quantidade, preco_prod) VALUES (@Id_pedido,@cpf,@Id_prod,@Id_pag,@quantidade,@preco_prod)";
                cmd.Parameters.AddWithValue("@Id_pedido", tb_Carrinho.Id_pedido);
                cmd.Parameters.AddWithValue("@cpf", tb_Carrinho.Cpf_cli);
                cmd.Parameters.AddWithValue("@Id_prod", tb_Carrinho.Id_prod);
                cmd.Parameters.AddWithValue("@Id_pag", (tb_Carrinho.Id_pag));
                cmd.Parameters.AddWithValue("@quantidade", tb_Carrinho.quantidade);
                cmd.Parameters.AddWithValue("@preco_prod", tb_Carrinho.preco_prod);
                cmd.ExecuteNonQuery();
            }
        }


        public void registrarPagBoleto(string id, string cepSelecionado, string numeroSelecionado)
        {
            string Idpedido = id;
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();
                cmd.CommandText = "SET SQL_SAFE_UPDATES = 0;Update Tb_carrinho set Cep=@cep, Numero_residencia=@numero, Id_pag=4,inforamacaoad_pag='Pagamento de Boleto Online', Data_pedido_car=current_timestamp(), Data_entrega_car=DATE_ADD(current_timestamp(), INTERVAL 3 DAY),Tipo_entrega_car='Premium' where Id_pedido=@ID;SET SQL_SAFE_UPDATES = 1;";
                cmd.Parameters.AddWithValue("@ID", Idpedido);
                cmd.Parameters.AddWithValue("@cep", cepSelecionado);
                cmd.Parameters.AddWithValue("@numero", numeroSelecionado);
                cmd.ExecuteNonQuery();
            }
        }
        public void registrarPagDebt(string id, string numero, string nome, string cepSelecionado, string numeroSelecionado)
        {
            string Idpedido = id;
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();
                cmd.CommandText = $"SET SQL_SAFE_UPDATES = 0;Update Tb_carrinho set Cep=@cep, Numero_residencia=@numero, Id_pag=2,inforamacaoad_pag='(Cartao de Debito) Dono: {nome}, Cartao: {numero}', Data_pedido_car=current_timestamp(), Data_entrega_car=DATE_ADD(current_timestamp(), INTERVAL 3 DAY),Tipo_entrega_car='Premium' where Id_pedido=@ID;SET SQL_SAFE_UPDATES = 1;";
                cmd.Parameters.AddWithValue("@ID", Idpedido);
                cmd.Parameters.AddWithValue("@cep", cepSelecionado);
                cmd.Parameters.AddWithValue("@numero", numeroSelecionado);
                cmd.ExecuteNonQuery();
            }
            
        }
        public void registrarPagCred(string id, string numero, string nome, string cepSelecionado, string numeroSelecionado)
        {
            string Idpedido = id;
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();
                cmd.CommandText = $"SET SQL_SAFE_UPDATES = 0;Update Tb_carrinho set Cep=@cep, Numero_residencia=@numero, Id_pag=3,inforamacaoad_pag='(Cartao de credito) Dono: {nome}, Cartao: {numero}', Data_pedido_car=current_timestamp(), Data_entrega_car=DATE_ADD(current_timestamp(), INTERVAL 3 DAY),Tipo_entrega_car='Premium' where Id_pedido=@ID;SET SQL_SAFE_UPDATES = 1;";
                cmd.Parameters.AddWithValue("@ID", Idpedido);
                cmd.Parameters.AddWithValue("@cep", cepSelecionado);
                cmd.Parameters.AddWithValue("@numero", numeroSelecionado);
                cmd.ExecuteNonQuery();
            }
        }
        public void registrarPagQrcode(string id, string cepSelecionado, string numeroSelecionado)
        {
            string Idpedido = id;
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();
                cmd.CommandText = "SET SQL_SAFE_UPDATES = 0;Update Tb_carrinho set Cep=@cep, Numero_residencia=@numero, Id_pag=5,inforamacaoad_pag='PIX Online', Data_pedido_car=current_timestamp(), Data_entrega_car=DATE_ADD(current_timestamp(), INTERVAL 3 DAY),Tipo_entrega_car='Premium' where Id_pedido=@ID;SET SQL_SAFE_UPDATES = 1;";
                cmd.Parameters.AddWithValue("@ID", Idpedido);
                cmd.Parameters.AddWithValue("@cep", cepSelecionado);
                cmd.Parameters.AddWithValue("@numero", numeroSelecionado);
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Historico> getHistorico(string cpf)
        {
            return GetBDHistorico(cpf);
        }

        private IEnumerable<Historico> GetBDHistorico(string cpf)
        {
            using (var db = new Conexao(_connectionString))
            {
                List<Historico> listaHistorico = new List<Historico>();
                var prompt = db.MySqlCommand();
                prompt.CommandText = $"SELECT tcar.Id_carrinho, tcar.Id_pedido, tped.Nome_prod, tped.Descricao_prod, tped.Tipo_prod, tped.Marca_prod, tped.img_path, tcar.quantidade, tcar.preco_prod, tped.Desconto_prod, tcar.inforamacaoad_pag, tcar.Data_pedido_car, tcar.Data_entrega_car, tcar.Tipo_entrega_car, tend.Cep, tend.Endereco, tend.Complemento, tend.Numero_residencia, test.Uf_est, test.Nome_est FROM Tb_carrinho tcar INNER JOIN Tb_produto tped ON tcar.Id_prod = tped.Id_prod INNER JOIN Tb_pagamento tpag ON tcar.Id_pag = tpag.Id_pag INNER JOIN Tb_cliente tcli ON tcar.Cpf_cli = tcli.Cpf_cli INNER JOIN Tb_endereco tend ON tcar.Cep = tend.Cep AND tcar.Numero_residencia = tend.Numero_residencia INNER JOIN Tb_cep tcep ON tend.Cep = tcep.Cep INNER JOIN Tb_estado test ON test.Uf_est = tend.Uf_est WHERE tcar.Cpf_cli = @cpf";
                prompt.Parameters.AddWithValue("@cpf", cpf);
                using (var reader = prompt.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("READER ESTA LENDO");
                            Historico historico = new Historico
                            {
                                Id_carrinho = reader.GetInt32("Id_carrinho"),
                                Id_pedido = reader.GetInt32("Id_pedido"),
                                Nome_prod = reader.GetString("Nome_prod"),
                                Descricao_prod = reader.GetString("Descricao_prod"),
                                Tipo_prod = reader.GetString("Tipo_prod"),
                                Marca_prod = reader.GetString("Marca_prod"),
                                Img_path = reader.GetString("img_path"),
                                Quantidade = reader.GetInt32("quantidade"),
                                Preco_prod = reader.GetDecimal("preco_prod"),
                                Desconto_prod = reader.GetDecimal("Desconto_prod"),
                                Inforamacaoad_pag = reader.IsDBNull(reader.GetOrdinal("inforamacaoad_pag")) ? null : reader.GetString("inforamacaoad_pag"),
                                Data_pedido_car = reader.GetDateTime("Data_pedido_car"),
                                Data_entrega_car = reader.GetDateTime("Data_entrega_car"),
                                Tipo_entrega_car = reader.GetString("Tipo_entrega_car"),
                                Cep = reader.GetString("Cep"),
                                Endereco = reader.GetString("Endereco"),
                                Complemento = reader.IsDBNull(reader.GetOrdinal("Complemento")) ? null : reader.GetString("Complemento"),
                                Numero_residencia = reader.GetString("Numero_residencia"),
                                Uf_est = reader.GetString("Uf_est"),
                                Nome_est = reader.GetString("Nome_est")
                            };


                            listaHistorico.Add(historico);
                        }
                    }
                    else
                    {
                        Historico historico = new Historico();
                        listaHistorico.Add(historico);
                    }
                    
                    return listaHistorico;
                }
            }





        }

        public int MudarQuantidade(int id, string operacao)
        {

            switch (operacao)
            {
                case "-":
                    return subQuantidade(id);

                case "+":
                    return incrementQuantidade(id);

                default:
                    Console.WriteLine("Nenhuma das operações de subtração ou incremento foram acionadas. Retornando a Quantidade.");
                    return getCarQuantidade(id);

            }
        }

        private int getCarQuantidade(int id)
        {
            using (var db = new Conexao(_connectionString))
            {
                var Prompt = db.MySqlCommand();
                Prompt.CommandText = $"Select quantidade from Tb_carrinho where Id_carrinho=@ID";
                Prompt.Parameters.AddWithValue("@ID", id);
                using (var reader = Prompt.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetInt32("quantidade");
                    }

                    Console.WriteLine("O Metodo getCarQuantidade não conseguiu obter um valor");
                    return 0;
                }

            }
        }

        private int subQuantidade(int id)
        {
            try
            {
                if (getCarQuantidade(id) > 1)
                {
                    var db = new Conexao(_connectionString);
                    var cmd = db.MySqlCommand();
                    cmd.CommandText = $"update Tb_carrinho set quantidade=quantidade-1 where Id_carrinho=@ID and quantidade>0;";
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                    db.Dispose();
                    Console.WriteLine($" Quantidade do Produto ID: {id} subtraida com sucesso");
                    
                    return getCarQuantidade(id);
                }
                else 
                {
                    return getCarQuantidade(id);
                }

            }catch
            {
                Console.WriteLine($"Ocorreu um erro, o Metodo subQuantidade não conseguiu subtrair a quantidade do produto ID: {id}");
                return getCarQuantidade(id);
            }
        }
        private int incrementQuantidade(int id)
        {
            try
            {
                var db = new Conexao(_connectionString);
                var cmd = db.MySqlCommand();
                cmd.CommandText = $"update Tb_carrinho set quantidade=quantidade+1 where Id_carrinho=@ID;";
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();
                db.Dispose();
                Console.WriteLine($" Quantidade do Produto ID: {id} incrementada com sucesso");
                return getCarQuantidade(id);

            }
            catch
            {
                Console.WriteLine($"Ocorreu um erro, o Metodo incrementQuantidade não conseguiu incrementar a quantidade do produto ID: {id}");
                return getCarQuantidade(id);
            }
        }




    }
}
