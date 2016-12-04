using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scannify.App_Code.Model;

namespace Scannify.App_Code.Responses
{
    class ResultadoResponse:ResponseBase
    {
        public Resultados Resultado { get; set; }
    }
}
