/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package almacen2.util;

/**
 *
 * @author steve
 */
public class TramaUtils {

    //rellenar los espacios de la derecha con espacios
    public static String padRight(String s, int n) {
        if (s == null) {
            s = "";
        }
        if (s.length() >= n) {
            return s.substring(0, n);
        }
        StringBuilder sb = new StringBuilder(s);
        while (sb.length() < n) {
            sb.append(' ');
        }
        return sb.toString();

    }// fin pad
    //rellenar izquierda

    public static String padLeftZeros(String s, int n) {
        if (s == null) {
            s = "";
        }
        if (s.length() >= n) {
            return s.substring(s.length() - n);
        }
        StringBuilder sb = new StringBuilder();
        while (sb.length() + s.length() < n) {
            sb.append('0');
        }
        sb.append(s);
        return sb.toString();

    }//fin pad izq
}
