using System;

namespace OSK.Hexagonal.MetaData.Models
{
    public class HexagonalIntegrationDescriptor
    {
        public Type AbstractionType { get; set; }

        public bool IsRequired { get; set; }

        public HexagonalIntegrationType[] HexagonalIntegrationTypes { get; set; }
    }
}
