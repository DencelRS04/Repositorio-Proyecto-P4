package almacen2.handler;

import almacen5.BitacoraGestion;
import almacen5.BitacoraEntradas;
import almacen2.dao.ProveedorDao;
import almacen2.model.Proveedor;
import almacen2.util.Validaciones;
import java.time.LocalDateTime;

public class ProveedorHandler {

    private ProveedorDao _dao;
    private BitacoraGestion _bitacora; // referencia a la bitácora

    public ProveedorHandler(ProveedorDao dao, BitacoraGestion bitacora) {
        this._dao = dao;
        this._bitacora = bitacora;
    }

    public String procesarTrama(String trama) {
        String resultado;
        try {
            // Extraer datos de la trama
            String tipo = trama.substring(0, 1).trim();
            String cedula = trama.substring(1, 11).trim();
            String nombre = trama.substring(11, 111).trim();
            String contacto = trama.substring(111, 186).trim();
            String telefono = trama.substring(186, 194).trim();
            String correo = trama.substring(194, 269).trim();
            String estado = trama.substring(269, 270).trim();

            // Validaciones de datos
            System.out.println("🔎 Validando campos...");
            System.out.println("Cedula válida: " + Validaciones.validarCedula(cedula)); // todas estas validaciones es para ver si deveulven bien los datos antes de insert
            System.out.println("Nombre válido: " + Validaciones.noPermiteVacio(nombre));
            System.out.println("Contacto válido: " + Validaciones.noPermiteVacio(contacto));
            System.out.println("Teléfono válido: " + Validaciones.validarTelefono(telefono));
            System.out.println("Correo válido: " + Validaciones.validarCorreo(correo));
            System.out.println("Estado válido: " + (estado.equals("1") || estado.equals("2")));

            if (!Validaciones.validarCedula(cedula)
                    || !Validaciones.noPermiteVacio(nombre)
                    || !Validaciones.noPermiteVacio(contacto)
                    || !Validaciones.validarTelefono(telefono)
                    || !Validaciones.validarCorreo(correo)
                    || !(estado.equals("1") || estado.equals("2"))) {
                resultado = "DATO INVÁLIDO";

                _bitacora.registrar(new BitacoraEntradas(
                        LocalDateTime.now(),
                        "VALIDACIÓN FALLIDA",
                        "Cédula: " + cedula + ", Nombre: " + nombre + ", Contacto: " + contacto
                ));
                return resultado;
            }

            //Crear objeto proveedor
            Proveedor p = new Proveedor();
            p.setcedulaJuridica(cedula);
            p.setnombreProveedor(nombre);
            p.setnombreContacto(contacto);
            p.settelefono(telefono);
            p.setcorreoElectronico(correo);
            p.setestado(estado);

            //Determinar tipo de transacción
            if (tipo.equals("3")) { // Insertar
                if (_dao.existePorCedula(cedula)) {
                    resultado = "DUPLICADO";
                    _bitacora.registrar(new BitacoraEntradas(
                            LocalDateTime.now(),
                            "INSERCIÓN FALLIDA",
                            "Proveedor duplicado: " + nombre + " (" + cedula + ")"
                    ));
                } else if (_dao.insertar(p)) {
                    resultado = "EXITOSO";
                    _bitacora.registrar(new BitacoraEntradas(
                            LocalDateTime.now(),
                            "INSERTAR PROVEEDOR",
                            "Proveedor agregado: " + nombre + " (" + cedula + ")"
                    ));
                } else {
                    resultado = "ERROR";
                    _bitacora.registrar(new BitacoraEntradas(
                            LocalDateTime.now(),
                            "ERROR INSERCIÓN",
                            "Error al insertar proveedor: " + nombre + " (" + cedula + ")"
                    ));
                }

            } else if (tipo.equals("4")) { // Actualizar
                if (!_dao.existePorCedula(cedula)) {
                    resultado = "PROVEEDOR INVÁLIDO";
                    _bitacora.registrar(new BitacoraEntradas(
                            LocalDateTime.now(),
                            "ACTUALIZACIÓN FALLIDA",
                            "Proveedor no existe: " + nombre + " (" + cedula + ")"
                    ));
                } else if (_dao.actualizar(p)) {
                    resultado = "EXITOSO";
                    _bitacora.registrar(new BitacoraEntradas(
                            LocalDateTime.now(),
                            "ACTUALIZAR PROVEEDOR",
                            "Proveedor actualizado: " + nombre + " (" + cedula + ")"
                    ));
                } else {
                    resultado = "ERROR";
                    _bitacora.registrar(new BitacoraEntradas(
                            LocalDateTime.now(),
                            "ERROR ACTUALIZACIÓN",
                            "Error al actualizar proveedor: " + nombre + " (" + cedula + ")"
                    ));
                }
            } else {
                resultado = "DATO INVÁLIDO";
                _bitacora.registrar(new BitacoraEntradas(
                        LocalDateTime.now(),
                        "TIPO INVÁLIDO",
                        "Tipo de operación no reconocido: " + tipo
                ));
            }//fin utl else

        } catch (Exception e) {
            resultado = "ERROR";
            System.err.println("Error procesando trama: " + e.getMessage());

            _bitacora.registrar(new BitacoraEntradas(
                    LocalDateTime.now(),
                    "EXCEPCIÓN",
                    "Error procesando trama: " + e.getMessage()
            ));
        }//fin catch

        return resultado;
    }//procesar trama
}//fin class
