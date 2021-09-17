using AutoMapper;
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
    public class Consulta
    {
        public class ListaSaldo:IRequest<List<SaldoHistoricoDto>>
        {

        }

        public class Manejador : IRequestHandler<ListaSaldo,List<SaldoHistoricoDto>>
        {
            public readonly ContextoFinanzas _contexto;
            private readonly IMapper _mapper;
            public Manejador(ContextoFinanzas contextoFinanzas,IMapper mapper)
            {
                _contexto = contextoFinanzas;
                _mapper = mapper;
            }

            public async Task<List<SaldoHistoricoDto>> Handle(ListaSaldo request, CancellationToken cancellationToken)
            {
                var saldos = await _contexto.SaldoHistoricos.ToListAsync();
                var saldosDto = _mapper.Map<List<SaldoHistorico>, List<SaldoHistoricoDto>>(saldos);
                return saldosDto;
            }
        }
    }
}
