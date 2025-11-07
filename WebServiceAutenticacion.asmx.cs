using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MongoDB.Driver;
using WebServiceAutenticacion.App_Code;

namespace WebServiceAutenticacion
{
    [WebService(Namespace = "http://novaonline.com/webservices/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class WSAutenticacion : WebService
    {
        // ===============================================
        // WS_AUTENTICACION1 - Probar conexión y autenticación
        // ===============================================
        [WebMethod(Description = "Prueba la conexión con la base de datos MongoDB")]
        public string ProbarConexion()
        {
            var db = ConexionMongo.ObtenerConexion();
            return $"✅ Conexión establecida con la base de datos: {db.DatabaseNamespace.DatabaseName}";
        }

        [WebMethod(Description = "Obtiene la lista de usuarios de la colección 'usuarios'")]
        public List<Usuario> ObtenerUsuarios()
        {
            var db = ConexionMongo.ObtenerConexion();
            var coleccion = db.GetCollection<Usuario>("usuarios");
            return coleccion.Find(_ => true).ToList();
        }

        [WebMethod(Description = "Autentica a un usuario según su tipo (1 = empleado, 2 = cliente)")]
        public Respuesta AutenticarUsuario(string usuario, string contrasena, int tipo)
        {
            var respuesta = new Respuesta();
            try
            {
                var db = ConexionMongo.ObtenerConexion();
                var coleccion = db.GetCollection<Usuario>("usuarios");

                var filtro = Builders<Usuario>.Filter.And(
                    Builders<Usuario>.Filter.Eq(u => u.NombreUsuario, usuario),
                    Builders<Usuario>.Filter.Eq(u => u.Contrasena, Usuario.EncriptarContrasena(contrasena)),
                    Builders<Usuario>.Filter.Eq(u => u.Tipo, tipo),
                    Builders<Usuario>.Filter.Eq(u => u.Estado, "activo")
                );

                var usuarioEncontrado = coleccion.Find(filtro).FirstOrDefault();

                if (usuarioEncontrado != null)
                {
                    respuesta.Resultado = true;
                    respuesta.Id = usuarioEncontrado.Id;
                    respuesta.Mensaje = "Exitoso";
                }
                else
                {
                    respuesta.Resultado = false;
                    respuesta.Mensaje = "Usuario y/o contraseña incorrectos.";
                }

                // Registrar bitácora
                Bitacora.RegistrarBitacora(
                    solicitud: $"AutenticarUsuario | Usuario: {usuario}, Tipo: {tipo}",
                    respuesta: $"Resultado: {respuesta.Resultado}, Mensaje: {respuesta.Mensaje}"
                );
            }
            catch (Exception ex)
            {
                respuesta.Resultado = false;
                respuesta.Mensaje = "Error interno: " + ex.Message;

                Bitacora.RegistrarBitacora(
                    solicitud: $"AutenticarUsuario | Usuario: {usuario}, Tipo: {tipo}",
                    respuesta: $"Error interno: {ex.Message}"
                );
            }

            return respuesta;
        }

        // ===============================================
        // WS_AUTENTICACION2 - Crear, Modificar y Cambiar Estado
        // ===============================================

        [WebMethod(Description = "Crea un nuevo usuario")]
        public Respuesta CrearUsuario(string identificacion, string nombre, string primerApellido, string segundoApellido,
                                     string correo, string usuario, string contrasena, int tipo)
        {
            var respuesta = new Respuesta();

            try
            {
                var db = ConexionMongo.ObtenerConexion();
                var coleccion = db.GetCollection<Usuario>("usuarios");

                // Validaciones
                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(primerApellido) || string.IsNullOrWhiteSpace(segundoApellido) ||
                    string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena) ||
                    !(tipo == 1 || tipo == 2) || !ValidarCorreo(correo) || !ValidarContrasena(contrasena))
                {
                    respuesta.Resultado = false;
                    respuesta.Mensaje = "Usuario ya existe o datos incorrectos o incompletos";
                }
                else
                {
                    // Verificar si ya existe
                    var filtro = Builders<Usuario>.Filter.Eq(u => u.NombreUsuario, usuario);
                    var existente = coleccion.Find(filtro).FirstOrDefault();
                    if (existente != null)
                    {
                        respuesta.Resultado = false;
                        respuesta.Mensaje = "Usuario ya existe o datos incorrectos o incompletos";
                    }
                    else
                    {
                        var nuevoUsuario = new Usuario
                        {
                            NombreUsuario = usuario,
                            Contrasena = Usuario.EncriptarContrasena(contrasena),
                            Correo = correo,
                            Estado = "activo",
                            Tipo = tipo,
                            Rol = tipo == 1 ? "Empleado" : "Cliente"
                        };
                        coleccion.InsertOne(nuevoUsuario);
                        respuesta.Resultado = true;
                        respuesta.Mensaje = "Exitoso";
                    }
                }

                // Bitácora
                Bitacora.RegistrarBitacora(
                    solicitud: $"CrearUsuario | Usuario: {usuario}, Tipo: {tipo}",
                    respuesta: $"Resultado: {respuesta.Resultado}, Mensaje: {respuesta.Mensaje}"
                );
            }
            catch (Exception ex)
            {
                respuesta.Resultado = false;
                respuesta.Mensaje = "Error interno: " + ex.Message;
                Bitacora.RegistrarBitacora(
                    solicitud: $"CrearUsuario | Usuario: {usuario}, Tipo: {tipo}",
                    respuesta: $"Error interno: {ex.Message}"
                );
            }

            return respuesta;
        }

        [WebMethod(Description = "Modifica un usuario existente")]
        public Respuesta ModificarUsuario(string identificacion, string nombre, string primerApellido, string segundoApellido,
                                          string correo, string usuario, string contrasena)
        {
            var respuesta = new Respuesta();
            try
            {
                var db = ConexionMongo.ObtenerConexion();
                var coleccion = db.GetCollection<Usuario>("usuarios");

                var filtro = Builders<Usuario>.Filter.Eq(u => u.Id, identificacion);
                var usuarioExistente = coleccion.Find(filtro).FirstOrDefault();

                if (usuarioExistente == null)
                {
                    respuesta.Resultado = false;
                    respuesta.Mensaje = "Usuario no existe o datos incorrectos o incompletos";
                }
                else
                {
                    // Validaciones
                    if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(primerApellido) || string.IsNullOrWhiteSpace(segundoApellido) ||
                        string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena) ||
                        !ValidarCorreo(correo) || !ValidarContrasena(contrasena))
                    {
                        respuesta.Resultado = false;
                        respuesta.Mensaje = "Usuario no existe o datos incorrectos o incompletos";
                    }
                    else
                    {
                        var update = Builders<Usuario>.Update
                            .Set(u => u.NombreUsuario, usuario)
                            .Set(u => u.Contrasena, Usuario.EncriptarContrasena(contrasena))
                            .Set(u => u.Correo, correo);
                        coleccion.UpdateOne(filtro, update);

                        respuesta.Resultado = true;
                        respuesta.Mensaje = "Exitoso";
                    }
                }

                // Bitácora
                Bitacora.RegistrarBitacora(
                    solicitud: $"ModificarUsuario | Id: {identificacion}",
                    respuesta: $"Resultado: {respuesta.Resultado}, Mensaje: {respuesta.Mensaje}"
                );
            }
            catch (Exception ex)
            {
                respuesta.Resultado = false;
                respuesta.Mensaje = "Error interno: " + ex.Message;
                Bitacora.RegistrarBitacora(
                    solicitud: $"ModificarUsuario | Id: {identificacion}",
                    respuesta: $"Error interno: {ex.Message}"
                );
            }

