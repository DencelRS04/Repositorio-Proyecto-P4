import socket
import json
from datetime import datetime
from zoneinfo import ZoneInfo

# ========================
# CONFIGURACIÓN
# ========================
HOST = "127.0.0.1"  # mismo host del servidor
PORT = 5000         # mismo puerto del servidor
BUFFER_SIZE = 8192

# ========================
# FUNCIÓN PARA ENVIAR TRAMA
# ========================
def enviar_trama(trama: dict):
    try:
        with socket.create_connection((HOST, PORT), timeout=5) as s:
            s.sendall(json.dumps(trama).encode())
            respuesta = s.recv(BUFFER_SIZE)
            if respuesta:
                return json.loads(respuesta.decode())
            else:
                return {"status": "4"}
    except Exception as e:
        print("Error comunicando con el servidor:", e)
        return {"status": "4"}


