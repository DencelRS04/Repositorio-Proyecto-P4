import socket
import threading
import json
from verificador_clientes import procesar_cliente
from verificador_compras import procesar_compra
from verificador_bitacora import iniciar_hilo_bitacora, registrar_bitacora

# ========================
# CONFIGURACIÓN
# ========================
HOST = "127.0.0.1"
PORT = 5001  # Puerto configurable

# ========================
# INICIAR HILO BITÁCORA
# ========================
iniciar_hilo_bitacora()
print("[Sistema] Hilo de bitácora iniciado.")

# ========================
# FUNCION PARA ATENDER CLIENTE
# ========================
def atender_cliente(conn, addr):
    print(f"[Conexión] Cliente conectado desde {addr}")
    try:
        data = conn.recv(8192)
        if not data:
            conn.close()
            return

        # Decodificar UTF-8
        texto_trama = data.decode('utf-8').strip()
        try:
            # Intentar convertir a JSON
            trama = json.loads(texto_trama)
        except json.JSONDecodeError:
            # Si no es JSON, manejar como cadena
            trama = {"raw": texto_trama}

        tipo_transaccion = trama.get("TipoTransaccion", "").lower() if isinstance(trama, dict) else "desconocida"
        respuesta = {}

        # ------------------------------
        # Determinar tipo de solicitud
        # ------------------------------
        if "Identificacion" in trama:
            # HU1 – Clientes
            respuesta = procesar_cliente(trama)
            registrar_bitacora("cliente", trama, respuesta.get("status"))
        elif"datos" in trama and "numero_compra" in trama["datos"]:
            respuesta = procesar_compra(trama)
            registrar_bitacora("compra", trama, respuesta.get("status"))
        else:
            respuesta = {"status": "4"}  # error no controlado
            registrar_bitacora("desconocido", trama, "4")

        # ------------------------------
        # Enviar respuesta al cliente como UTF-8
        # ------------------------------
        conn.sendall(json.dumps(respuesta).encode('utf-8'))

    except Exception as e:
        print(f"[Error] Al procesar la solicitud: {e}")
        conn.sendall(json.dumps({"status": "4"}).encode('utf-8'))
    finally:
        conn.close()
        print(f"[Conexión] Cliente desconectado: {addr}")

# ========================
# SERVIDOR TCP PRINCIPAL
# ========================
def iniciar_servidor():
    server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server.bind((HOST, PORT))
    server.listen(5)
    print(f"[Servidor] Verificador escuchando en {HOST}:{PORT}")

    while True:
        conn, addr = server.accept()
        threading.Thread(target=atender_cliente, args=(conn, addr), daemon=True).start()

# ========================
# MAIN
# ========================
if __name__ == "__main__":
    try:
        iniciar_servidor()
    except KeyboardInterrupt:
        print("[Servidor] Detenido por usuario.")
