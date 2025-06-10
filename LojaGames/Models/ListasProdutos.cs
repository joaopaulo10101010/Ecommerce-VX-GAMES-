using System.Reflection.PortableExecutable;

namespace LojaGames.Models
{
    public class ListasProdutos
    {
        public IEnumerable<Tb_produto>? listadeprodutos { get; set; }
        public IEnumerable<Tb_endereco>? listadeenderecos { get; set; }
        public IEnumerable<Tb_carrinho>? listacarrinho { get; set; }
        public IEnumerable<Historico> listadohistorico { get; set; } = new List<Historico>() { new Historico(), };
        public Tb_usuario usuario { get; set; } = new Tb_usuario();

        public string numerocartao { get; set; }
        public string datacartao { get; set; }
        public string cvccartao { get; set; }
        public string formulario { get; set; }
        public string nomecartao { get; set; }

    }
}
