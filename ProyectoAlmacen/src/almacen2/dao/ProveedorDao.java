
package almacen2.dao;
import almacen2.model.Proveedor;

public interface ProveedorDao {
    boolean insertar(Proveedor proveedor);
    boolean actualizar(Proveedor proovedor);
    Proveedor buscarPorCedula(String cedula);// este es para cuando necesito todos los datos del proveedor (nombre, contacto, correo, etc.).
    boolean existePorCedula (String cedula);//Y este solo para cuando necesito comprobar si solamente existe o no
}
