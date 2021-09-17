using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaydayController.Modelos
{
    public class Saldo
    {
        public int Id { get; set; }
        public float SaldoUsuario { get; set; }
        public DateTime? Fecha { get; set; }
        public string SaldoGuid { get; set; }

    }
}
