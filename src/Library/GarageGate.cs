using Library.BasicGates;

namespace Library
{
    /// <summary>
    /// Es la puerta del garage. 
    /// </summary>
    // Nota1: Como sólo hay una única puerta de garage con una única estructura, entonces dejamos la clase como estática.
    // Nota2: Ver imágenes de la carpeta docs.
    // °Estereotipo: "Information holder" porque conoce su estructura (circuito de compuertas). Puede realizar cálculos a partir de los datos que posee, por ejemplo, cuando va a calcular si la puerta está abierta.
    public static class GarageGate
    {
        #region ATRIBUTOS

        // Variables simples que entran en el diseño del circuito.
        private static SimpleVariable a = new SimpleVariable("A", false);
        private static SimpleVariable b = new SimpleVariable("B", false);
        private static SimpleVariable c = new SimpleVariable("C", false);

        // Compuertas lógicas que entran en el diseño del circuito.
        private static NotGate FGate = new NotGate("FGate");
        private static NotGate EGate = new NotGate("EGate");
        private static AndGate DGate = new AndGate("DGate");
        private static AndGate CGate = new AndGate("CGate");
        private static OrGate BGate = new OrGate("BGate");
        private static AndGate AGate = new AndGate("AGate");
        #endregion

        #region MÉTODOS

        /// <summary>
        /// Prepara el circuito, es decir, acomoda las entradas de las compuertas antecesoras. Ver imagen del circuito en docs.
        /// </summary>
        public static void SetGarageGate()
        {
            AGate.AddInput(c);
            AGate.AddInput(BGate);

            BGate.AddInput(CGate);
            BGate.AddInput(DGate);

            CGate.AddInput(a);
            CGate.AddInput(b);

            DGate.AddInput(EGate);
            DGate.AddInput(FGate);

            EGate.AddInput(b);

            FGate.AddInput(a);
        }

        // Si la puerta está abierta o cerrada dependerá de los valores de "a", "b" y "c", por lo tanto, los siguientes tres métodos permiten cambiar esos valores.
        public static void ChangeAValue(bool booleanValue)
        {
            a.Value = booleanValue;
            if (a.Value == true)
            {
                Console.WriteLine("The button A is pressed.");
            }
            else
            {
                Console.WriteLine("The button A is not pressed.");
            }
        }
        public static void ChangeBValue(bool booleanValue)
        {
            b.Value = booleanValue;
            if (b.Value == true)
            {
                Console.WriteLine("The button B is pressed.");
            }
            else
            {
                Console.WriteLine("The button B is not pressed.");
            }
        }
        public static void ChangeCValue(bool booleanValue)
        {
            c.Value = booleanValue;
            if (c.Value == true)
            {
                Console.WriteLine("The button C is pressed.");
            }
            else
            {
                Console.WriteLine("The button C is not pressed.");
            }
        }

        /// <summary>
        /// Indica si la puerta del garage está abierta o cerrada.
        /// </summary>
        /// <returns></returns>
        public static bool ItIsOpen()
        {
            bool result = AGate.CalculateInput();
            if (result == true)
            {
                Console.WriteLine("The garage gate is open.");
                return true;
            }
            else
            {
                Console.WriteLine("The garage gate is close.");
                return false;
            }
        }
        #endregion
    }
}