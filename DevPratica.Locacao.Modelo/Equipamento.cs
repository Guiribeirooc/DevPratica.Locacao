using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevPratica.Locacao.Modelo
{
    public class Equipamento
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "A Descrição é obrigatória.")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Este campo deve ter no minimo 5 e no máximo 200 Caracteres.")]
        public string Descricao { get; set; } = "";

        [Required(ErrorMessage = "Os Detalhes são obrigatórios.")]
        [StringLength(2000, MinimumLength = 5, ErrorMessage = "Este campo deve ter no minimo 5 e no máximo 2000 Caracteres.")]
        public string Detalhes { get; set; } = "";

        [Required(ErrorMessage = "Campo VALOR deve ser preenchido.")]
        public decimal Valor { get; set; }

        public DateTime DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }
    }
}
