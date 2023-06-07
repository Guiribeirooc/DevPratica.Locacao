using System.ComponentModel.DataAnnotations;

namespace DevPratica.Locacao.Modelo
{
    public class Endereco
    {
        [Required(ErrorMessage = "O Logradouro é obrigatório.")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Este campo deve ter no minimo 5 e no máximo 150 Caracteres.")]
        public string Logradrouro { get; set; }

        [Required(ErrorMessage = "O Numero é obrigatório.")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Este campo deve ter no minimo 1 e no máximo 10 Caracteres.")]
        public string Numero { get; set; }

        [StringLength(100, ErrorMessage = "Este campo deve ter no máximo 100 Caracteres.")]
        public string? Complemento { get; set; }

        [Required(ErrorMessage = "O Bairro é obrigatório.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Este campo deve ter no minimo 2 e no máximo 50 Caracteres.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "A Cidade é obrigatório.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Este campo deve ter no minimo 2 e no máximo 100 Caracteres.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O Estado é obrigatório.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Este campo deve ter 2 Caracteres.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Este campo deve ter 9 Caracteres.")]
        public string CEP { get; set; }
    }
}
