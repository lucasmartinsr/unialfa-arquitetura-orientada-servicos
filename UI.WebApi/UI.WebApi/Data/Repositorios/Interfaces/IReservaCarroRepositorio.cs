using System.Collections.Generic;
using UI.WebApi.Dominio;

namespace UI.WebApi.Interfaces
{
    public interface IReservaCarroRepositorio
    {
        IList<ReservaCarro> ObtenhaTodosPorClienteId(long clienteId);
        void Salve(ReservaCarro reservaCarro);
        void Atualize(ReservaCarro reservaCarro);
        void Atualize(IList<ReservaCarro> reservaCarro);
    }
}
