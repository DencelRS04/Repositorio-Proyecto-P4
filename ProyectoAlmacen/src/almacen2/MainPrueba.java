package almacen2;

import almacen2.dao.ProveedorDaoImplemen;
import almacen2.handler.ProveedorHandler;
import almacen2.util.ConexionBD;
import almacen5.BitacoraGestion;
import java.sql.Connection;

public class MainPrueba {
    public static void main(String[] args) {
        try (Connection conn = ConexionBD.getConnection()) {
            
            //Inicializamos la bitácora
            BitacoraGestion bitacora = new BitacoraGestion();

            //Instanciamos el DAO con la conexión
            ProveedorDaoImplemen dao = new ProveedorDaoImplemen(conn);

            //Crea el handler y le pasamos la bitácora
            ProveedorHandler handler = new ProveedorHandler(dao, bitacora);

            //Trama de prueba tipo 3 (ingreso proveedor)
            String trama = "3" +                                   // Tipo transacción = 3 (ingreso)
                    "3100550001" +                                // Cédula jurídica (10)
                    String.format("%-100s", "Noches Mágicas") + // Nombre proveedor (100 chars)
                    String.format("%-75s", "Steven garcia") +    // Nombre contacto (75 chars)
                    "89403536" +                                  // Teléfono (8)
                    String.format("%-75s", "correo@ejemplo.com") +// Correo (75 chars)
                    "1";                                          // Estado (1 = activo)

            //Procesar trama
            String respuesta = handler.procesarTrama(trama);
            System.out.println("Respuesta del sistema: " + respuesta);

            //Detener bitácora (opcional, si ya no se usarán más tramas)
            bitacora.detener();

        } catch (Exception e) {
            e.printStackTrace();
        }
    }// fin main
}
