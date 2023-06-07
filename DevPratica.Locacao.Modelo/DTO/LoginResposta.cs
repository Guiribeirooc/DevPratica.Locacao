namespace DevPratica.Locacao.Modelo.DTO
{
    public class LoginResposta
    {
        public string Usuario { get; set; } = "";   
        public bool Autenticado { get; set; }
        public string Token { get; set; } = "";
        public DateTime? DataExpiracao { get; set; }
    }
}
