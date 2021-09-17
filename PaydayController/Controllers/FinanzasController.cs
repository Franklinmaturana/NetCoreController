using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaydayController.Aplicacion;
using PaydayController.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaydayController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanzasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public object SaldoHistoricoGuid { get; private set; }

        public FinanzasController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<SaldoHistoricoDto>>> GetSaldos()
        {
            return await _mediator.Send(new Consulta.ListaSaldo());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SaldoHistorico>> GetSaldo(string id)
        {
            return await _mediator.Send(new ConsultaFiltro.SaldoEspecifico{ SaldoHistoricoGuid = id});
        }
    }
}
