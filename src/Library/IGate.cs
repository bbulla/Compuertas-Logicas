namespace Library.BasicGates
{
    /// <summary>
    /// Operaciones que deben incluir todas las compuertas lógicas.
    /// </summary>
    public interface IGate
    {
        string Name { get; set; }
        void AddInput(SimpleVariable simpleInput);
        void RemoveInput(SimpleVariable simpleInput);
        void AddInput(IGate gate);
        void RemoveInput(IGate gate);
        bool CalculateInput();
    }
}