namespace LojaGames.Models
{
    public class Tb_carrinho
    {
        public int Id_carrinho { get; set; }
        public string? Cpf_cli { get; set; }
        public int Id_pedido { get; set; }
        public Tb_produto tb_Produto { get; set; }
        public int Id_prod { get; set; }
        public int Id_pag { get; set; }
        public decimal preco_prod { get; set; }
        public DateOnly Data_pedido_car { get; set; }
        public DateOnly Data_entrega_car { get; set; }
        public string? Tipo_entrega_car { get; set; }
        public string? Cep { get; set; }
        public string? Numero_residencia { get; set; }
        public int quantidade { get; set; }


    }
}
