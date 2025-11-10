import json
import os
from mysql.connector import Error
from Conexion import obtener_conexion
from datetime import datetime

BITACORA_FILE_CLIENTES = "bitacora.json"


# -----------------------------
# Guardar en bitácora
# -----------------------------
def guardar_bitacora_cliente(registro):
    """Guarda un registro en bitacora.json"""
    try:
        datos_existentes = []
        if os.path.exists(BITACORA_FILE_CLIENTES):
            with open(BITACORA_FILE_CLIENTES, "r", encoding="utf-8") as f:
                try:
                    datos_existentes = json.load(f)
                except json.JSONDecodeError:
                    datos_existentes = []

        datos_existentes.append(registro)
        with open(BITACORA_FILE_CLIENTES, "w", encoding="utf-8") as f:
            json.dump(datos_existentes, f, indent=4, ensure_ascii=False)

    except Exception as e:
        print(f"[ERROR] No se pudo guardar la bitácora: {e}")


# -----------------------------
# Procesar cliente
# -----------------------------
def procesar_cliente(trama_recibida):
    """Procesa una solicitud JSON y actualiza la base de datos"""
    try:
        trama = json.loads(trama_recibida) if isinstance(trama_recibida, str) else trama_recibida

        # ✅ Detectar estructura anidada
        datos = trama.get("datos") or trama
        if isinstance(datos.get("datos"), dict):
            datos = datos.get("datos")

        # Extraer campos
        identificacion = datos.get("Identificacion") or datos.get("identificacion")
        nombre = datos.get("Nombre") or datos.get("nombre")
        apellido1 = datos.get("Apellido1") or datos.get("apellido1")
        apellido2 = datos.get("Apellido2") or datos.get("apellido2", "")
        correo = datos.get("Correo") or datos.get("correo")
        telefono = datos.get("Telefono") or datos.get("telefono")
        direccion = datos.get("Direccion") or datos.get("direccion")
        transaccion = (datos.get("transaccion") or datos.get("Transaccion") or "desconocido").lower()

        # Validar campos básicos
        if not all([identificacion, nombre, apellido1, correo, telefono, direccion]):
            status = "1"  # Datos inválidos
            guardar_bitacora_cliente({
                "fecha_hora": datetime.now().strftime("%Y-%m-%d %H:%M:%S"),
                "tipo_transaccion": transaccion,
                "status": status,
                "datos": datos
            })
            return {"status": "1"}

        conexion = obtener_conexion()
        if not conexion:
            return {"status": "4"}  # Error no controlado

        cursor = conexion.cursor()

        # --- Transacción: AGREGAR ---
        if transaccion == "agregar":
            cursor.execute("SELECT COUNT(*) FROM clientes WHERE Identificacion = %s", (identificacion,))
            existe = cursor.fetchone()[0]
            if existe:
                guardar_bitacora_cliente({
                    "fecha_hora": datetime.now().strftime("%Y-%m-%d %H:%M:%S"),
                    "tipo_transaccion": transaccion,
                    "status": "2",  # Cliente ya existe
                    "datos": datos
                })
                return {"status": "2"}

            cursor.execute("""
                INSERT INTO clientes (
                    Identificacion, Nombre, Apellido1, Apellido2,
                    Correo, Telefono, Direccion
                ) VALUES (%s, %s, %s, %s, %s, %s, %s)
            """, (identificacion, nombre, apellido1, apellido2, correo, telefono, direccion))
            conexion.commit()
            status = "OK"

        # --- Transacción: MODIFICAR ---
        elif transaccion == "modificar":
            cursor.execute("SELECT COUNT(*) FROM clientes WHERE Identificacion = %s", (identificacion,))
            existe = cursor.fetchone()[0]
            if not existe:
                guardar_bitacora_cliente({
                    "fecha_hora": datetime.now().strftime("%Y-%m-%d %H:%M:%S"),
                    "tipo_transaccion": transaccion,
                    "status": "3",  # Cliente no existe
                    "datos": datos
                })
                return {"status": "3"}

            cursor.execute("""
                UPDATE clientes
                SET Nombre=%s, Apellido1=%s, Apellido2=%s,
                    Correo=%s, Telefono=%s, Direccion=%s
                WHERE Identificacion=%s
            """, (nombre, apellido1, apellido2, correo, telefono, direccion, identificacion))
            conexion.commit()
            status = "OK"

        # --- Transacción: BORRAR ---
        # --- Transacción: BORRAR ---
        elif transaccion == "borrar" or transaccion == "eliminar":
            cursor.execute("SELECT IdCliente FROM clientes WHERE Identificacion=%s", (identificacion,))
            resultado = cursor.fetchone()
            if not resultado:
                guardar_bitacora_cliente({
                    "fecha_hora": datetime.now().strftime("%Y-%m-%d %H:%M:%S"),
                    "tipo_transaccion": transaccion,
                    "status": "3",  # Cliente no existe
                    "datos": datos
                })
                return {"status": "3"}

            id_cliente = resultado[0]

            # ✅ Verificar si tiene compras asociadas
            cursor.execute("SELECT COUNT(*) FROM compras WHERE IdCliente=%s", (id_cliente,))
            tiene_compras = cursor.fetchone()[0]

            if tiene_compras > 0:
                status = "Error: cliente con historial de compras"
                guardar_bitacora_cliente({
                    "fecha_hora": datetime.now().strftime("%Y-%m-%d %H:%M:%S"),
                    "tipo_transaccion": transaccion,
                    "status": status,
                    "datos": datos
                })
                return {"status": status}

            # Si no tiene compras, se puede borrar
            cursor.execute("DELETE FROM clientes WHERE IdCliente=%s", (id_cliente,))
            conexion.commit()
            status = "OK"

        else:
            status = "4"  # Error no controlado

        # Guardar en bitácora
        guardar_bitacora_cliente({
            "fecha_hora": datetime.now().strftime("%Y-%m-%d %H:%M:%S"),
            "tipo_transaccion": transaccion,
            "status": status,
            "datos": datos
        })

        return {"status": status}

    except Exception as e:
        print(f"[ERROR] {e}")
        guardar_bitacora_cliente({
            "fecha_hora": datetime.now().strftime("%Y-%m-%d %H:%M:%S"),
            "tipo_transaccion": "desconocido",
            "status": "4",
            "error": str(e)
        })
        return {"status": "4"}

    finally:
        try:
            if 'cursor' in locals():
                cursor.close()
            if 'conexion' in locals() and conexion.is_connected():
                conexion.close()
        except Exception as e:
            print(f"[ERROR] Error al cerrar conexión: {e}")
