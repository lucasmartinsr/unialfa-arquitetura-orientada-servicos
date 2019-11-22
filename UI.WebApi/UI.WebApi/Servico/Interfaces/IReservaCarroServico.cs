using System.Collections.Generic;
using UI.WebApi.Dominio;

namespace UI.WebApi.Interfaces
{
    public interface IReservaCarroServico
    {
        long Adicionar(ReservaCarro reserva);
        IEnumerable<object> ObtenhaTodosPorCliente(long clienteId);
        double ObtenhaPreco(long clinteId);
        void AlterarStatus(long clienteId, StatusReserva status);
    }
}
