/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package almacen2.dao;

import almacen2.model.Proveedor;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

/**
 *
 * @author steve
 */
public class ProveedorDaoImplemen implements ProveedorDao {

    private Connection _conn;

    // El constructor recibe la conexión a la BD
    public ProveedorDaoImplemen(Connection conn) {
        this._conn = conn;
    }

    @Override
    public boolean insertar(Proveedor proveedor) {
        String sql = "INSERT INTO provedores (Cedula_Juridica, Nombre_Proveedor, Nombre_Contacto, Telefono, Correo_Electronico, Estado) "
                + "VALUES (?, ?, ?, ?, ?, ?)";
        try (PreparedStatement ps = _conn.prepareStatement(sql)) {
            ps.setString(1, proveedor.getcedulaJuridica());
            ps.setString(2, proveedor.getnombreProveedor());
            ps.setString(3, proveedor.getnombreContacto());
            ps.setString(4, proveedor.gettelefono());
            ps.setString(5, proveedor.getcorreoElectronico());
            ps.setString(6, proveedor.getestado());
            return ps.executeUpdate() > 0;

        }//ttry
        catch (SQLException e) {
            System.err.println("Error al insertar proovedor: " + e.getMessage());
            return false;
        }//catch
    }

    @Override
    public boolean actualizar(Proveedor proveedor) {
        String sql = "UPDATE provedores SET Nombre_Proveedor=?, Nombre_Contacto=?, "
                + "Telefono=?, Correo_Electronico=?, Estado=? "
                + "WHERE Cedula_Juridica=?";
        try (PreparedStatement ps = _conn.prepareStatement(sql)) {
            ps.setString(1, proveedor.getnombreProveedor());
            ps.setString(2, proveedor.getnombreContacto());
            ps.setString(3, proveedor.gettelefono());
            ps.setString(4, proveedor.getcorreoElectronico());
            ps.setString(5, proveedor.getestado());
             ps.setString(6, proveedor.getcedulaJuridica());
            return ps.executeUpdate() > 0;
        }//try
        catch (SQLException e) {
            System.err.println("Error al actualizar proveedor: " + e.getMessage());
            return false;
        }//catch  
    }

    @Override
    public Proveedor buscarPorCedula(String cedula) {
        String sql = "SELECT * FROM provedores WHERE Cedula_Juridica=?";
        try (PreparedStatement ps = _conn.prepareStatement(sql)) {
            ps.setString(1, cedula);
            try (ResultSet rs = ps.executeQuery()) {
                if (rs.next()) {
                    Proveedor p = new Proveedor();
                    p.setIdProvedor(rs.getInt("id_provedor"));
                    p.setcedulaJuridica(rs.getString("Cedula_Juridica"));
                    p.setnombreProveedor(rs.getString("Nombre_Proveedor"));
                    p.setnombreContacto(rs.getString("Nombre_Contacto"));
                    p.settelefono(rs.getString("Telefono"));
                    p.setcorreoElectronico(rs.getString("Correo_Electronico"));
                    p.setestado(rs.getString("Estado"));
                    return p;
                }
            }
        } catch (SQLException e) {
            System.err.println("Error al buscar proveedor: " + e.getMessage());
        }
        return null;
    }//buscarporcedula

    @Override
    public boolean existePorCedula(String cedula) {
        return buscarPorCedula(cedula) != null;
    }

    }//fin class
