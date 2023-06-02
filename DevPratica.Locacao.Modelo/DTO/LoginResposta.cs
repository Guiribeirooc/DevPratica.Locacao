using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
