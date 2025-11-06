using System;
using System.Collections.Generic;
using System.ServiceModel;
using WebServiceAlmacen.Entities;

namespace WebServiceAlmacen
{
    [ServiceContract]
    public interface IAlmacen
    {
        [OperationContract]
        StandardResponse MantenimientoProducto(string tipoTransaccion, string numeroProducto, string nombreProducto, decimal precio);

        [OperationContract]
        StandardResponse MantenimientoProveedor(string tipoTransaccion, string cedulaJuridica, string nombreEmpresa, string nombreContacto, string telefono, string correoElectronico, string estado);

        [OperationContract]
        StandardResponse RegistrarCompra(string numeroIngreso, DateTime fechaCompra, string cedulaJuridica, List<DetalleCompra> listaProductos);
    }
}
