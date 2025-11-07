using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;

namespace WebServiceAutenticacion.App_Code
{
    public static class Bitacora
    {
        private static readonly string RutaArchivo = AppDomain.CurrentDomain.BaseDirectory + "bitacora.json";

        public static void RegistrarBitacora(string solicitud, string respuesta)
        {
            var registro = new
            {
                Fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Solicitud = solicitud,
                Respuesta = respuesta
            };

            string json = JsonConvert.SerializeObject(registro, Formatting.Indented);
            File.AppendAllText(RutaArchivo, json + Environment.NewLine);
        }
    }
}
