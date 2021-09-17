using MediatR;
using Microsoft.EntityFrameworkCore;
using PaydayController.Modelos;
using PaydayController.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PaydayController.Aplicacion
{
    public class ConsultaFiltro
    {
        public class SaldoEspecifico:IRequest<SaldoHistorico>
        {
            public string SaldoHistoricoGuid { get; set; }
        }

        public class Manejador : IRequestHandler<SaldoEspecifico, SaldoHistorico>
        {
            public readonly ContextoFinanzas _contexto;

            public Manejador(ContextoFinanzas contexto)
            {
                _contexto = contexto;
            }
               
            public async Task<SaldoHistorico> Handle(SaldoEspecifico request, CancellationToken cancellationToken)
            {
                //var saldoEspecifico = await _contexto.SaldoHistoricos.FindAsync(request.SaldoHistoricoGuid);

                //return saldoEspecifico;

                var saldoEspecifico = await _contexto.SaldoHistoricos.Where(x => x.SaldoHistoricoGuid == request.SaldoHistoricoGuid).FirstOrDefaultAsync();

                if (saldoEspecifico == null)
                {
                    throw new Exception("No se encontro el autor");
                }

                return saldoEspecifico;

            }
        }
    }
}
