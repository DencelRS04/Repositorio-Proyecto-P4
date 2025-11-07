package almacen3;

import almacen3.dao.CompraDaoImpl;
import almacen3.handler.CompraHandler;
import almacen3.util.ConexionBD;
import almacen5.BitacoraGestion;
import java.sql.Connection;

public class MainPruebaCompra {

    public static void main(String[] args) {
        try (Connection conn = ConexionBD.getConnection()) {
            
            //Inicializar bitácora
            BitacoraGestion bitacora = new BitacoraGestion();

            // DAO y Handler con bitácora
            CompraDaoImpl dao = new CompraDaoImpl(conn);
            CompraHandler handler = new CompraHandler(dao, bitacora);

            // Trama de prueba tipo 5 (compra)
            String trama = "5"
                    + "2526202000"   // Número de ingreso (10)
                    + "20250927"     // Fecha de compra (YYYYMMDD, 8)
                    + "3100550000"   // Cédula proveedor (10)
                    + "3444550000" + "0000345"  // Producto 1 (10) + Cantidad (7)
                    + "3444600000" + "0000100"; // Producto 2 (10) + Cantidad (7)

            //Procesar trama
            String respuesta = handler.procesarTrama(trama);
            System.out.println("Respuesta del sistema: " + respuesta);

            //Detener bitácora (opcional, si ya no se usarán más tramas)
            bitacora.detener();

        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
