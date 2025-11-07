package almacen2.model;

public class Proveedor {

    //variables
  private int _idProvedor; 
    private String _cedulaJuridica;
    private String _nombreProveedor;
    private String _nombreContacto;
    private String _telefono;
    private String _correoElectronico;
    private String _estado; // '1' = activo, '2' = inactivo
    // Getters y Setters
    public int getIdProvedor() {
        return _idProvedor;
    }

    public void setIdProvedor(int idProvedor) {
        this._idProvedor = idProvedor;
    }

    public String getcedulaJuridica() {
        return _cedulaJuridica;
    }

    public void setcedulaJuridica(String cedulaJuridica) {
        this._cedulaJuridica = cedulaJuridica;
    }

    public String getnombreProveedor() {
        return _nombreProveedor;
    }

    public void setnombreProveedor(String nombreProveedor) {
        this._nombreProveedor = nombreProveedor;
    }
    
    public String getnombreContacto(){
        return _nombreContacto;
    }
    
    public void setnombreContacto(String nombreContacto){
        this._nombreContacto=nombreContacto;
      
    }
    
    public String gettelefono(){
     return _telefono;
    }
    
    public void settelefono(String telefono){
        this._telefono=telefono;
    }
    
    public String getcorreoElectronico(){
    return _correoElectronico;
    }
    
    public void setcorreoElectronico(String correoElectronico){
    this._correoElectronico=correoElectronico;
    }
    
    public String getestado(){
    return _estado;
    }
    
    public void setestado(String estado){
        this._estado=estado;
    }
    
    

}//fin public class
