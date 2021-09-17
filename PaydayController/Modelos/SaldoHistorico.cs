using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaydayController.Modelos
{
    public class SaldoHistorico
    {
        public int Id { get; set; }
        public float Saldo { get; set; }
        public string Fuente { get; set; }
        public string SaldoHistoricoGuid { get; set; }

    }
}
