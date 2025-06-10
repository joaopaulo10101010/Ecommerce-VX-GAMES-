using LojaGames.Models;
using LojaGames.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace LojaGames.Controllers
{
    public class Endereco : Controller
    {

        private readonly ProdutoRepositorio _produtoRepositorio;
        private readonly UsuarioRepositorio _usuarioRepositorio;

        public Endereco(ProdutoRepositorio produtoRepositorio,UsuarioRepositorio usuarioRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult EnderecoLista()
        {
            _produtoRepositorio.listadeprodutoserdados.usuario = _usuarioRepositorio.ObterUsuarioCpf(new Tb_usuario() { Cpf_cli = HttpContext.Session.GetString("cpf") });
            _produtoRepositorio.listadeprodutoserdados.listadeenderecos = _usuarioRepositorio.getEnderecoList(HttpContext.Session.GetString("cpf"));
            return View(_produtoRepositorio.listadeprodutoserdados);
        }



        [HttpPost]
        public IActionResult EnderecoLista(string cep,string numero, string endereco, string complemento, string bairro,string estado,string uf, string localidade)
        {
            string cpf = HttpContext.Session.GetString("cpf");
            _usuarioRepositorio.adicionarEndereco(cpf,cep,numero,uf,endereco,complemento,localidade,bairro,estado);
            _produtoRepositorio.listadeprodutoserdados.listadeenderecos = _usuarioRepositorio.getEnderecoList(HttpContext.Session.GetString("cpf"));
            _produtoRepositorio.listadeprodutoserdados.usuario = _usuarioRepositorio.ObterUsuarioCpf(new Tb_usuario() { Cpf_cli = HttpContext.Session.GetString("cpf") });
            return View(_produtoRepositorio.listadeprodutoserdados);
        }

        public IActionResult ExcluirEndereco(string cep, string numero)
        {
            
            _usuarioRepositorio.ApagarEndereco(cep,numero,HttpContext.Session.GetString("cpf"));
            return RedirectToAction("EnderecoLista", "Endereco");
        }
    }
}
