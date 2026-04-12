namespace OSK.Hexagonal.MetaData
{
    public static class HexagonalIntegrationTypeExtensions
    {
        public static bool IsRequired(this HexagonalIntegrationType hexagonalIntegration)
            => hexagonalIntegration == HexagonalIntegrationType.ConsumerRequired
        || hexagonalIntegration == HexagonalIntegrationType.IntegrationRequired;

        public static bool IsOptional(this HexagonalIntegrationType hexagonalIntegration)
            => hexagonalIntegration == HexagonalIntegrationType.ConsumerOptional
                || hexagonalIntegration == HexagonalIntegrationType.IntegrationOptional;
    }
}
