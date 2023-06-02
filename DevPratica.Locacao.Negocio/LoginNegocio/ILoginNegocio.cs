using DevPratica.Locacao.Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevPratica.Locacao.Negocio.LoginNegocio
{
    public interface ILoginNegocio
    {
        Task<LoginResposta> Login(LoginRequisicao loginRequisicao);
    }
}
