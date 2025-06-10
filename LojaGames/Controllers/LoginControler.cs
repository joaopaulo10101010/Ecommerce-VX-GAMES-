using LojaGames.Models;
using LojaGames.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MySqlX.XDevAPI;

namespace LojaGames.Controllers
{
    public class LoginControler : Controller
    {
        private readonly UsuarioRepositorio _usuarioRepositorio;
        private readonly ProdutoRepositorio _produtoRepositorio;

        public LoginControler(UsuarioRepositorio usuarioRepositorio, ProdutoRepositorio produtoRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _produtoRepositorio = produtoRepositorio;
        }
        

        public IActionResult Cadastro()
        {
            return View(_produtoRepositorio.listadeprodutoserdados);
        }

        public IActionResult Login()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("perfil"))) 
            {
                HttpContext.Session.SetString("perfil", "Entrar na Conta");
            }

            Console.WriteLine(HttpContext.Session.GetString("perfil"));


            if (HttpContext.Session.GetString("perfil") != "Entrar na Conta")
            {
                
                return RedirectToAction("Conta", "Conta");
            }
            else
            {
                return View(_produtoRepositorio.listadeprodutoserdados);
            }
        }



        [HttpPost]
        public IActionResult Cadastro(string nome, string cpf, string usuario, string senha, string email)
        {
            Tb_usuario tb_Usuario = new Tb_usuario();
            tb_Usuario.Cpf_cli = cpf;
            tb_Usuario.Usuario_cli = usuario;
            tb_Usuario.Senha_cli = senha;
            Tb_cliente tb_Cliente = new Tb_cliente();
            tb_Cliente.Cpf_cli = cpf;
            tb_Cliente.Nome_cli = nome;
            Tb_email tb_Email = new Tb_email();
            tb_Email.Cpf_cli = cpf;
            tb_Email.Email = email;

            if (_usuarioRepositorio.ValidarExistenciaUsuario(tb_Usuario) == false)
            {
                _usuarioRepositorio.AdicionarUsuario(tb_Usuario, tb_Cliente, tb_Email);
                return RedirectToAction("Login", "LoginControler");
            }
            else
            {
                HttpContext.Session.SetString("cadastrorep", "CPF ja cadastrado");
                ModelState.AddModelError("", "Esse CPF e esse Usuario ja estao cadastrados");
                return View(_produtoRepositorio.listadeprodutoserdados);
            }




       
        }


        [HttpPost]
        public IActionResult Login(string cpf, string senha)
        {
            Tb_usuario tb_Usuario = new Tb_usuario();
            tb_Usuario.Cpf_cli = cpf;
            tb_Usuario.Senha_cli = senha;

            var usuario = _usuarioRepositorio.ObterUsuarioCpf(tb_Usuario);

            if (usuario != null && tb_Usuario.Senha_cli == usuario.Senha_cli && tb_Usuario.Cpf_cli == usuario.Cpf_cli)
            {
                /* Adicioando os dados na cache*/
                HttpContext.Session.SetString("perfil", usuario.Usuario_cli);
                HttpContext.Session.SetString("nome", _usuarioRepositorio.ObterNome(usuario));
                HttpContext.Session.SetString("email", _usuarioRepositorio.ObterEmail(usuario));
                HttpContext.Session.SetString("cargo_cli", usuario.Cargo_cli);
                HttpContext.Session.SetString("cpf", usuario.Cpf_cli);
                HttpContext.Session.SetString("Pedido", _produtoRepositorio.novoPedido());


                Tb_usuario usuario2 = new Tb_usuario();
                usuario2.Cpf_cli = HttpContext.Session.GetString("cpf");
                _produtoRepositorio.listadeprodutoserdados.usuario = _usuarioRepositorio.ObterUsuarioCpf(usuario2);
                _produtoRepositorio.listadeprodutoserdados.listadohistorico = _produtoRepositorio.getHistorico(usuario2.Cpf_cli);
                _produtoRepositorio.listadeprodutoserdados.listadeprodutos = _produtoRepositorio.ListaProdutos("Xbox");
                _produtoRepositorio.listadeprodutoserdados.listacarrinho = _produtoRepositorio.listaCarrinho(usuario2.Cpf_cli);

                return RedirectToAction("Conta", "Conta"); /* Destino Após o login */
            }
            HttpContext.Session.SetString("logL","Dados de Login Invalidos");
            ModelState.AddModelError("", "Os dados de Login são invalidos.");
            return View(_produtoRepositorio.listadeprodutoserdados);
        }
    }
}
