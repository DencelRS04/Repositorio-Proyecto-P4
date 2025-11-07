using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace WebServiceAutenticacion
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("usuario")]
        public string NombreUsuario { get; set; }

        [BsonElement("correo")]
        public string Correo { get; set; }

        [BsonElement("contrasenia")] //coincide MongoDB
        public string Contrasena { get; set; }

        [BsonElement("estado")]
        public string Estado { get; set; } //cmbiar a string para que coincida

        [BsonElement("tipo")]
        public int Tipo { get; set; }

        [BsonElement("rol")]
        public string Rol { get; set; }

        public static string EncriptarContrasena(string contrasena)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contrasena));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}