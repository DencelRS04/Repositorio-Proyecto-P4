import mysql.connector
from mysql.connector import Error

try:
    conn = mysql.connector.connect(
        host='localhost',
        user='root',
        password='2004',
        database='vericadordb'
    )
    if conn.is_connected():
        print("✅ Conexión a MySQL exitosa.")
except Error as e:
    print("❌ Error al conectar:", e)
