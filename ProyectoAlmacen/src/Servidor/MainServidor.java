/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */
package Servidor;
import javax.xml.ws.Endpoint;

/**
 *
 * @author XPC
 */
public class MainServidor {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
         String url = "http://localhost:8080/AlmacenServiceJava";
        System.out.println("📦 Publicando servicio en: " + url);
        Endpoint.publish(url, new AlmacenServiceJava());
        System.out.println("✅ Servicio activo y esperando peticiones...");
    }
    
}
