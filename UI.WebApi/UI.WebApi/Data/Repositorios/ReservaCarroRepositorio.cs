using System.Collections.Generic;
using System.Linq;
using UI.WebApi.Dominio;
using UI.WebApi.Interfaces;
using static UI.WebApi.Data.Context.ReservaCarroContexto;

namespace UI.WebApi.Data.Repositorios
{
    public class ReservaCarroRepositorio: IReservaCarroRepositorio
    {
        private readonly StoreDataContext _dataContext;

        public ReservaCarroRepositorio(StoreDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Atualize(ReservaCarro reservaCarro)
        {
            _dataContext.ReservasCarro.Update(reservaCarro);
            _dataContext.SaveChanges();
        }

        public void Atualize(IList<ReservaCarro> reservaCarro)
        {
            _dataContext.ReservasCarro.UpdateRange(reservaCarro);
            _dataContext.SaveChanges();
        }

        public IList<ReservaCarro> ObtenhaTodosPorClienteId(long clienteId)
        {
            return _dataContext.ReservasCarro.Where(r => r.ClienteId == clienteId).ToList();
        }

        public void Salve(ReservaCarro reservaCarro)
        {
            _dataContext.ReservasCarro.Add(reservaCarro);
            _dataContext.SaveChanges();
        }
    }
}
