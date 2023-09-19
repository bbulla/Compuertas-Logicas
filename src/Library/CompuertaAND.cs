public class CompuertaAND : Compuerta
{
    public CompuertaAND(string nombre)
    {
        this.nombre = nombre;
        this.entradas = new Dictionary<string, object>();
        this.salida = null;
    }

    public override object Calcular()
    {
        int prod = 1;
        foreach (var elemento in entradas)
        {
            if (elemento.Value is int valor && (valor == 0 || valor == 1))
            {
                prod *= valor;
            }
            else if (elemento.Value is Compuerta compuerta)
            {
                prod *= (int)compuerta.Calcular();
            }
        }
        return prod;
    }
}
