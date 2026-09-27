namespace GraficaArboles
{
    class Program
    {
        static void Main(string[] args)
        {
            // Leer las notas desde el archivo
            string[] lineas = System.IO.File.ReadAllLines("notas.txt");

            // ---- Ejemplo 1: Arbol ----
            Arbol arbolNotas = new Arbol();

            System.DateTime inicio = System.DateTime.Now;
            for (int i = 0; i < lineas.Length; i++)
            {
                string[] partes = lineas[i].Split(':');
                string nombre = partes[0];
                int nota = System.Convert.ToInt32(partes[1]);
                arbolNotas.Insertar(nota, nombre);
            }
            System.DateTime fin = System.DateTime.Now;
            System.TimeSpan duracion = fin - inicio;

            System.Console.WriteLine("Tiempo de construccion del arbol: " + duracion.TotalMilliseconds + " ms");
            System.Console.WriteLine();

            System.Console.WriteLine("--- Reporte del arbol (inorden) ---");
            arbolNotas.InOrden(arbolNotas.Raiz);

            System.Console.WriteLine();
            System.Console.WriteLine("--- Dibujo del arbol ---");
            arbolNotas.Dibujar(arbolNotas.Raiz, 0);

            System.Console.WriteLine();
            System.Console.WriteLine("--- Buscar estudiante con nota 90 ---");
            Nodo resultado = arbolNotas.Buscar(90);
            if (resultado != null)
                System.Console.WriteLine("Encontrado: " + resultado.Nombre + " - " + resultado.Nota);
            else
                System.Console.WriteLine("No se encontro ningun estudiante con esa nota");

            // ---- Ejemplo 2: Grafo ----
            Grafo red = new Grafo();
            for (int i = 0; i < lineas.Length; i++)
            {
                string[] partes = lineas[i].Split(':');
                red.AgregarNodo(partes[0]);
            }

            red.AgregarConexion("Ana", "Luis");
            red.AgregarConexion("Ana", "Maria");
            red.AgregarConexion("Luis", "Pedro");
            red.AgregarConexion("Maria", "Sofia");
            red.AgregarConexion("Sofia", "Carlos");
            red.AgregarConexion("Carlos", "Elena");

            System.Console.WriteLine();
            System.Console.WriteLine("--- Reporte del grafo ---");
            red.Mostrar();

            System.Console.WriteLine();
            System.Console.WriteLine("--- Recorrido BFS desde Ana ---");
            red.BFS("Ana");

            System.Console.WriteLine();
            System.Console.WriteLine("Presione una tecla para salir...");
            System.Console.ReadKey();
        }
    }
}