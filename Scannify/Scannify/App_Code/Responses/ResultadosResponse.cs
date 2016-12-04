using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scannify.App_Code.Model;

namespace Scannify.App_Code.Responses
{
    class ResultadosResponse:ResponseBase
    {
        public List<Resultados> Resultados { get; set; }
    }
}
