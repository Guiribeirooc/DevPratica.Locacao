using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevPratica.Locacao.Modelo
{
    public class Fornecedor : Endereco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "Este campo deve ter 18 Caracteres.")]
        public string CNPJ { get; set; } = "";

        [Required(ErrorMessage = "A Razão Social é obrigatório.")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Este campo deve ter no minimo 5 e no máximo 150 Caracteres.")]
        public string RazaoSocial { get; set; } = "";

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "Este campo deve ter 14 Caracteres.")]
        public string Telefone { get; set; }

        [StringLength(150, ErrorMessage = "Este campo deve ter no máximo 150 Caracteres.")]
        public string? Email { get; set; } = "";

        public DateTime DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }
    }
}
