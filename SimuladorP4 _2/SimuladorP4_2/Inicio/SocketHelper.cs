using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace Inicio
{
    internal class SocketHelper
    {
        public static string EnviarAlVerificador(string trama, string ip = "127.0.0.1", int puerto = 5001)
        {
            try
            {
                using (TcpClient cliente = new TcpClient(ip, puerto))
                using (NetworkStream stream = cliente.GetStream())
                {
                    // Enviar JSON + salto de línea como delimitador
                    byte[] datos = Encoding.UTF8.GetBytes(trama + "\n");
                    stream.Write(datos, 0, datos.Length);

                    // Leer respuesta completa
                    byte[] buffer = new byte[4096];
                    int bytesLeidos = stream.Read(buffer, 0, buffer.Length);
                    return Encoding.UTF8.GetString(buffer, 0, bytesLeidos).Trim();
                }
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }

        // 🔹 Envío de trama al ALMACÉN (Java)
        public static string EnviarAlAlmacen(string jsonData, string host = "localhost", int port = 8080)
        {
            TcpClient client = null;
            NetworkStream stream = null;
            StreamReader reader = null;

            try
            {
                client = new TcpClient(host, port);
                stream = client.GetStream();

                // Limpiar y convertir a bytes UTF-8 sin BOM
                string jsonLimpio = jsonData.Trim();
                byte[] data = Encoding.UTF8.GetBytes(jsonLimpio + "\n");

                // Configurar timeout
                client.SendTimeout = 5000;
                client.ReceiveTimeout = 5000;

                // Enviar bytes directamente
                stream.Write(data, 0, data.Length);
                stream.Flush();

                // Leer respuesta
                reader = new StreamReader(stream, Encoding.UTF8);
                string respuesta = reader.ReadLine();

                return respuesta ?? "ERROR: Respuesta nula del servidor";
            }
            catch (SocketException ex)
            {
                return $"ERROR: No se pudo conectar al servidor {host}:{port} - {ex.Message}";
            }
            catch (IOException ex)
            {
                return $"ERROR: Timeout o problema de E/S - {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"ERROR: {ex.GetType().Name} - {ex.Message}";
            }
            finally
            {
                reader?.Close();
                stream?.Close();
                client?.Close();
            }
        }

        // 🔹 Método adicional para envío genérico
        public static string EnviarJSON(string jsonData, string host, int port, int timeoutMs = 5000)
        {
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    client.Connect(host, port);
                    client.SendTimeout = timeoutMs;
                    client.ReceiveTimeout = timeoutMs;

                    using (NetworkStream stream = client.GetStream())
                    using (StreamWriter writer = new StreamWriter(stream, new UTF8Encoding(false)))
                    using (StreamReader reader = new StreamReader(stream, new UTF8Encoding(false)))
                    {
                        // Enviar JSON limpio
                        writer.WriteLine(jsonData.Trim());
                        writer.Flush();

                        // Leer respuesta
                        return reader.ReadLine()?.Trim() ?? "ERROR: Sin respuesta";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"ERROR: {ex.Message}";
            }
        }
    }
}