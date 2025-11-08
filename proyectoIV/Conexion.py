import mysql.connector
from mysql.connector import Error

# ========================
# CONFIGURACIÓN DE CONEXIÓN
# ========================
config = {
    'host': 'localhost',
    'user': 'root',
    'password': '2004',  # tu contraseña
    'database': 'vericadordb'
}

# ========================
# FUNCIÓN PARA OBTENER CONEXIÓN
# ========================
def obtener_conexion():
    """
    Crea y devuelve una conexión activa a la base de datos MySQL.
    Retorna None si ocurre un error.
    """
    try:
        conn = mysql.connector.connect(**config)
        if conn.is_connected():
            print("Conexión a MySQL exitosa.")
            return conn
    except Error as e:
        print("Error al conectar a MySQL:", e)
        return None


# ========================
# FUNCIÓN PARA CERRAR CONEXIÓN
# ========================
def cerrar_conexion(conn, cursor=None):
    """
    Cierra el cursor y la conexión si están abiertos.
    """
    try:
        if cursor is not None and not cursor.closed:
            cursor.close()
        if conn is not None and conn.is_connected():
            conn.close()
            print("Conexión cerrada correctamente.")
    except Error as e:
        print("Error al cerrar la conexión:", e)


# ========================
# FUNCIÓN PARA MOSTRAR COMPRAS
# ========================
def mostrar_compras(conn):
    """
    Muestra todos los registros de la tabla 'compra'.
    """
    try:
        cursor = conn.cursor()
        cursor.execute("""
            SELECT 
                IdCompra,
                NumeroIngreso,
                FechaCompra,
                CedulaJuridica,
                DetalleCompra,
                NumeroTarjeta,
                FechaVencimiento,
                CodigoSeguridad,
                NumeroProducto,
                Cantidad
            FROM compra
            ORDER BY IdCompra DESC;
        """)
        compras = cursor.fetchall()
        print("\n=== REGISTROS EN TABLA 'compra' ===")
        for comp in compras:
            print(comp)
        cursor.close()
    except Error as e:
        print("Error al consultar la base de datos:", e)


# ========================
# BLOQUE PRINCIPAL (PRUEBA)
# ========================
if __name__ == "__main__":
    conn = obtener_conexion()
    if conn:
        from Conexion import mostrar_compras
        mostrar_compras(conn)
        cerrar_conexion(conn)

