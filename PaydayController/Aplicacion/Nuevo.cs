using FluentValidation;
using MediatR;
using PaydayController.Modelos;
using PaydayController.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PaydayController.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta:IRequest
        {
            //parametros que vendran por el request por medio del Controller
            public float Saldo { get; set; }
            public string Fuente { get; set; }
        }

        public class EjecutaValidacion:AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Saldo).NotEmpty();
                RuleFor(x => x.Fuente).NotEmpty();

            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            public readonly ContextoFinanzas _contexto;

            public Manejador(ContextoFinanzas contexto)
            {
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var saldoIngresado = new SaldoHistorico()
                {
                    Saldo = request.Saldo,
                    Fuente = request.Fuente,
                    SaldoHistoricoGuid = Convert.ToString(Guid.NewGuid())
                };

                _contexto.SaldoHistoricos.Add(saldoIngresado);// es como un begin tran
                var valor= await _contexto.SaveChangesAsync();

                if (valor > 0)
                    return Unit.Value;
                

                throw new Exception("No se pudo insertar el Autor del libro");




            }
        }

    }
}
