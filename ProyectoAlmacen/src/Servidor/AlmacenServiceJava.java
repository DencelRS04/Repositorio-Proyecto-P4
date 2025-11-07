package Servidor;

import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import java.sql.Connection;
import java.util.List;

import almacen2.handler.ProveedorHandler;
import almacen2.dao.ProveedorDaoImplemen;
import almacen2.util.ConexionBD;
import almacen3.handler.CompraHandler;
import almacen3.dao.CompraDaoImpl;
import almacen5.BitacoraGestion;

@WebService(serviceName = "AlmacenServiceJava")
public class AlmacenServiceJava {

    @WebMethod(operationName = "MantenimientoProveedor")
    public String mantenimientoProveedor(
            @WebParam(name = "tipoTransaccion") String tipoTransaccion,
            @WebParam(name = "cedulaJuridica") String cedulaJuridica,
            @WebParam(name = "nombreEmpresa") String nombreEmpresa,
            @WebParam(name = "nombreContacto") String nombreContacto,
            @WebParam(name = "telefono") String telefono,
            @WebParam(name = "correoElectronico") String correoElectronico,
            @WebParam(name = "estado") String estado) {

        try (Connection conn = ConexionBD.getConnection()) {
            BitacoraGestion bitacora = new BitacoraGestion();
            ProveedorHandler proveedorHandler = new ProveedorHandler(new ProveedorDaoImplemen(conn), bitacora);

            // Armar la trama como antes
            String trama = tipoTransaccion
                    + almacen2.util.TramaUtils.padRight(cedulaJuridica, 10)
                    + almacen2.util.TramaUtils.padRight(nombreEmpresa, 100)
                    + almacen2.util.TramaUtils.padRight(nombreContacto, 75)
                    + almacen2.util.TramaUtils.padRight(telefono, 8)
                    + almacen2.util.TramaUtils.padRight(correoElectronico, 75)
                    + almacen2.util.TramaUtils.padRight(estado, 1);

            String respuesta = proveedorHandler.procesarTrama(trama);
            return "Resultado=TRUE;Mensaje=Exitoso;Detalle=" + respuesta;

        } catch (Exception e) {
            return "Resultado=FALSE;Mensaje=Error al procesar proveedor: " + e.getMessage();
        }
    }

    @WebMethod(operationName = "RegistrarCompra")
    public String registrarCompra(
            @WebParam(name = "numeroIngreso") String numeroIngreso,
            @WebParam(name = "fechaCompra") String fechaCompra,
            @WebParam(name = "cedulaJuridica") String cedulaJuridica,
            @WebParam(name = "listaProductos") List<DetalleCompra> listaProductos) {

        try (Connection conn = almacen3.util.ConexionBD.getConnection()) {
            BitacoraGestion bitacora = new BitacoraGestion();
            CompraHandler compraHandler = new CompraHandler(new CompraDaoImpl(conn), bitacora);

            StringBuilder trama = new StringBuilder();
            trama.append("5")
                 .append(almacen3.util.TramaUtilsAlm3.padRight(numeroIngreso, 10))
                 .append(almacen3.util.TramaUtilsAlm3.padRight(fechaCompra, 8))
                 .append(almacen3.util.TramaUtilsAlm3.padRight(cedulaJuridica, 10));

            for (DetalleCompra producto : listaProductos) {
                trama.append(almacen3.util.TramaUtilsAlm3.padRight(producto.getCodigo(), 10))
                     .append(almacen3.util.TramaUtilsAlm3.padLeftZeros(String.valueOf(producto.getCantidad()), 7));
            }

            String respuesta = compraHandler.procesarTrama(trama.toString());
            return "Resultado=TRUE;Mensaje=Exitoso;Detalle=" + respuesta;

        } catch (Exception e) {
            return "Resultado=FALSE;Mensaje=Error al procesar compra: " + e.getMessage();
        }
    }
}
