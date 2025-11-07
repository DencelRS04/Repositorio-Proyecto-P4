/* acá yo guardo los datos como si fuera una línea en la bitacora,
guardo fecha tipo de trnasacción y los datos que estan asociados
*/
package almacen5;


import java.time.LocalDateTime;
/**
 *
 * @author steve
 */
public class BitacoraEntradas {
  private LocalDateTime _fechaHora;
    private String _transaccion;
    private String _datos;
    
    public BitacoraEntradas(LocalDateTime fechaHora,String transaccion,String datos){
    this._fechaHora=fechaHora;
    this._transaccion=transaccion;
    this._datos=datos;
    } // fin constructor
    //getters y setters
    
    public void setfechaHora(LocalDateTime fechaHora){
    this._fechaHora=fechaHora;
    }
    public LocalDateTime getFechaHora(){
    return _fechaHora;
    }
    
    public void setTransaccion(String transaccion){
    this._transaccion=transaccion;
    }
    public String getTransaccion(){
    return _transaccion;
    }
    
    public void setDatos(String datos){
    this._datos=datos;
    }
    public String getDatos(){
        return _datos;
    }
  
}//fin class
