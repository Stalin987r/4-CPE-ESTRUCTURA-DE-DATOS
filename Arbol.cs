namespace GraficaArboles
{
    class Arbol
    {
        public Nodo Raiz;

        public Arbol()
        {
            this.Raiz = null;
        }

        public void Insertar(int nota, string nombre)
        {
            Raiz = InsertarNodo(Raiz, nota, nombre);
        }

        private Nodo InsertarNodo(Nodo actual, int nota, string nombre)
        {
            if (actual == null)
                return new Nodo(nota, nombre);

            if (nota < actual.Nota)
                actual.Izquierdo = InsertarNodo(actual.Izquierdo, nota, nombre);
            else if (nota > actual.Nota)
                actual.Derecho = InsertarNodo(actual.Derecho, nota, nombre);
            else
                System.Console.WriteLine("Nota repetida, se ignora: " + nota);

            return actual;
        }

        public void InOrden(Nodo actual)
        {
            if (actual == null)
                return;

            InOrden(actual.Izquierdo);
            System.Console.WriteLine(actual.Nombre + " -> " + actual.Nota);
            InOrden(actual.Derecho);
        }

        public Nodo Buscar(int nota)
        {
            Nodo actual = Raiz;
            while (actual != null)
            {
                if (nota == actual.Nota)
                    return actual;

                if (nota < actual.Nota)
                    actual = actual.Izquierdo;
                else
                    actual = actual.Derecho;
            }
            return null;
        }

        public void Dibujar(Nodo actual, int nivel)
        {
            if (actual == null)
                return;

            Dibujar(actual.Derecho, nivel + 1);

            for (int i = 0; i < nivel; i++)
                System.Console.Write("    ");

            System.Console.WriteLine(actual.Nota);

            Dibujar(actual.Izquierdo, nivel + 1);
        }
    }
}