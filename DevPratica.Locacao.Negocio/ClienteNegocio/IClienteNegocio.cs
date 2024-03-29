﻿using DevPratica.Locacao.Modelo;

namespace DevPratica.Locacao.Negocio.ClienteNegocio
{
    public interface IClienteNegocio
    {
        Task Incluir(Cliente cliente);
        Task<Cliente> ObterPorCPF(string cpf);
        Task<List<Cliente>> ObterLista();
        Task Alterar(Cliente cliente);
        Task EmailEnviado(string cpf);
        Task<List<Cliente>> ObterListaEmailNaoEnviados();
    }
}
