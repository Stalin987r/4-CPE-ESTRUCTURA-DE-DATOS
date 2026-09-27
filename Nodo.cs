namespace GraficaArboles
{
    class Nodo
    {
        public int Nota;
        public string Nombre;
        public Nodo Izquierdo;
        public Nodo Derecho;

        public Nodo(int nota, string nombre)
        {
            this.Nota = nota;
            this.Nombre = nombre;
            this.Izquierdo = null;
            this.Derecho = null;
        }
    }
}