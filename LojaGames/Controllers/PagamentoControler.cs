using LojaGames.Models;
using LojaGames.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace LojaGames.Controllers
{
    public class PagamentoControler : Controller
    {
        private readonly ProdutoRepositorio _produtoRepositorio;
        private readonly UsuarioRepositorio _usuarioRepositorio;

        public PagamentoControler(ProdutoRepositorio produtoRepositorio, UsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _produtoRepositorio = produtoRepositorio;
        }



        public IActionResult Pagamento()
        {
            HttpContext.Session.SetString("back", "Pagamento");
            _produtoRepositorio.listadeprodutoserdados.usuario = _usuarioRepositorio.ObterUsuarioCpf(new Tb_usuario() { Cpf_cli = HttpContext.Session.GetString("cpf") });
            _produtoRepositorio.listadeprodutoserdados.listadeenderecos = _usuarioRepositorio.getEnderecoList(HttpContext.Session.GetString("cpf"));
            _produtoRepositorio.listadeprodutoserdados.listadeprodutos = _produtoRepositorio.ListaProdutos("Xbox");
            _produtoRepositorio.listadeprodutoserdados.listacarrinho = _produtoRepositorio.listaCarrinho(HttpContext.Session.GetString("Pedido"));
            return View(_produtoRepositorio.listadeprodutoserdados);
        }

        [HttpPost]
        public IActionResult Pagamento(string numerocartao, string datacartao, string cvccartao, string formulario, string nomecartao, string cepSelecionado, string numeroSelecionado)
        {
            if (string.IsNullOrEmpty(cepSelecionado) || string.IsNullOrEmpty(numeroSelecionado))
            {
                Tb_usuario usuario = new Tb_usuario();
                usuario.Cpf_cli = HttpContext.Session.GetString("cpf");
                _produtoRepositorio.listadeprodutoserdados.usuario = _usuarioRepositorio.ObterUsuarioCpf(usuario);
                _produtoRepositorio.listadeprodutoserdados.listadohistorico = _produtoRepositorio.getHistorico(usuario.Cpf_cli);
                _produtoRepositorio.listadeprodutoserdados.listadeprodutos = _produtoRepositorio.ListaProdutos("Xbox");
                _produtoRepositorio.listadeprodutoserdados.listacarrinho = _produtoRepositorio.listaCarrinho(HttpContext.Session.GetString("Pedido"));
                _produtoRepositorio.listadeprodutoserdados.listadeenderecos = _usuarioRepositorio.getEnderecoList(HttpContext.Session.GetString("cpf"));
                HttpContext.Session.SetString("retornopag","Selecione um Endereço para realizar a sua compra");


                return View(_produtoRepositorio.listadeprodutoserdados);
            }
            else
            {
                HttpContext.Session.SetString("retornopag", "");
                string pedido = HttpContext.Session.GetString("Pedido");
                switch (formulario)
                {
                    case "cartaocredito":
                        _produtoRepositorio.registrarPagCred(pedido, numerocartao, nomecartao, cepSelecionado, numeroSelecionado);
                        HttpContext.Session.SetString("Pedido", _produtoRepositorio.novoPedido());

                        return RedirectToAction("Conta", "Conta");

                    case "cartaodebito":
                        _produtoRepositorio.registrarPagDebt(pedido, numerocartao, nomecartao, cepSelecionado, numeroSelecionado);
                        HttpContext.Session.SetString("Pedido", _produtoRepositorio.novoPedido());

                        return RedirectToAction("Conta", "Conta");

                    case "boleto":
                        _produtoRepositorio.registrarPagBoleto(pedido, cepSelecionado, numeroSelecionado);
                        HttpContext.Session.SetString("Pedido", _produtoRepositorio.novoPedido());

                        return RedirectToAction("Conta", "Conta");

                    case "qrcode":
                        _produtoRepositorio.registrarPagQrcode(pedido, cepSelecionado, numeroSelecionado);
                        HttpContext.Session.SetString("Pedido", _produtoRepositorio.novoPedido());

                        return RedirectToAction("Conta", "Conta");

                    default:
                        return RedirectToAction("Conta", "Conta");
                }
            }
                

        }






    }
}
