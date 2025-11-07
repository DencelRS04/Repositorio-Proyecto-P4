package almacen3.handler;

import almacen3.dao.CompraDao;
import almacen3.model.Compra;
import almacen3.model.CompraDetalle;
import almacen5.BitacoraEntradas;
import almacen5.BitacoraGestion;
import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.List;

public class CompraHandler {

    private CompraDao _dao;
    private BitacoraGestion _bitacora; // referencia a la bitácora

    public CompraHandler(CompraDao dao, BitacoraGestion bitacora) {
        this._dao = dao;
        this._bitacora = bitacora;
    }

    public String procesarTrama(String trama) {
        String resultado;

        try {
            String tipo = trama.substring(0, 1).trim();
            if (!tipo.equals("5")) {
                resultado = "DATO INVÁLIDO";
                _bitacora.registrar(new BitacoraEntradas(
                        LocalDateTime.now(),
                        "TIPO INVÁLIDO",
                        "Tipo de operación no reconocido: " + tipo
                ));
                return resultado;
            }

            //Datos de cabecera
            String numeroIngreso = trama.substring(1, 11).trim();
            String fechaStr = trama.substring(11, 19).trim();
            String cedulaProv = trama.substring(19, 29).trim();

            //Validar fecha
            LocalDate fecha;
            if (fechaStr.contains("-")) {
                fecha = LocalDate.parse(fechaStr, DateTimeFormatter.ofPattern("yyyy-MM-dd"));
            } else {
                fecha = LocalDate.parse(fechaStr, DateTimeFormatter.ofPattern("yyyyMMdd"));
            }

            if (fecha.isAfter(LocalDate.now())) {
                resultado = "DATO INVÁLIDO";
                _bitacora.registrar(new BitacoraEntradas(
                        LocalDateTime.now(),
                        "VALIDACIÓN FALLIDA",
                        "Fecha futura detectada: " + fechaStr
                ));
                return resultado;
            }

            //Construir objeto Compra
            Compra compra = new Compra();
            compra.setNumeroIngreso(numeroIngreso);
            compra.setFechaCompra(fecha);
            compra.setCedulaProveedor(cedulaProv);

            //Parsear productos
            List<CompraDetalle> detalles = new ArrayList<>();
            int pos = 29;
            while (pos + 17 <= trama.length()) {
                String noProducto = trama.substring(pos, pos + 10).trim();
                pos += 10;
                int cantidad = Integer.parseInt(trama.substring(pos, pos + 7).trim());
                pos += 7;

                if (cantidad <= 0) {
                    resultado = "DATO INVÁLIDO";
                    _bitacora.registrar(new BitacoraEntradas(
                            LocalDateTime.now(),
                            "VALIDACIÓN FALLIDA",
                            "Cantidad inválida para producto: " + noProducto
                    ));
                    return resultado;
                }

                CompraDetalle det = new CompraDetalle();
                det.setNumeroProducto(noProducto);
                det.setCantidad(cantidad);
                detalles.add(det);
            }

            //Validar si hay productos
            if (detalles.isEmpty()) {
                resultado = "DATO INVÁLIDO";
                _bitacora.registrar(new BitacoraEntradas(
                        LocalDateTime.now(),
                        "VALIDACIÓN FALLIDA",
                        "No se detectaron productos en la trama"
                ));
                return resultado;
            }

            // 🔹 Guardar en BD
            compra.setDetalles(detalles);
            boolean exito = _dao.insertarCompra(compra);
            if (exito) {
                resultado = "EXITOSO";
                _bitacora.registrar(new BitacoraEntradas(
                        LocalDateTime.now(),
                        "REGISTRAR COMPRA",
                        String.format("Compra #%s registrada (Proveedor %s, %d productos)",
                                compra.getNumeroIngreso(),
                                compra.getCedulaProveedor(),
                                compra.getDetalles().size())
                ));
            } else {
                resultado = "ERROR";
                _bitacora.registrar(new BitacoraEntradas(
                        LocalDateTime.now(),
                        "ERROR REGISTRO",
                        String.format("Fallo al registrar compra #%s del proveedor %s",
                                compra.getNumeroIngreso(),
                                compra.getCedulaProveedor())
                ));
            }

        } catch (Exception e) {
            resultado = "ERROR";
            System.err.println("Error procesando compra: " + e.getMessage());

            _bitacora.registrar(new BitacoraEntradas(
                    LocalDateTime.now(),
                    "EXCEPCIÓN",
                    "Error procesando trama: " + e.getMessage()
            ));
        }

        return resultado;
    }
}
