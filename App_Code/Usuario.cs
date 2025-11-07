using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceAutenticacion
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("identificacion")]
        public string Identificacion { get; set; }

        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [BsonElement("primerApellido")]
        public string PrimerApellido { get; set; }

        [BsonElement("segundoApellido")]
        public string SegundoApellido { get; set; }

        [BsonElement("correo")]
        public string Correo { get; set; }

        [BsonElement("usuario")]
        public string UsuarioNombre { get; set; }

        [BsonElement("contrasena")]
        public string Contrasena { get; set; }

        [BsonElement("estado")]
        public bool Estado { get; set; }

        [BsonElement("tipo")]
        public int Tipo { get; set; }
    }
}
