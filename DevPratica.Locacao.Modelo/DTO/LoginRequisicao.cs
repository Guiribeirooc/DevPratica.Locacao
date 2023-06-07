using System.ComponentModel.DataAnnotations;

namespace DevPratica.Locacao.Modelo.DTO
{
    public class LoginRequisicao
    {
        [Required]
        public string Usuario { get; set; } = "";

        [Required]
        public string Senha { get; set; } = "";
    }
}
