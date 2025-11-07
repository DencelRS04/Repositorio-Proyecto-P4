package almacen3.model;
import java.time.LocalDate;
import java.util.List;

public class Compra {
    private String _numeroIngreso; // 10 caracteres
    private LocalDate _fechaCompra; // formato YYYYMMDD
    private String _cedulaProveedor; //ced juridica de 10 caracteres
    private List<CompraDetalle> _detalles;  // lista de los porductos de la compra
    
    //getters y setters
    public String getNumeroIngreso(){
    return _numeroIngreso;
    }
    public void setNumeroIngreso(String numeroIngreso){
        this._numeroIngreso=numeroIngreso;
    }
    
    public LocalDate getFechaCompra(){
    return _fechaCompra;
    }
    
    public void setFechaCompra(LocalDate fechaCompra){
    this._fechaCompra=fechaCompra;
    }
    
    public String getCedulaProveedor(){
    return _cedulaProveedor;
    }
    public void setCedulaProveedor(String cedulaProveedor){
        this._cedulaProveedor=cedulaProveedor;
    }
    
    public List<CompraDetalle> getDetalles() {
        return _detalles;
    }
    public void setDetalles(List<CompraDetalle> detalles) {
        this._detalles = detalles;
    }
}//fin class
