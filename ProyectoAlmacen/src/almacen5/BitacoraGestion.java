package almacen5;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.time.format.DateTimeFormatter;
import java.util.concurrent.BlockingQueue;
import java.util.concurrent.LinkedBlockingQueue;

/**
 * Gestiona la bitácora del sistema de forma asíncrona.
 * Utiliza una cola bloqueante para almacenar entradas y un hilo daemon
 * que escribe en el archivo bitacora.json en formato JSON.
 * 
 * @author Steven
 */
public class BitacoraGestion {
    private static final String FILE_NOMBRE = "bitacora.json";// nombre del archivo
    private final BlockingQueue<BitacoraEntradas> queue;// cola FIFO thread-safe
    /*esto es gracias al blockingQueue(estructura de datos que funicona como FIFO) 
    hce cmo de bandeja de entrada donde se acumulan las entradas de bitácora antes de que el hilo las escriba en el archivo. 
    es bueno porque es thread-safe, si un hilo intenta sacar datos 
    y la cola está vacía se queda esperando a quue algo llegue*/
    
    private volatile boolean running;

    public BitacoraGestion() {
        this.queue = new LinkedBlockingQueue<>();
        this.running = true;

        // Si el archivo no existe, se crea con un encabezado de arreglo JSON
        inicializarArchivo();

        // Hilo que procesa la cola de entradas y escribe en el archivo
        Thread worker = new Thread(() -> {
            while (running) {
                try {
                    BitacoraEntradas entrada = queue.take(); // espera hasta que llegue algo
                    escribirEnArchivo(entrada);
                    System.out.println("Bitácora registrada: " + entrada.getTransaccion());
                } catch (InterruptedException e) {
                    Thread.currentThread().interrupt();
                }
            }
        });

        worker.setDaemon(true); // se cierra automáticamente al detener el programa
        worker.start();

        // Hook para cerrar la bitácora al salir del programa
        Runtime.getRuntime().addShutdownHook(new Thread(this::detener));
    }

    /**
     * Agrega una nueva entrada a la cola para ser escrita.
     */
    public void registrar(BitacoraEntradas entrada) {
        queue.offer(entrada);
    }

    /**
     * Escribe la entrada en el archivo JSON de la bitácora.
     */
    private synchronized void escribirEnArchivo(BitacoraEntradas entrada) {
        try (FileWriter fw = new FileWriter(FILE_NOMBRE, true)) {
            String json = String.format(
                "  { \"fechaHora\": \"%s\", \"transaccion\": \"%s\", \"datos\": \"%s\" },%n",
                entrada.getFechaHora().format(DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss")),
                entrada.getTransaccion(),
                entrada.getDatos().replace("\"", "\\\"") // escapo comillas
            );
            fw.write(json);
        } catch (IOException e) {
            System.err.println("Error escribiendo en bitácora: " + e.getMessage());
        }
    }

    /**
     * Inicializa el archivo si no existe, agregando el inicio del arreglo JSON.
     */
    private void inicializarArchivo() {
        try {
            File archivo = new File(FILE_NOMBRE);
            if (!archivo.exists()) {
                try (FileWriter fw = new FileWriter(FILE_NOMBRE, true)) {
                    fw.write("[\n"); // apertura del arreglo JSON
                }
            }
        } catch (IOException e) {
            System.err.println("No se pudo inicializar bitácora: " + e.getMessage());
        }
    }

    /**
     * Detiene la bitácora y cierra el arreglo JSON.
     */
    public void detener() {
        running = false;
        try (FileWriter fw = new FileWriter(FILE_NOMBRE, true)) {
            fw.write("]\n"); // cierre del arreglo JSON
        } catch (IOException e) {
            System.err.println("Error al cerrar bitácora: " + e.getMessage());
        }
    }
}
