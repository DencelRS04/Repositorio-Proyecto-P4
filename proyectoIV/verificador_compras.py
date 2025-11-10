import base64
import json
import os
from mysql.connector import Error
from Conexion import obtener_conexion

BITACORA_FILE = "bitacora.json"

def guardar_bitacora(registro):
    """
    Guarda un registro en bitacora.json.
    Si el archivo no existe, lo crea.
    """
    datos = []
    if os.path.exists(BITACORA_FILE):
        try:
            with open(BITACORA_FILE, "r", encoding="utf-8") as f:
                datos = json.load(f)
        except json.JSONDecodeError:
            datos = []

    datos.append(registro)

    with open(BITACORA_FILE, "w", encoding="utf-8") as f:
        json.dump(datos, f, indent=4, ensure_ascii=False)


def procesar_compra(trama):
    """
    Procesa un JSON recibido desde C# y guarda la compra en la tabla 'compra'.
    Funciona si 'productos' es un dict o una lista, y acepta diferentes estilos de nombres.
    También guarda automáticamente la compra en bitacora.json.
    """

    try:
        print("[DEBUG] Trama recibida:", trama)  # Para depuración

        # 1️⃣ Extraer los datos principales
        datos = trama.get("datos") or trama.get("Datos") or trama
        if not datos:
            print("[DB] No se encontraron datos en la trama.")
            return {"status": "4"}

        # Mapear campos flexibles
        numero_compra = datos.get("numero_compra") or datos.get("numeroCompra")
        fecha_compra = datos.get("fecha_compra") or datos.get("fechaCompra")
        id_cliente = datos.get("id_cliente") or datos.get("idCliente")
        tarjeta_b64 = datos.get("tarjeta") or datos.get("Tarjeta")
        vencimiento_b64 = datos.get("vencimiento") or datos.get("Vencimiento")
        cvv_b64 = datos.get("cvv") or datos.get("CVV")
        productos = datos.get("productos") or datos.get("Productos") or []

        # Convertir a lista si llega como dict (un solo producto)
        if isinstance(productos, dict):
            productos = [productos]

        if not numero_compra or not fecha_compra or not id_cliente or not productos:
            print("[DB] Faltan campos obligatorios en la trama.")
            return {"status": "4"}

        # 2️⃣ Decodificar Base64
        try:
            numero_tarjeta = base64.b64decode(tarjeta_b64).decode("utf-8")
            vencimiento = base64.b64decode(vencimiento_b64).decode("utf-8")
            cvv = base64.b64decode(cvv_b64).decode("utf-8")
        except Exception as e:
            print(f"[DB] Error al decodificar Base64: {e}")
            return {"status": "4"}

        # 3️⃣ Conectar a MySQL
        conexion = obtener_conexion()
        if not conexion:
            print("[DB] No se pudo conectar a MySQL.")
            return {"status": "4"}

        cursor = conexion.cursor()

        # 4️⃣ Insertar cada producto
        for producto in productos:
            codigo_producto = producto.get("codigo") or producto.get("Codigo")
            detalle = producto.get("detalle") or producto.get("Detalle") or ""
            cantidad = producto.get("cantidad") or producto.get("Cantidad") or 1

            if not codigo_producto:
                print("[DB] Producto sin código, se omite.")
                continue

            cursor.execute("""
                INSERT INTO compra (
                    NumeroIngreso, FechaCompra, CedulaJuridica, DetalleCompra,
                    NumeroTarjeta, FechaVencimiento, CodigoSeguridad,
                    NumeroProducto, Cantidad
                ) VALUES (%s, %s, %s, %s, %s, %s, %s, %s, %s)
            """, (
                numero_compra,
                fecha_compra,
                id_cliente,
                detalle,
                numero_tarjeta,
                vencimiento,
                cvv,
                codigo_producto,
                cantidad
            ))

        conexion.commit()
        print(f"[DB] Compra {numero_compra} registrada correctamente con {len(productos)} producto(s).")

        # 5️⃣ Guardar en bitacora.json
        registro = {
            "numero_compra": numero_compra,
            "id_cliente": id_cliente,
            "fecha_compra": fecha_compra,
            "productos": productos
        }
        guardar_bitacora(registro)

        return {"status": "1"}

    except Error as e:
        print(f"[DB] Error en la base de datos: {e}")
        if 'conexion' in locals() and conexion.is_connected():
            conexion.rollback()
        return {"status": "4"}

    except Exception as e:
        print(f"[DB] Error general: {e}")
        return {"status": "4"}

    finally:
        # 🔹 Cierre seguro de cursor y conexión
        try:
            if 'cursor' in locals() and cursor:
                cursor.close()
        except Exception as e:
            print(f"[DB] Error al cerrar cursor: {e}")

        try:
            if 'conexion' in locals() and conexion.is_connected():
                conexion.close()
        except Exception as e:
            print(f"[DB] Error al cerrar conexión: {e}")
