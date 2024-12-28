using OSK.Extensions.Object.DeepEquals;
using OSK.Extensions.Object.DeepEquals.Options;
using OSK.Hexagonal.MetaData.UnitTests.Helpers;
using System.Reflection;
using Xunit;

namespace OSK.Hexagonal.MetaData.UnitTests
{
    public class AssemblyExtensionsTests
    {
        #region Variables

        private readonly Assembly _assembly;

        #endregion

        #region Constructors

        public AssemblyExtensionsTests()
        {
            _assembly = Assembly.GetExecutingAssembly();
        }

        #endregion

        #region GetHexagonalPortTypes

        [Fact]
        public void GetHexagonalPortTypes_AllIntegrations_ReturnsAllExportedIntegrationTypes()
        {
            // Arrange/Act
            var types = _assembly.GetHexagonalIntegrations().ToList();

            // Assert
            Assert.Equal(4, types.Count);

            var consumerRequired = types.First(t => t.AbstractionType == typeof(IConsumerRequiredRepository));
            Assert.True(consumerRequired.IsRequired);
            Assert.Single(consumerRequired.HexagonalIntegrationTypes);
            Assert.Contains(HexagonalIntegrationType.ConsumerRequired, consumerRequired.HexagonalIntegrationTypes);

            var integrationRequired = types.First(t => t.AbstractionType == typeof(IIntegrationRequiredRepository));
            Assert.True(integrationRequired.IsRequired);
            Assert.Single(integrationRequired.HexagonalIntegrationTypes);
            Assert.Contains(HexagonalIntegrationType.IntegrationRequired, integrationRequired.HexagonalIntegrationTypes);

            var libraryProvided = types.First(t => t.AbstractionType == typeof(ILibraryProvidedService));
            Assert.False(libraryProvided.IsRequired);
            Assert.Single(libraryProvided.HexagonalIntegrationTypes);
            Assert.Contains(HexagonalIntegrationType.LibraryProvided, libraryProvided.HexagonalIntegrationTypes);

            var multiType = types.First(t => t.HexagonalIntegrationTypes.Length > 1);
            Assert.False(multiType.IsRequired);
            Assert.Equal(3, multiType.HexagonalIntegrationTypes.Length);

            HexagonalIntegrationType[] expected = 
                [ HexagonalIntegrationType.UnderDevelopment, HexagonalIntegrationType.LibraryProvided,
                  HexagonalIntegrationType.ConsumerPointOfEntry ];
            Assert.True(expected.DeepEquals(multiType.HexagonalIntegrationTypes));
        }

        [Fact]
        public void GetHexagonalPortTypes_UnusedIntegrationTypeFilter_ReturnsNoHexagonalDescriptors()
        {
            // Arrange/Act
            var types = _assembly.GetHexagonalIntegrations(HexagonalIntegrationType.IntegrationOptional).ToList();

            // Assert
            Assert.Empty(types);
        }

        [Fact]
        public void GetHexagonalPortTypes_Filter_ReturnsIntegrationsValidForFilter()
        {
            // Arrange/Act
            var types = _assembly
                .GetHexagonalIntegrations(HexagonalIntegrationType.IntegrationRequired, HexagonalIntegrationType.ConsumerRequired)
                .ToList();

            // Assert
            Assert.Equal(2, types.Count);

            var consumerRequired = types.First(t => t.AbstractionType == typeof(IConsumerRequiredRepository));
            Assert.True(consumerRequired.IsRequired);
            Assert.Single(consumerRequired.HexagonalIntegrationTypes);
            Assert.Contains(HexagonalIntegrationType.ConsumerRequired, consumerRequired.HexagonalIntegrationTypes);

            var integrationRequired = types.First(t => t.AbstractionType == typeof(IIntegrationRequiredRepository));
            Assert.True(integrationRequired.IsRequired);
            Assert.Single(integrationRequired.HexagonalIntegrationTypes);
            Assert.Contains(HexagonalIntegrationType.IntegrationRequired, integrationRequired.HexagonalIntegrationTypes);
        }

        #endregion
    }
}
