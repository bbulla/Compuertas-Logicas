public class CompuertaOR : Compuerta
{
    public CompuertaOR(string nombre)
    {
        this.nombre = nombre;
        this.entradas = new Dictionary<string, object>();
        this.salida = null;
    }

    public override object Calcular()
    {
        int suma = 0;
        foreach (var elemento in entradas)
        {
            if (elemento.Value is int valor && (valor == 0 || valor == 1))
            {
                suma += valor;
            }
            else if (elemento.Value is Compuerta compuerta)
            {
                suma += (int)compuerta.Calcular();
            }
        }
        return suma;
    }
}
