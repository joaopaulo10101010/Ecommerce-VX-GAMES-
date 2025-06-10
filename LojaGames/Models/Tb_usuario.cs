namespace LojaGames.Models
{
    public class Tb_usuario
    {
        public string? Cpf_cli {  get; set; }
        public string? Usuario_cli { get; set; }
        public string? Senha_cli { get; set; }
        public string? Cargo_cli { get; set; }

        public string? Img_caminho { get; set; } = "/assets/image/perfil-de-usuario.png";
        public Tb_telefone telefones { get; set; }


        public void alterarEmail(string email)
        {
            Email = email;
        }
        public void alterarNome(string nome)
        {
            Nome = nome;
        }
        public string? Email { get; set; }
        public string? Nome { get; set; }
        public bool Ativo_cli { get; set; }
    }
}
