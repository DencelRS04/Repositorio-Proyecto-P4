import json
import threading
import time
from datetime import datetime
from queue import Queue
import os

# =====================================================
# CONFIGURACIÓN
# =====================================================
BITACORA_PATH = "bitacora.json"

# Cola compartida para solicitudes de escritura
cola_bitacora = Queue()

# =====================================================
# HILO SECUNDARIO: ESCRIBE BITÁCORA EN SEGUNDO PLANO
# =====================================================
def hilo_escritor_bitacora():
    """
    Hilo que se ejecuta en segundo plano.
    Extrae mensajes de la cola y los escribe en bitacora.json
    """
    print("[Bitácora] Hilo de escritura iniciado.")
    while True:
        registro = cola_bitacora.get()  # Espera un nuevo elemento en la cola
        if registro == "STOP":
            print("[Bitácora] Hilo detenido.")
            break

        try:
            # Si el archivo no existe, se crea
            if not os.path.exists(BITACORA_PATH):
                with open(BITACORA_PATH, "w", encoding="utf-8") as f:
                    json.dump([], f, indent=4)

            # Leer contenido actual
            with open(BITACORA_PATH, "r", encoding="utf-8") as f:
                contenido = json.load(f)

            # Agregar nuevo registro
            contenido.append(registro)

            # Guardar nuevamente
            with open(BITACORA_PATH, "w", encoding="utf-8") as f:
                json.dump(contenido, f, ensure_ascii=False, indent=4)

            print(f"[Bitácora] Registro agregado: {registro['tipo_transaccion']} - {registro['status']}")

        except Exception as e:
            print(f"[Bitácora] Error al escribir: {e}")
        finally:
            cola_bitacora.task_done()
        time.sleep(0.2)  # Pequeña pausa para no sobrecargar CPU

# =====================================================
# FUNCIÓN PARA AGREGAR A LA BITÁCORA
# =====================================================
def registrar_bitacora(tipo_transaccion, datos, status):
    """
    Envía una entrada a la cola para registrar en bitácora.
    - tipo_transaccion: "cliente" o "compra"
    - datos: diccionario o trama JSON original
    - status: resultado ("OK", "1", "2", etc.)
    """
    registro = {
        "fecha_hora": datetime.now().strftime("%Y-%m-%d %H:%M:%S"),
        "tipo_transaccion": tipo_transaccion,
        "status": status,
        "datos": datos
    }
    cola_bitacora.put(registro)
    print(f"[Bitácora] Encolado registro: {tipo_transaccion}")

# =====================================================
# INICIO AUTOMÁTICO DEL HILO
# =====================================================
def iniciar_hilo_bitacora():
    hilo = threading.Thread(target=hilo_escritor_bitacora, daemon=True)
    hilo.start()
    return hilo

# =====================================================
# DEMO / PRUEBA INDEPENDIENTE
# =====================================================
if __name__ == "__main__":
    # Iniciar hilo
    hilo = iniciar_hilo_bitacora()

    # Simular registros
    registrar_bitacora("cliente", {"Identificacion": "10101010", "Transaccion": "agregar"}, "OK")
    registrar_bitacora("compra", {"NumeroCompra": "C001", "Total": 15000}, "1")
    registrar_bitacora("cliente", {"Identificacion": "10101010", "Transaccion": "borrar"}, "Error: cliente con historial")

    # Esperar a que se procese la cola
    cola_bitacora.join()

    # Detener hilo (opcional)
    cola_bitacora.put("STOP")
    hilo.join()
