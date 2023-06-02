using DevPratica.Locacao.Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevPratica.Locacao.Negocio.GeradorTokenNegocio
{
    public interface IGeradorTokenNegocio
    {
        Task<LoginResposta> GerarToken(LoginResposta loginResposta);
    }
}
