package almacen3.model;

public class CompraDetalle {
    private String _numeroProducto; // 10 caracteres (No_Producto)
    private int _cantidad;          // cantidad comprada

    public String getNumeroProducto() { return _numeroProducto; }
    public void setNumeroProducto(String numeroProducto) { this._numeroProducto = numeroProducto; }

    public int getCantidad() { return _cantidad; }
    public void setCantidad(int cantidad) { this._cantidad = cantidad; }
}
