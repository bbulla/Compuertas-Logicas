namespace Library.BasicGates
{
    /// <summary>
    /// Compuerta AND. Tiene al menos dos entradas y si todas sus entradas son true, entonces su salida será true.
    /// </summary>
    // °Estereotipo: "Information holder" porque conoce sus entradas y proporciona información. Puede realizar cálculos a partir de los datos que posee, por ejemplo, cuando va a calcular la salida.
    public class AndGate : IGate
    {
        #region ATRIBUTOS
        /// <summary>
        /// Son las entradas simples, es decir, las que no dependen de una compuerta.
        /// </summary>
        private List<SimpleVariable> simpleInputs = new();

        /// <summary>
        /// Son las compuertas antecesoras de la compuerta actual, las cuales sus salidas son entradas
        /// de la compuerta actual.
        /// </summary>
        private List<IGate> inputGates = new();

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
        /// Método constructor de compuertas AND.
        /// </summary>
        /// <param name="gateName"></param>
        public AndGate(string gateName)
        {
            _name = gateName;
        }

        /// <summary>
        /// Agrega una entrada simple a la lista de entradas simples de la compuerta.
        /// </summary>
        /// <param name="simpleInput"></param>
        public void AddInput(SimpleVariable simpleInput)
        {
            // Se supone que la entrada simple puede agregarse.
            bool isCapableToAdd = true;
            if (simpleInputs.Count > 0)
            {
                // Se itera con la lista de entradas simples.
                foreach (SimpleVariable existingSimpleInput in this.simpleInputs)
                {
                    if (simpleInput.Name == existingSimpleInput.Name)
                    {
                        // Si coincide el nombre de una entrada simple que quiere agregarse con una existente en la lista,
                        // entonces no se agrega (para evitar inconsistencias del circuito eléctrico).
                        isCapableToAdd = false;
                        // Break para no realizar pasos innecesarios.
                        break;
                    }
                }
            }
            if (isCapableToAdd == true)
            {
                // Se agrega la entrada simple.
                simpleInputs.Add(simpleInput);
            }
            else
            {
                // Se avisa al usuario que la variable no puede agregarse por coincidencia de nombre.
                Console.WriteLine($"The variable has the same name of an existing variable between simple inputs of '{this.Name}' gate.");
            }
        }

        /// <summary>
        /// Remueve una entrada simple existente de la lista de entradas simples de la compuerta.
        /// </summary>
        /// <param name="simpleInput"></param>
        public void RemoveInput(SimpleVariable simpleInput)
        {
            if (simpleInputs.Contains(simpleInput))
            {
                // Se quita la entrada simple.
                simpleInputs.Remove(simpleInput);
            }
            else
            {
                // Se avisa al usuario que la variable no puede quitarse porque no existe en la lista.
                Console.WriteLine($"The variable does not exist between simple inputs of '{this.Name}' gate.");
            }
        }

        /// <summary>
        /// Agrega una compuerta a la lista de compuertas antecesoras de la actual.
        /// </summary>
        /// <param name="gate"></param>
        public void AddInput(IGate gate)
        {
            // Se supone que la compuerta puede agregarse.
            bool isCapableToAdd = true;
            if (simpleInputs.Count > 0)
            {
                // Se itera con la lista de compuertas antecesoras.
                foreach (IGate existingGate in this.inputGates)
                {
                    if (gate.Name == existingGate.Name)
                    {
                        // Si coincide el nombre de una compuerta que quiere agregarse con una existente en la lista,
                        // entonces no se agrega (para evitar inconsistencias del circuito eléctrico).
                        isCapableToAdd = false;
                        // Break para no realizar pasos innecesarios.
                        break;
                    }
                }
            }
            if (isCapableToAdd == true)
            {
                // Se agrega la compuerta.
                inputGates.Add(gate);
            }
            else
            {
                // Se avisa al usuario que la compuerta no puede agregarse por coincidencia de nombre.
                Console.WriteLine($"'{gate.Name}' has the same name of an existing gate between antecesor gates of '{this.Name}' gate.");
            }
        }

        /// <summary>
        /// Remueve una compuerta existente de la lista de compuertas antecesoras de la actual.
        /// </summary>
        /// <param name="gate"></param>
        public void RemoveInput(IGate gate)
        {
            if (inputGates.Contains(gate))
            {
                // Se quita la compuerta antecesora.
                inputGates.Remove(gate);
            }
            else
            {
                // Se avisa al usuario que la compuerta no puede quitarse porque no existe en la lista.
                Console.WriteLine($"'{gate.Name}' gate does not exist between input gates of '{this.Name}' gate.");
            }
        }

        /// <summary>
        /// Retorna la salida de la compuerta a partir de sus entradas.
        /// </summary>
        /// <returns>Una única salida.</returns>
        public bool CalculateInput()
        {
            if (simpleInputs.Count + inputGates.Count < 2)
            {
                // Se avisa al usuario que no se puede calcular correctamente una salida, ya que faltan entradas.
                Console.WriteLine("There is no suficcient inputs to calculate an input (minimum two).");
                return false;
            }
            else
            {
                // Se supone que la salida es true.
                bool result = true;

                // Primero lo más fácil de revisar, es decir, las variables simples.
                foreach (SimpleVariable simpleInput in simpleInputs)
                {
                    if (simpleInput.Value == false)
                    {
                        return false;
                    }
                }

                // Si todas las variables simples son true, entonces va a revisar las salidas de las compuertas antecesoras.
                foreach (IGate gate in inputGates)
                {
                    if (gate.CalculateInput() == false)
                    {
                        return false;
                    }
                }
                return result;
            }
        }
        #endregion
    }
}