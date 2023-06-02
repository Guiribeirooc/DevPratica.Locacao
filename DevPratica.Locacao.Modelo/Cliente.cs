using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevPratica.Locacao.Modelo
{
    public class Cliente : Endereco
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "Este campo deve ter 14 Caracteres.")]
        public string CPF { get; set; } = "";

        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Este campo deve ter no minimo 5 e no máximo 150 Caracteres.")]
        public string Nome { get; set; } = "";

        [StringLength (14, ErrorMessage = "Este campo deve ter no máximo 14 Caracteres.")]
        public string? Telefone { get; set; }

        [Required(ErrorMessage = "O Celular é obrigatório.")]
        [StringLength(15, MinimumLength = 15, ErrorMessage = "Este campo deve ter 15 Caracteres.")]
        public string Celular { get; set; } = "";

        [StringLength(150, ErrorMessage = "Este campo deve ter no máximo 150 Caracteres.")]
        public string? Email { get; set; } = "";

        [Required(ErrorMessage = "A Data de Nascimento é obrigatório.")]
        public DateTime DataNascimento { get; set; }

        public DateTime DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }
    }
}
