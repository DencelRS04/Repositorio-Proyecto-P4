package almacen3.util;

public class TramaUtilsAlm3 {

    // Rellenar los espacios a la derecha con espacios
    public static String padRight(String s, int n) {
        if (s == null) s = "";
        if (s.length() >= n) return s.substring(0, n);
        StringBuilder sb = new StringBuilder(s);
        while (sb.length() < n) sb.append(' ');
        return sb.toString();
    }

    // Rellenar a la izquierda con ceros
    public static String padLeftZeros(String s, int n) {
        if (s == null) s = "";
        if (s.length() >= n) return s.substring(s.length() - n);
        StringBuilder sb = new StringBuilder();
        while (sb.length() + s.length() < n) sb.append('0');
        sb.append(s);
        return sb.toString();
    }
}
