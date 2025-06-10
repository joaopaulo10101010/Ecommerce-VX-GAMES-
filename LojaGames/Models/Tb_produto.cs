using System.ComponentModel.DataAnnotations;

namespace LojaGames.Models
{
    public class Tb_produto
    {
        public int Id_prod {  get; set; }
        public string? Nome_prod { get; set; } = "Produto sem nome";
        public string? Descricao_prod { get; set; } = "Produto sem Descricao";
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]  /* Isso e para colocar em R$ *.***,** */
        public decimal ValorCusto_prod { get; set; } = 0;
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal ValorVenda_prod { get; set; } = 0;
        public decimal Desconto_prod { get; set; } = 1;
        public string? Tipo_prod { get; set; } = "Produto sem tipo";
        public string? Marca_prod { get; set; } = "Sem marca registrada";
        public int QuantidadeEstoque_prod { get; set; } = 0;
        public string? img_path { get; set; } = "~/assets/image/icones/404.svg";
        public bool VendaDisponivel_prod { get; set; } = true;
    }
}
