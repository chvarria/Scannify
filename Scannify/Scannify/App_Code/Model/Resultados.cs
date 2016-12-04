using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace Scannify.App_Code.Model
{
    class Resultados
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Resultado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Tipo { get; set; }
    }
}
