using System;
using System.Collections.Generic;
using System.Linq;

namespace OSK.Hexagonal.MetaData.Internal.Helpers
{
    internal static class HexagonalHelper
    {
        public static void ValidateHexagonalIntegration(ISet<HexagonalIntegrationType> hexagonalIntegrationTypes)
        {
            var isRequired = hexagonalIntegrationTypes.Any(integrationType => integrationType.IsRequired());
            var isOptional = hexagonalIntegrationTypes.Any(integrationType => integrationType.IsOptional());

            if (isRequired && isOptional)
            {
                throw new InvalidOperationException("Unable to set an integration type as both required and optional.");
            }
            if (isRequired && hexagonalIntegrationTypes.Contains(HexagonalIntegrationType.LibraryProvided))
            {
                throw new InvalidOperationException("Unable to set an integration type as required if it is already provided by the library.");
            }
            if (isOptional && hexagonalIntegrationTypes.Contains(HexagonalIntegrationType.ConsumerPointOfEntry))
            {
                throw new InvalidOperationException("Unable to set an integration type as a consumer point of entry while it is optional");
            }
        }
    }
}
