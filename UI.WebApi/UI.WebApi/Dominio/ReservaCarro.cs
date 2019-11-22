using System;
using UI.WebApi.Interfaces;

namespace UI.WebApi.Dominio
{
    public class ReservaCarro : IReserva
    {
        public long Id { get; set; }
        public long ClienteId { get; set; }
        public string ModeloDoVeiculo { get; set; }
        public double Preco { get;set;}
        public StatusReserva Status { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public ReservaCarro(long clienteId, string modeloDoVeiculo, double preco, DateTime dataInicio, DateTime dataFim)
        {
            ClienteId = clienteId;
            ModeloDoVeiculo = modeloDoVeiculo;
            Preco = preco;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Status = StatusReserva.PENDENTE_PAGAMENTO;
        }
        public DateTime ObtenhaDataFinal()
        {
            return DataInicio;
        }

        public DateTime ObtenhaDataInicial()
        {
            return DataFim;
        }

        public string ObtenhaNome()
        {
            return ModeloDoVeiculo;
        }

        public double ObtenhaPreco()
        {
            var quantidadeDeDias = DataFim - DataInicio;
            return Preco * quantidadeDeDias.TotalDays;
        }

        public StatusReserva ObtenhaStatus()
        {
            return Status;
        }
    }
}
