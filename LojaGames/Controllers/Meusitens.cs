using LojaGames.Models;
using LojaGames.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace LojaGames.Controllers
{
    public class Meusitens : Controller
    {
        private readonly ProdutoRepositorio _produtoRepositorio;
        private readonly UsuarioRepositorio _usuarioRepositorio;


        public Meusitens(ProdutoRepositorio produtoRepositorio,UsuarioRepositorio usuarioRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listamenu() 
        {
            _produtoRepositorio.listadeprodutoserdados.usuario = _usuarioRepositorio.ObterUsuarioCpf(new Tb_usuario() { Cpf_cli = HttpContext.Session.GetString("cpf") });
            _produtoRepositorio.listadeprodutoserdados.listadohistorico = _produtoRepositorio.getHistorico(HttpContext.Session.GetString("cpf"));
            _produtoRepositorio.listadeprodutoserdados.listadeprodutos = _produtoRepositorio.ListaProdutos("Xbox");
            _produtoRepositorio.listadeprodutoserdados.listacarrinho = _produtoRepositorio.listaCarrinho(HttpContext.Session.GetString("Pedido"));
            return View(_produtoRepositorio.listadeprodutoserdados);
        
        }
    }
}
