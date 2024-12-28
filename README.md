# OSK.Hexagonal.MetaData
This project is meant to provide a way to mark, directly in code, the expectation of a given abstraction for a hexagonally implemented
library. By using this kind of metadata, a codebase may hopefully be more clearly documented to its intentions and usage. There is also
a set of assembly extensions that can be used to retrieve specific types of abstractions based on their hexagonal integration type metadata.

# Usage
Codebase abstractions, i.e. interfaces, can be marked using the `HexagonalIntegrationAttribute` and can be marked in a variety of ways 
to help provide code readers an idea to the intentions of the port at a glance. The attribute can be defined with one or more hexagonal integration
types. These types help to define expectations for integrations, consumers, and direct implementations of the library.

Note: There is some additional logic in place to restrict some combinations of integration types. For example, an abstraction can 
not be both marked as required and optional. This is to help reduce potential confusion for a codebase when using this library. The attribute
integration types are validated at runtime and will throw a `HexagonalMetaDataException` if they are found to be invalid.

# Contributions and Issues
Any and all contributions are appreciated! Please be sure to follow the branch naming convention OSK-{issue number}-{deliminated}-{branch}-{name} as current workflows rely on it for automatic issue closure. Please submit issues for discussion and tracking using the github issue tracker.111