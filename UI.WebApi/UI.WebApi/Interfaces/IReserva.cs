using System;
using UI.WebApi.Dominio;

namespace UI.WebApi.Interfaces
{
    public interface IReserva
    {
        string ObtenhaNome();
        double ObtenhaPreco();
        StatusReserva ObtenhaStatus();
        DateTime ObtenhaDataInicial();
        DateTime ObtenhaDataFinal();
    }
}
