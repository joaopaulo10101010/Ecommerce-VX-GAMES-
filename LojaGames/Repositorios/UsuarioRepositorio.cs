using MySql.Data.MySqlClient;
using LojaGames.Models;
using System.Configuration;
using System.Data;
using LojaGames.Repositorios;
using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;


namespace LojaGames.Repositorios
{
    public class UsuarioRepositorio(IConfiguration configuration)
    {

        private readonly string _connectionString = configuration.GetConnectionString("MySQLConnection");

        public IEnumerable<Tb_endereco> getEnderecoList(string cpf)
        {
            return ReceberEnderecos(cpf);
        }

        private IEnumerable<Tb_endereco> ReceberEnderecos(string cpf)
        {
            using (var db = new Conexao(_connectionString))
            {

                List<Tb_endereco> listacarrinho = new List<Tb_endereco>();
                var Prompt = db.MySqlCommand();
                Prompt.CommandText = $"Select * from Tb_endereco where Cpf_cli={cpf}";
                using (var reader = Prompt.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.IsDBNull("Complemento"))
                        {
                            Tb_endereco carrinho1 = new Tb_endereco
                            {
                                Cep = reader.GetString("Cep"),
                                Numero_residencia = reader.GetString("Numero_residencia"),
                                Uf_est = reader.GetString("Uf_est"),
                                Endereco = reader.GetString("Endereco"),
                                Complemento = "",
                            };
                            listacarrinho.Add(carrinho1);
                        }
                        else
                        {
                            Tb_endereco carrinho = new Tb_endereco
                            {
                                Cep = reader.GetString("Cep"),
                                Numero_residencia = reader.GetString("Numero_residencia"),
                                Uf_est = reader.GetString("Uf_est"),
                                Endereco = reader.GetString("Endereco"),
                                Complemento = reader.GetString("Complemento"),
                            };

                            listacarrinho.Add(carrinho);
                        }
                            
                    }

                    return listacarrinho;
                }

            }
        }

        private bool adicionarEstado(string uf, string nome)
        {
            try
            {
                var banco = new Conexao(_connectionString);
                var query = banco.MySqlCommand();

                query.CommandText = "Select * from Tb_estado where Uf_est=@uf";
                query.Parameters.AddWithValue("@uf", uf);
                using (var reader = query.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return true;
                    }
                }
                query.Parameters.Clear();
                query.CommandText = $"insert into Tb_estado(Uf_est,Nome_est) values(@uf,@nome)";
                query.Parameters.AddWithValue("@uf",uf);
                query.Parameters.AddWithValue("@nome", nome);
                query.ExecuteNonQuery();
                banco.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool adicionarCep(string cep, string cidade, string bairro)
        {
            try
            {
                var banco = new Conexao(_connectionString);
                var query = banco.MySqlCommand();

                query.CommandText = "Select * from Tb_cep where Cep=@cep";
                query.Parameters.AddWithValue("@cep", cep);
                using (var reader = query.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return true;
                    }
                }
                query.Parameters.Clear();
                query.CommandText = $"insert into Tb_cep(Cep,Bairro,Cidade) values(@cep,@bairro,@cidade)";
                query.Parameters.AddWithValue("@cep", cep);
                query.Parameters.AddWithValue("@bairro", bairro);
                query.Parameters.AddWithValue("@cidade", cidade);
                query.ExecuteNonQuery();
                banco.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void adicionarEndereco(string cpf, string cep,string numero,string uf,string endereco, string complemento, string cidade, string bairro,string estado)
        {
            try
            {
                if (adicionarEstado(uf, estado))
                {
                    Console.WriteLine("Estado Adicionado com Sucesso");
                }
                else
                {
                    Console.WriteLine("O Estado nao pode ser adicionado ao banco");
                }
                if (adicionarCep(cep, cidade, bairro))
                {
                    Console.WriteLine("Novo Cep cadastrado no banco com sucesso");
                }
                else
                {
                    Console.WriteLine("O Cep nao pode ser adicionado ao banco");
                }

                var banco = new Conexao(_connectionString);
                var query = banco.MySqlCommand();

                query.CommandText = $"insert into Tb_endereco(Cpf_cli,Cep,Numero_residencia,Uf_est,Endereco,Complemento) values(@cpf,@cep,@numero,@uf,@endereco,@complemento);";
                query.Parameters.AddWithValue("@cpf", cpf);
                query.Parameters.AddWithValue("@cep", cep);
                query.Parameters.AddWithValue("@numero", numero);
                query.Parameters.AddWithValue("@uf", uf);
                query.Parameters.AddWithValue("@endereco", endereco);
                query.Parameters.AddWithValue("@complemento", complemento);
                Console.WriteLine("Novo Endereco cadastrado com sucesso");
                query.ExecuteNonQuery();
                banco.Dispose();
            }
            catch
            {
                Console.WriteLine("Nao foi possivel cadastrar o endereco");
            }
        }

        public void AdicionarUsuario(Tb_usuario usuario, Tb_cliente cliente, Tb_email email)
        {
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();

                cmd.CommandText = "INSERT INTO Tb_cliente (Cpf_cli, Nome_cli) VALUES (@Cpf,@Nome)";
                cmd.Parameters.AddWithValue("@Cpf", cliente.Cpf_cli);
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome_cli);
                cmd.ExecuteNonQuery();

            }
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();

                cmd.CommandText = "INSERT INTO Tb_usuario (Cpf_cli, Usuario_cli, Senha_cli) VALUES (@Cpf,@Usuario,@Senha)";
                cmd.Parameters.AddWithValue("@Cpf", usuario.Cpf_cli);
                cmd.Parameters.AddWithValue("@Usuario", usuario.Usuario_cli);
                cmd.Parameters.AddWithValue("@Senha", usuario.Senha_cli);
                cmd.ExecuteNonQuery();

            }
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();

                cmd.CommandText = "INSERT INTO Tb_email (Cpf_cli, Email) VALUES (@Cpf,@Email)";
                cmd.Parameters.AddWithValue("@Cpf", email.Cpf_cli);
                cmd.Parameters.AddWithValue("@Email", email.Email);
                cmd.ExecuteNonQuery();

            }
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();

                cmd.CommandText = "INSERT INTO Tb_telefone (Cpf_cli) VALUES (@Cpf)";
                cmd.Parameters.AddWithValue("@Cpf", email.Cpf_cli);
                cmd.ExecuteNonQuery();

            }
        }

        public bool ValidarExistenciaUsuario(Tb_usuario tb_Usuario)
        {
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();
                cmd.CommandText = "SELECT * FROM Tb_usuario WHERE Cpf_cli = @Cpf";
                cmd.Parameters.AddWithValue("@Cpf", tb_Usuario.Cpf_cli);
                cmd.ExecuteNonQuery();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var usuariobanco = new Tb_usuario
                        {
                            Cpf_cli = reader.GetString("Cpf_cli"),
                            Usuario_cli = reader.GetString("Usuario_cli"),
                        };
                        if (tb_Usuario.Cpf_cli == usuariobanco.Cpf_cli || tb_Usuario.Usuario_cli == usuariobanco.Usuario_cli)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }

        }

        
        public Tb_usuario ObterUsuarioCpf(Tb_usuario tb_Usuario)
        {
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();
                cmd.CommandText = "SELECT t1.*, t2.Email, t3.DD,t3.Telefone,t4.Nome_cli FROM Tb_usuario t1 left join Tb_Email t2 on t1.Cpf_cli = t2.Cpf_cli left join Tb_telefone t3 on t1.Cpf_cli = t3.Cpf_cli left join Tb_cliente t4 on t1.Cpf_cli = t4.Cpf_cli where t1.Cpf_cli = @Cpf;";
                cmd.Parameters.AddWithValue("@Cpf", tb_Usuario.Cpf_cli);
                cmd.ExecuteNonQuery();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Tb_usuario
                        {
                            Cpf_cli = reader.GetString("Cpf_cli"),
                            Usuario_cli = reader.GetString("Usuario_cli"),
                            Senha_cli = reader.GetString("Senha_cli"),
                            Cargo_cli = reader.GetString("Cargo_cli"),
                            Ativo_cli = reader.GetBoolean("Ativo_cli"),
                            Img_caminho = reader.GetString("Img_caminho"),
                            telefones = new Tb_telefone { DD = reader.GetString("DD"), Telefone = reader.GetString("Telefone") },
                            Nome = reader.GetString("Nome_cli"),
                            Email = reader.GetString("Email"),
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
        public Tb_usuario ObterUsuarioUsu(Tb_usuario tb_Usuario)
        {
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();
                cmd.CommandText = "SELECT * FROM Tb_usuario WHERE Usuario_cli = @Usuario";
                cmd.Parameters.AddWithValue("@Usuario", tb_Usuario.Usuario_cli);
                cmd.ExecuteNonQuery();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Tb_usuario
                        {
                            Cpf_cli = reader.GetString("Cpf_cli"),
                            Usuario_cli = reader.GetString("Usuario_cli"),
                            Senha_cli = reader.GetString("Senha_cli"),
                            Cargo_cli = reader.GetString("Cargo_cli"),
                            Ativo_cli = reader.GetBoolean("Ativo_cli"),
                            Img_caminho = reader.GetString("Img_caminho"),
                        };
                    }
                }
                return new Tb_usuario();
            }
        }
        public string ObterEmail(Tb_usuario tb_Usuario)
        {
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();
                cmd.CommandText = "SELECT * FROM Tb_Email WHERE Cpf_cli = @Cpf";
                cmd.Parameters.AddWithValue("@Cpf", tb_Usuario.Cpf_cli);
                cmd.ExecuteNonQuery();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetString("Email");
                    }
                    else
                    {
                        return "nenhum Email";
                    }
                }
            }
        }
        public string ObterNome(Tb_usuario tb_Usuario)
        {
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();
                cmd.CommandText = "SELECT * FROM Tb_cliente WHERE Cpf_cli = @Cpf";
                cmd.Parameters.AddWithValue("@Cpf", tb_Usuario.Cpf_cli);
                cmd.ExecuteNonQuery();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetString("Nome_cli");
                    }
                    else
                    {
                        return "nenhum Nome";
                    }
                }
            }
        }





        public bool enviarImgBD(byte[] imgbyte,string cpf)
        {
            try
            {
                var db = new Conexao(_connectionString);
                var query = db.MySqlCommand();
                query.CommandText = $"Update Tb_usuario Set Img_path=@arquivo where Cpf_cli=@Cpf;";
                query.Parameters.AddWithValue("@Cpf", cpf);
                query.Parameters.AddWithValue("@arquivo", imgbyte);
                query.ExecuteNonQuery();
                return true;
            }
            catch
            {
                Console.WriteLine("Não foi possivel colocar a imagem no banco");
                return false;
            }
        }

        public void ApagarEndereco(string cep, string numero, string cpf)
        {
            Console.WriteLine($"Cep: {cep} Numero: {numero} CPF: {cpf}");

            try
            {
                var db = new Conexao(_connectionString);
                var query = db.MySqlCommand();
                query.CommandText = @"UPDATE tb_carrinho SET Cep = NULL, Numero_residencia = NULL WHERE Cep = @Cep AND Numero_residencia = @Numero AND Cpf_cli = @Cpf;";
                query.Parameters.AddWithValue("@Cpf", cpf);
                query.Parameters.AddWithValue("@Numero", numero);
                query.Parameters.AddWithValue("@Cep", cep);
                query.ExecuteNonQuery();
                db.Dispose();
            }
            catch
            {
                Console.WriteLine("a Tb_carrinho nao foi atualizada");
            }

            try
            {
                var db = new Conexao(_connectionString);
                var query = db.MySqlCommand();
                query.CommandText = @"DELETE FROM Tb_endereco WHERE Cpf_cli = @Cpf AND Cep = @Cep AND Numero_residencia = @Numero;";
                query.Parameters.AddWithValue("@Cpf", cpf);
                query.Parameters.AddWithValue("@Numero", numero);
                query.Parameters.AddWithValue("@Cep", cep);
                query.ExecuteNonQuery();
                db.Dispose();
            }
            catch
            {
                Console.WriteLine("Endereço nao foi excluído");
            }
        }


        public string salvarByteLocal(byte[] bytes,string nome,string formato)
        {
            try
            {
                string nomedoarquivo = $"{nome}."+formato;
                string caminhoFinal = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", "image", "fromdb", nomedoarquivo);
                System.IO.File.WriteAllBytes(caminhoFinal, bytes);
                string caminhoParaRetorno = "/assets/image/fromdb/" + nomedoarquivo;
                return caminhoParaRetorno;
            }
            catch
            {
                Console.WriteLine("Erro ao salvar localmente a imagem");
                return "erro";
            }
        }

        public byte[] receberImgBD(string cpf)
        {
            try
            {
                var db = new Conexao(_connectionString);
                var cmd = db.MySqlCommand();
                cmd.CommandText = "select img_path from Tb_usuario where Cpf_cli = @cpf";
                cmd.Parameters.AddWithValue("@cpf", cpf);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader["Img_path"] as byte[];
                    }
                }

                return null;
            }
            catch
            {
                Console.WriteLine("Não foi possivel obter a imagem do banco");
                return null;
            }
        }

        public void salvarCaminhoBd(string caminho,string cpf)
        {
            try
            {
                var db = new Conexao(_connectionString);
                var query = db.MySqlCommand();
                query.CommandText = @"UPDATE Tb_usuario SET Img_caminho = @caminho WHERE Cpf_cli = @Cpf;";
                query.Parameters.AddWithValue("@caminho", caminho);
                query.Parameters.AddWithValue("@Cpf", cpf);
                query.ExecuteNonQuery();
                db.Dispose();
            }
            catch
            {
                Console.WriteLine("O caminho da imagem nao foi atualizada");
            }
        }


        public bool atualizarUsuario(Tb_usuario tb_Usuario)
        {
            try
            {
                using (var db = new Conexao(_connectionString))
                {
                    var query = db.MySqlCommand();
                    query.CommandText = @"UPDATE Tb_usuario SET Usuario_cli = @usuario, Senha_cli = @senha WHERE Cpf_cli = @Cpf;";
                    query.Parameters.AddWithValue("@Cpf", tb_Usuario.Cpf_cli);
                    query.Parameters.AddWithValue("@senha", tb_Usuario.Senha_cli);
                    query.Parameters.AddWithValue("@usuario", tb_Usuario.Usuario_cli);
                    query.ExecuteNonQuery();
                    db.Dispose();
                }

                using (var db = new Conexao(_connectionString))
                {
                    var query = db.MySqlCommand();
                    query.CommandText = @"UPDATE Tb_email SET Email = @Email WHERE Cpf_cli = @Cpf;";
                    query.Parameters.AddWithValue("@Email", tb_Usuario.Email);
                    query.Parameters.AddWithValue("@Cpf", tb_Usuario.Cpf_cli);
                    query.ExecuteNonQuery();
                    db.Dispose();
                }

                using (var db = new Conexao(_connectionString))
                {
                    var query = db.MySqlCommand();
                    query.CommandText = @"UPDATE Tb_cliente SET Nome_cli = @Nome_cli WHERE Cpf_cli = @Cpf;";
                    query.Parameters.AddWithValue("@Nome_cli", tb_Usuario.Nome);
                    query.Parameters.AddWithValue("@Cpf", tb_Usuario.Cpf_cli);
                    query.ExecuteNonQuery();
                    db.Dispose();
                }

                using (var db = new Conexao(_connectionString))
                {
                    var query = db.MySqlCommand();
                    query.CommandText = @"UPDATE Tb_telefone SET Telefone = @Telefone, DD=@DD WHERE Cpf_cli = @Cpf;";
                    query.Parameters.AddWithValue("@Telefone", tb_Usuario.telefones.Telefone);
                    query.Parameters.AddWithValue("@DD", tb_Usuario.telefones.DD);
                    query.Parameters.AddWithValue("@Cpf", tb_Usuario.Cpf_cli);
                    query.ExecuteNonQuery();
                    db.Dispose();
                }
                return true;
            }
            catch
            {
                Console.WriteLine("Ocorreu um erro ao Atualizar os dados no metodo: atualizarUsuario");
                return false;
            }
        }


        public Tb_telefone ExtrairTelefone(string entrada)
        {
            var resultado = new Tb_telefone();

            // Remove qualquer caractere que não seja número
            entrada = new string(entrada.Where(char.IsDigit).ToArray());

            // Verifica se tem pelo menos 10 ou 11 dígitos (DDD + número)
            if (entrada.Length >= 10 && entrada.Length <= 11)
            {
                resultado.DD = entrada.Substring(0, 2);
                resultado.Telefone = entrada.Substring(2);
            }

            return resultado;
        }

    }
}