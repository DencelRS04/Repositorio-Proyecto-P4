/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package almacen3.dao;
import almacen3.model.Compra;
import almacen3.model.CompraDetalle;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;

public class CompraDaoImpl implements CompraDao{
    
    private Connection _conn;
    
    public CompraDaoImpl(Connection conn){
    this._conn=conn;
    }//conn
    @Override
    public boolean insertarCompra(Compra compra){
       
        try{
            // System.out.println("HOLA SOY Steven");
            _conn.setAutoCommit(false);//inicio transac
            
            for (CompraDetalle det: compra.getDetalles()){
           String sql = "INSERT INTO registro_compra (fecha_compra, cantidad, id_provedor, id_producto) "
           + "VALUES (?, ?, ?, ?)";

                           
            try(PreparedStatement ps= _conn.prepareStatement(sql)){
            ps.setDate(1,java.sql.Date.valueOf(compra.getFechaCompra()));
            ps.setInt(2, det.getCantidad());
            ps.setString(3, compra.getCedulaProveedor());
            ps.setString(4, det.getNumeroProducto());
            ps.executeUpdate();
                }//try interno
            
            }//for
            
            _conn.commit();
            return true;
        }//try
        catch(SQLException e){
            System.err.println("Error insertando la compra: "+ e.getMessage());
            try{_conn.rollback();}catch(SQLException ex){}
            return false;
        }//catch
        finally{
        try{_conn.setAutoCommit(true);}catch(SQLException e){}
        }
    }//insert compra
}
