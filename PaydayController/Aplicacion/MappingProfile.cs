using AutoMapper;
using PaydayController.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaydayController.Aplicacion
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {
            CreateMap<SaldoHistorico, SaldoHistoricoDto>();    
        }
    }
}
