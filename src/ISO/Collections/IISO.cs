namespace ISOLib.Collections
{
    /// <summary>
    /// Represents an interface for ISO standards, providing information about their names and numbers.
    /// </summary>
    public interface IISO
    {
        /// <summary>
        /// Gets the name of the ISO standard.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Gets the number associated with the ISO standard.
        /// </summary>
        int Number { get; }
        /// <summary>
        /// Gets the Wikipedia link related to the ISO standard.
        /// </summary>
        string Wiki { get; }
    }
}
