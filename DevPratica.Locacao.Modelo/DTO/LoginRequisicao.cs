using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
