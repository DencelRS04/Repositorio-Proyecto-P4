/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package almacen2.util;

public class Validaciones {
    
    //validar que tenga 10 dpigitos la cédula
    public static boolean validarCedula(String cedula){
        return cedula !=null && cedula.matches("\\d{10}");
    }
    
    //aquí que el telef tenga 8 digitos de CR
    public static boolean validarTelefono(String telefono){
    return telefono!=null && telefono.matches("\\d{8}");
    }
    
    //Aquí que el correo tenga regex simple
    public static boolean validarCorreo(String correo){
    return correo!=null  && correo.matches("^[A-Za-z0-9+_.-]+@[A-Za-z0-9.-]+$");
    }
    
    //este es para los campos de texto 
    public static boolean noPermiteVacio(String valor){
        return valor !=null && !valor.trim().isEmpty();
    }
    
    
    
}//fin public
