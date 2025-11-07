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
        // Ruta del archivo de bitácora en la raíz del proyecto
        private static readonly string RutaArchivo = AppDomain.CurrentDomain.BaseDirectory + "bitacora.json";

        /// <summary>
        /// Registra en la bitácora cualquier operación realizada por el Web Service
        /// </summary>
        /// <param name="solicitud">Detalles de la solicitud recibida</param>
        /// <param name="respuesta">Respuesta generada por el servicio</param>
        public static void RegistrarBitacora(string solicitud, string respuesta)
        {
            try
            {
                var registro = new
                {
                    Fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Solicitud = solicitud,
                    Respuesta = respuesta
                };

                string json = JsonConvert.SerializeObject(registro, Formatting.Indented);

                // Agregar una línea al archivo de bitácora
                File.AppendAllText(RutaArchivo, json + Environment.NewLine);
            }
            catch (Exception ex)
            {
                // Para desarrollo: mostrar en consola si hay error
                Console.WriteLine("Error al registrar bitácora: " + ex.Message);
            }
        }
    }
}