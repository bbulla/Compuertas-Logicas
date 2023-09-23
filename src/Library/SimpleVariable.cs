namespace Library
{
    /// <summary>
    /// Es una variable booleana que su valor no depende de compuertas.
    /// </summary>
    // °Estereotipo: "Information holder" porque sabe su valor y proporciona información para que las compuertas operen y den una salida determinada.
    public class SimpleVariable
    {
        #region ATRIBUTOS
        /// <summary>
        /// Nombre de la variable simple. Sólo sirve de identificador para el usuario del programa.
        /// </summary>
        private string _name;

        /// <summary>
        /// Valor de la variable simple.
        /// </summary>
        private bool _value;
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Retorna o cambia el nombre de la variable simple.
        /// </summary>
        /// <value>Nombre de variable simple.</value>
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
                    Console.WriteLine("Invalid name of simple variable.");
                }
            }
        }

        /// <summary>
        /// Retorna o cambia el valor booleano de la variable simple.
        /// </summary>
        /// <value>Valor booleano de la variable simple.</value>
        public bool Value
        {
            get { return _value; }
            set { _value = value; }
        }
        #endregion

        #region MÉTODOS
        /// <summary>
        /// Método constructor de las variables simples.
        /// </summary>
        /// <param name="nameVariable"></param>
        /// <param name="booleanValue"></param>
        public SimpleVariable(string nameVariable, bool booleanValue)
        {
            _name = nameVariable;
            _value = booleanValue;
        }
        #endregion
    }
}