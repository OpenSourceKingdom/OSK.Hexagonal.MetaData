using OSK.Hexagonal.MetaData.Internal.Helpers;
using Xunit;

namespace OSK.Hexagonal.MetaData.UnitTests.Internal.Helpers
{
    public class HexagonalHelperTests
    {
        #region ValidateHexagonalIntegration

        [Theory]
        [InlineData(HexagonalIntegrationType.ConsumerPointOfEntry, HexagonalIntegrationType.ConsumerOptional)]
        [InlineData(HexagonalIntegrationType.ConsumerPointOfEntry, HexagonalIntegrationType.IntegrationOptional)]
        [InlineData(HexagonalIntegrationType.LibraryProvided, HexagonalIntegrationType.IntegrationRequired)]
        [InlineData(HexagonalIntegrationType.LibraryProvided, HexagonalIntegrationType.ConsumerRequired)]
        [InlineData(HexagonalIntegrationType.IntegrationRequired, HexagonalIntegrationType.IntegrationOptional)]
        [InlineData(HexagonalIntegrationType.ConsumerRequired, HexagonalIntegrationType.ConsumerOptional)]
        [InlineData(HexagonalIntegrationType.IntegrationOptional, HexagonalIntegrationType.ConsumerRequired)]
        [InlineData(HexagonalIntegrationType.IntegrationRequired, HexagonalIntegrationType.ConsumerOptional)]
        public void ValidateHexagonalIntegration_HexagonalTypeRequirementMismatch_ThrowsInvalidOperationException(
            params HexagonalIntegrationType[] mismatchedTypes)
        {
            // Arrange/Act/Assert
            Assert.Throws<InvalidOperationException>(() => HexagonalHelper.ValidateHexagonalIntegration(mismatchedTypes.ToHashSet()));
        }


        [Theory]
        [InlineData(HexagonalIntegrationType.LibraryProvided)]
        [InlineData(HexagonalIntegrationType.ConsumerRequired)]
        [InlineData(HexagonalIntegrationType.IntegrationRequired)]
        [InlineData(HexagonalIntegrationType.LibraryProvided, HexagonalIntegrationType.ConsumerOptional)]
        [InlineData(HexagonalIntegrationType.LibraryProvided, HexagonalIntegrationType.IntegrationOptional)]
        [InlineData(HexagonalIntegrationType.ConsumerOptional, HexagonalIntegrationType.IntegrationOptional)]
        public void ValidateHexagonalIntegration_SomeValidMatches_ReturnsSuccessfully(params HexagonalIntegrationType[] validTypes)
        {
            // Arrange/Act/Assert
            HexagonalHelper.ValidateHexagonalIntegration(validTypes.ToHashSet());
        }

        #endregion
    }
}
