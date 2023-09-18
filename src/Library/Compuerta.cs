namespace Library;
using System;
using System.Collections.Generic;

public abstract class Compuerta
{
    protected string nombre;
    protected Dictionary<string, object> entradas;
    protected object salida;

    public string GetNombre()
    {
        return nombre;
    }

    public void AgregarEntrada(string conector, object valor)
    {
        entradas[conector] = valor;
    }

    public abstract object Calcular();
}