            return respuesta;
        }

        [WebMethod(Description = "Cambia el estado de un usuario")]
        public Respuesta CambiarEstadoUsuario(string identificacion, string estado)
        {
            var respuesta = new Respuesta();
            try
            {
                var db = ConexionMongo.ObtenerConexion();
                var coleccion = db.GetCollection<Usuario>("usuarios");

                var filtro = Builders<Usuario>.Filter.Eq(u => u.Id, identificacion);
                var usuarioExistente = coleccion.Find(filtro).FirstOrDefault();

                if (usuarioExistente == null)
                {
                    respuesta.Resultado = false;
                    respuesta.Mensaje = "Usuario no existe o datos incorrectos";
                }
                else
                {
                    var update = Builders<Usuario>.Update.Set(u => u.Estado, estado);
                    coleccion.UpdateOne(filtro, update);

                    respuesta.Resultado = true;
                    respuesta.Mensaje = "Exitoso";
                }

                // Bitácora
                Bitacora.RegistrarBitacora(
                    solicitud: $"CambiarEstadoUsuario | Id: {identificacion}, Estado: {estado}",
                    respuesta: $"Resultado: {respuesta.Resultado}, Mensaje: {respuesta.Mensaje}"
                );
            }
            catch (Exception ex)
            {
                respuesta.Resultado = false;
                respuesta.Mensaje = "Error interno: " + ex.Message;
                Bitacora.RegistrarBitacora(
                    solicitud: $"CambiarEstadoUsuario | Id: {identificacion}",
                    respuesta: $"Error interno: {ex.Message}"
                );
            }

            return respuesta;
        }

        // ===============================================
        // Métodos auxiliares de validación
        // ===============================================
        private bool ValidarCorreo(string correo)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(correo);
                return addr.Address == correo;
            }
            catch
            {
                return false;
            }
        }

        private bool ValidarContrasena(string contrasena)
        {
            if (contrasena.Length < 14) return false;
            if (!System.Text.RegularExpressions.Regex.IsMatch(contrasena, "[A-Z]")) return false;
            if (!System.Text.RegularExpressions.Regex.IsMatch(contrasena, "[a-z]")) return false;
            if (!System.Text.RegularExpressions.Regex.IsMatch(contrasena, "[0-9]")) return false;
            if (!System.Text.RegularExpressions.Regex.IsMatch(contrasena, "[^a-zA-Z0-9]")) return false;
            return true;
        }
    }
}
