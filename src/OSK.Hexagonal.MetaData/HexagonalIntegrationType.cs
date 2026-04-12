namespace OSK.Hexagonal.MetaData
{
    /// <summary>
    /// An enum that defines the types of integrations a library expects or provides to different types of consumers and integrations
    /// </summary>
    public enum HexagonalIntegrationType
    {
        /// <summary>
        /// The abstraction is under development and may not be fully designed. Implementations may be expected to change at a later
        /// date when final implementations are completed. 
        /// </summary>
        UnderDevelopment,

        /// <summary>
        /// The abstraction has a library provided implementation and does not need to be provided by any consumer for the library to function.
        /// </summary> 
        LibraryProvided,

        /// <summary>
        /// The abstraction can be considered by a consumer to be one of the primary abstractions to look at when wanting to integrate into their application
        /// </summary>
        ConsumerPointOfEntry,

        /// <summary>
        /// The consumer of the library, that is the end user, is required to add an implementation. If the implementation is not provided, users 
        /// should not expect the library to function properly.
        /// </summary>
        ConsumerRequired,

        /// <summary>
        /// The consumer of the library, that is the end user, can optionally add an implementation. If the implementation is not provided, users
        /// should still expect the library to function properly. If this option is not present on the abstraction, user implementations may be ignored.
        /// completely.
        /// </summary>
        ConsumerOptional,

        /// <summary>
        /// An integration with the library, that is a library plugin or similarly provided implementation, is required to create an implementation.
        /// This indicates that in order for the integration to work with the library and consumers expecations, this abstraction must be implemented.
        /// </summary>
        IntegrationRequired,

        /// <summary>
        /// An integration with the library, that is a library plugin or similarly provided implementation, can optionally add an implementation.
        /// This indicates that the abstraction is not needed for the library or consumer expectations to be met. If this option is not present 
        /// on the abstraction, integration implementations may be ignored.
        /// </summary>
        IntegrationOptional
    }
}
