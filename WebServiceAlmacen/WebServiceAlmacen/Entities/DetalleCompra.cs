using System.Runtime.Serialization;

namespace WebServiceAlmacen.Entities
{
    [DataContract]
    public class DetalleCompra
    {
        [DataMember]
        public string NumeroProducto { get; set; }

        [DataMember]
        public int Cantidad { get; set; }
    }
}
