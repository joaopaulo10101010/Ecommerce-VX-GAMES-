using Microsoft.AspNetCore.Mvc;
using LojaGames.Repositorios;
using LojaGames.Models;
using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Components.RenderTree;

namespace LojaGames.Controllers
{
    public class ProcuraControler : Controller
    {
        private readonly ProdutoRepositorio _produtoRepositorio;
        private readonly UsuarioRepositorio _usuarioRepositorio;

        public ProcuraControler(ProdutoRepositorio produtoRepositorio,UsuarioRepositorio usuarioRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }


        [HttpPost]
        public IActionResult Quantidade([FromBody] JsReceptor js)
        {
            Console.WriteLine($"o ID = {js.id} e a ação é: {js.acao}");

            


            return Json(new {quantidadefinal = Convert.ToString(_produtoRepositorio.MudarQuantidade(Convert.ToInt32(js.id),js.acao))});
        }

        public IActionResult Procura(string pesquisa)
        {
            if (pesquisa == null) { pesquisa = "Xbox"; }


            HttpContext.Session.SetString("redirecionarpesquisa", pesquisa);
            _produtoRepositorio.listadeprodutoserdados.listadeprodutos = _produtoRepositorio.ListaProdutos(pesquisa);

            if (HttpContext.Session.GetString("perfil") != "Entrar na Conta" && string.IsNullOrEmpty(HttpContext.Session.GetString("perfil")) == false)
            {
                _produtoRepositorio.listadeprodutoserdados.listacarrinho = _produtoRepositorio.listaCarrinho(HttpContext.Session.GetString("Pedido"));
                _produtoRepositorio.listadeprodutoserdados.usuario = _usuarioRepositorio.ObterUsuarioCpf(new Tb_usuario() { Cpf_cli = HttpContext.Session.GetString("cpf")});
            }
            return View(_produtoRepositorio.listadeprodutoserdados);
        }

        [HttpPost]
        public IActionResult adicionarCarrinho(string Id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("perfil")) || HttpContext.Session.GetString("perfil") == "Entrar na Conta")
            {
                return RedirectToAction("Login", "LoginControler");
            }
            else
            {
                Tb_produto produto = _produtoRepositorio.ObterProduto(Convert.ToInt32(Id));

                Tb_carrinho carrinho = new Tb_carrinho
                {
                    Cpf_cli = HttpContext.Session.GetString("cpf"),
                    Id_pedido = Convert.ToInt32(HttpContext.Session.GetString("Pedido")),
                    Id_prod = produto.Id_prod,
                    preco_prod = produto.ValorVenda_prod,
                    Id_pag = 1,
                    quantidade = 1,
                };

                _produtoRepositorio.carrinhoNovoProd(carrinho);

                return RedirectToAction("Procura");
            }
        }




    }
}
