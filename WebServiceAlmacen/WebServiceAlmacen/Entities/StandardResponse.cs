using System.Runtime.Serialization;

namespace WebServiceAlmacen.Entities
{
    [DataContract]
    public class StandardResponse
    {
        [DataMember]
        public bool Resultado { get; set; }

        [DataMember]
        public string Mensaje { get; set; }
    }
}
