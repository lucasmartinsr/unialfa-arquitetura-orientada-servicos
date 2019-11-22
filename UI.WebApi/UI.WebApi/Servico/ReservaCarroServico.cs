using System.Collections.Generic;
using System.Linq;
using UI.WebApi.Dominio;
using UI.WebApi.Interfaces;

namespace UI.WebApi.Servico
{
    public class ReservaCarroServico : IReservaCarroServico
    {
        private readonly IReservaCarroRepositorio _reservaCarroRepositorio;
        public ReservaCarroServico(IReservaCarroRepositorio reservaCarroRepositorio)
        {
            _reservaCarroRepositorio = reservaCarroRepositorio;
        }
        public long Adicionar(ReservaCarro reserva)
        {
            var novaReserva = new ReservaCarro(reserva.ClienteId, reserva.ModeloDoVeiculo, reserva.Preco, reserva.DataInicio, reserva.DataFim);
            _reservaCarroRepositorio.Salve(novaReserva);
            return novaReserva.Id;
        }

        public void AlterarStatus(long clienteId, StatusReserva status)
        {
            var reservas = _reservaCarroRepositorio.ObtenhaTodosPorClienteId(clienteId);
            foreach (var reserva in reservas)
            {
                reserva.Status = status;
            }
            _reservaCarroRepositorio.Atualize(reservas);
        }

        public double ObtenhaPreco(long clienteId)
        {
            var reservas = _reservaCarroRepositorio.ObtenhaTodosPorClienteId(clienteId);
            return reservas.Sum(r => r.ObtenhaPreco());
        }

        public IEnumerable<object> ObtenhaTodosPorCliente(long clienteId)
        {
            return _reservaCarroRepositorio.ObtenhaTodosPorClienteId(clienteId).Select(r => new { Id = r.Id, ModeloDoVeiculo = r.ModeloDoVeiculo, Status= (int)r.Status});
        }
    }
}
