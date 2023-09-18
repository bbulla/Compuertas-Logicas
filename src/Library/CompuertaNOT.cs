public class CompuertaNOT : Compuerta
{
    public CompuertaNOT(string nombre)
    {
        this.nombre = nombre;
        this.entradas = new Dictionary<string, object>();
        this.salida = null;
    }

    public override object Calcular()
    {
        if (entradas.ContainsKey("entrada") && entradas["entrada"] is int valor)
        {
            return valor == 1 ? 0 : 1;
        }
        else if (entradas.ContainsKey("entrada") && entradas["entrada"] is Compuerta compuerta)
        {
            var salida = (int)compuerta.Calcular();
            return salida == 0 ? 1 : 0;
        }
        return null;
    }
}
