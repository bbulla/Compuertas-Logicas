namespace Library.BasicGates
{
    /// <summary>
    /// Compuerta NOT. Tiene una sola entrada y su salida es el valor opuesto de su entrada.
    /// </summary>
    // °Estereotipo: "Information holder" porque conoce sus entradas y proporciona información. Puede realizar cálculos a partir de los datos que posee, por ejemplo, cuando va a calcular la salida.
    public class NotGate : IGate
    {
        #region ATRIBUTOS
        /// <summary>
        /// Es la entrada simple, es decir, la que no depende de una compuerta.
        /// </summary>
        private SimpleVariable? simpleInput = null;

        /// <summary>
        /// Es la compuerta antecesora de la actual
        /// </summary>
        private IGate? inputGate = null;

        /// <summary>
        /// Es el nombre de la compuerta actual. Sólo sirve como un identificador para el usuario del programa.
        /// </summary>
        private string _name;
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Retorna o cambia el nombre de la compuerta.
        /// </summary>
        /// <value>Nombre de compuerta.</value>
        public string Name
        {
            get { return _name; }
            set
            {
                if (!String.IsNullOrEmpty(value) && !String.IsNullOrWhiteSpace(value))
                {
                    _name = value;
                }
                else
                {
                    Console.WriteLine("Invalid name of gate.");
                }
            }
        }
        #endregion

        #region MÉTODOS
        /// <summary>
        /// Método constructor de compuertas NOT.
        /// </summary>
        /// <param name="gateName">Nombre de la compuerta.</param>
        public NotGate(string gateName)
        {
            _name = gateName;
        }

        /// <summary>
        /// Establece la variable simple de la compuerta (distinta a nulo).
        /// </summary>
        /// <param name="simpleNewInput"></param>
        public void AddInput(SimpleVariable simpleNewInput)
        {
            if (simpleInput == null && inputGate == null)
            {
                // Se agrega la entrada simple.
                this.simpleInput = simpleNewInput;
            }
            else
            {
                // Se avisa al usuario que la variable no puede agregarse porque ya tiene una entrada.
                Console.WriteLine($"The gate already has one input.");
            }
        }

        /// <summary>
        /// Remueve una entrada simple existente (cambia el atributo de variable simple a nulo).
        /// </summary>
        /// <param name="existingSimpleInput"></param>
        public void RemoveInput(SimpleVariable existingSimpleInput)
        {
            if (simpleInput == existingSimpleInput)
            {
                // Se quita la entrada simple.
                this.simpleInput = null;
            }
            else
            {
                // Se avisa al usuario que la variable no puede quitarse porque no corresponde con la variable simple ya establecida.
                Console.WriteLine($"The variable is not a simple variable of '{this.Name}' gate.");
            }
        }

        /// <summary>
        /// Establece la compuerta antecesora de la compuerta actual (distinta a nulo).
        /// </summary>
        /// <param name="gate"></param>
        public void AddInput(IGate gate)
        {
            if (simpleInput == null && inputGate == null)
            {
                this.inputGate = gate;
            }
            else
            {
                // Se avisa al usuario que la compuerta no puede agregarse porque hay una entrada existente.
                Console.WriteLine($"The gate already has one input.");
            }
        }

        /// <summary>
        /// Remueve una compuerta existente de la lista de compuertas antecesoras de la actual.
        /// </summary>
        /// <param name="gate"></param>
        public void RemoveInput(IGate existingInputGate)
        {
            if (inputGate == existingInputGate)
            {
                // Se quita la compuerta antecesora.
                inputGate = null;
            }
            else
            {
                // Se avisa al usuario que la compuerta no puede quitarse porque no corresponde con la compuerta antecesora establecida.
                Console.WriteLine($"'{existingInputGate.Name}' gate is not a input gate of '{this.Name} gate.'");
            }
        }

        /// <summary>
        /// Retorna la salida de la compuerta a partir de sus entradas.
        /// </summary>
        /// <returns>Una única salida.</returns>
        public bool CalculateInput()
        {
            if ((simpleInput != null && inputGate != null) || (simpleInput == null && inputGate == null))
            {
                // Se avisa al usuario que no se puede calcular correctamente una salida, ya que no hay ninguna entrada.
                Console.WriteLine("The gate only calculate if has an one input.");
                return false;
            }
            else
            {
                if (inputGate == null)
                {
                    return !simpleInput.Value;
                }
                else
                {
                    return !inputGate.CalculateInput();
                }
            }
        }
        #endregion
    }
}