package almacen3.util;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class ConexionBD {
    private static final String URL =
        "jdbc:sqlserver://PCANCHA\\SQLSERVER:1433;"
      + "databaseName=AlmacenDB;"
      + "encrypt=true;"
      + "trustServerCertificate=true;"
      + "integratedSecurity=true";

    public static Connection getConnection() throws SQLException {
        return DriverManager.getConnection(URL);
    }
}
