namespace OSK.Hexagonal.MetaData
{
    /// <summary>
    /// An enum list that defines the types of ports that can be utilized in the hexagonal library design
    /// </summary>
    public enum HexagonalPort
    {
        /// <summary>
        /// An interface whose primary implementation will be provided by the library.
        /// </summary>
        Primary,

        /// <summary>
        /// An interface whose implementation must be provided by the consumer of the library
        /// </summary>
        Secondary
    }
}
