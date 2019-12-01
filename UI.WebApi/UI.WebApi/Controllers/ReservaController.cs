using Microsoft.AspNetCore.Mvc;
using System;
using UI.WebApi.Dominio;
using UI.WebApi.Interfaces;
using UI.WebApi.Utils;

namespace UI.WebApi.Controllers
{
    [Route("api/carro/[controller]")]
    [ApiController]
    public class ReservaController : Controller
    {
        private readonly IReservaCarroServico _reservaCarroServico;
        public ReservaController(IReservaCarroServico reservaCarroServico)
        {
            _reservaCarroServico = reservaCarroServico;
        }

        [HttpPost]
        public IActionResult Reserve([FromBody]ReservaCarro reserva)
        {
            try
            {
                var id = _reservaCarroServico.Adicionar(reserva);
                return Ok(id);
            }
            catch (Exception e)
            {
                return StatusCode(409, new ErroGenerico(CodigoErro.NaoFoiPossivelCriarItem, "Não foi possível reservar!" + e.InnerException)); ;
            }
        }

        [HttpPut("cliente/{clienteId}/status/{status}")]
        public IActionResult Put(long clienteId, StatusReserva status)
        {
            _reservaCarroServico.AlterarStatus(clienteId, status);
            return Ok();
        }

        [HttpGet("cliente/{id}")]
        public IActionResult ObtenhaTodosPorCliente(long id)
        {
            return Ok(_reservaCarroServico.ObtenhaTodosPorCliente(id));
        }

        [HttpGet("preco/cliente/{id}")]
        public IActionResult ObtenhaPreco(long id)
        {
            return Ok(_reservaCarroServico.ObtenhaPreco(id));
        }
    }
}