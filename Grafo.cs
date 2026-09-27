namespace GraficaArboles
{
    class Grafo
    {
        private System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> lista;

        public Grafo()
        {
            this.lista = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>>();
        }

        public void AgregarNodo(string nombre)
        {
            if (!lista.ContainsKey(nombre))
                lista[nombre] = new System.Collections.Generic.List<string>();
        }

        public void AgregarConexion(string a, string b)
        {
            AgregarNodo(a);
            AgregarNodo(b);

            lista[a].Add(b);
            lista[b].Add(a);
        }

        public void Mostrar()
        {
            foreach (System.Collections.Generic.KeyValuePair<string, System.Collections.Generic.List<string>> par in lista)
            {
                System.Console.Write(par.Key + " -> ");
                System.Console.WriteLine(string.Join(", ", par.Value));
            }
        }

        public void BFS(string inicio)
        {
            if (!lista.ContainsKey(inicio))
                return;

            System.Collections.Generic.List<string> visitados = new System.Collections.Generic.List<string>();
            System.Collections.Generic.Queue<string> cola = new System.Collections.Generic.Queue<string>();

            cola.Enqueue(inicio);
            visitados.Add(inicio);

            System.Console.Write("Recorrido: ");

            while (cola.Count > 0)
            {
                string actual = cola.Dequeue();
                System.Console.Write(actual + " ");

                foreach (string vecino in lista[actual])
                {
                    if (!visitados.Contains(vecino))
                    {
                        visitados.Add(vecino);
                        cola.Enqueue(vecino);
                    }
                }
            }
            System.Console.WriteLine();
        }
    }
}