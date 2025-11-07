package Servidor;

import java.io.Serializable;

public class DetalleCompra implements Serializable {

    private String codigo;
    private int cantidad;

    public DetalleCompra() {
    }

    public DetalleCompra(String codigo, int cantidad) {
        this.codigo = codigo;
        this.cantidad = cantidad;
    }

    public String getCodigo() {
        return codigo;
    }

    public void setCodigo(String codigo) {
        this.codigo = codigo;
    }

    public int getCantidad() {
        return cantidad;
    }

    public void setCantidad(int cantidad) {
        this.cantidad = cantidad;
    }
}
