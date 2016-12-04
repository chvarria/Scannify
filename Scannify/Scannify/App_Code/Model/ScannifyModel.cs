using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scannify.App_Code.Responses;
using SQLite.Net;
using Xamarin.Forms;

namespace Scannify.App_Code.Model
{
    class ScannifyModel:IDisposable
    {
        private SQLiteConnection connection;

        public ScannifyModel()
        {
            var config = DependencyService.Get<IConfig>();
            connection = new SQLiteConnection(config.Plataforma, Path.Combine(config.DirectorioBD, "ScannifyBD.db3"));

            // CREACION DE TABLAS
            connection.CreateTable<Resultados>();
        }

        public ResultadosResponse GetAllResultados()
        {
            var response = new ResultadosResponse();

            try
            {
                response.Resultados = connection.Table<Resultados>().ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public ResultadoResponse GetResultadoById(int id)
        {
            var response = new ResultadoResponse();

            try
            {
                response.Resultado = connection.Table<Resultados>().FirstOrDefault(r => r.Id == id);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public ResultadoResponse InsertResultado(Resultados resultado)
        {
            var response = new ResultadoResponse();
            try
            {
                connection.Insert(resultado);

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public ResponseBase DeleteResultado(int id)
        {
            var response = new ResponseBase();
            try
            {
                var resultado = GetResultadoById(id);
                if (resultado.Success)
                {
                    connection.Delete(resultado.Resultado);
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.Message = "No se ha encontrado el registro a eliminar";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
