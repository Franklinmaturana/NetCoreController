using Microsoft.EntityFrameworkCore;
using PaydayController.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaydayController.Persistencia
{
    public class ContextoFinanzas:DbContext
    {
        public ContextoFinanzas(DbContextOptions<ContextoFinanzas> options):base(options)
        {

        }

        public DbSet<Saldo> Saldos { get;set;}
        public DbSet<SaldoHistorico> SaldoHistoricos { get; set; }
    }
}
