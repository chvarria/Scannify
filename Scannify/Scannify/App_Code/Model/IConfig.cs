using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Interop;


namespace Scannify.App_Code.Model
{
    public interface IConfig
    {
        string DirectorioBD { get; }
        ISQLitePlatform Plataforma { get; }
    }
}
