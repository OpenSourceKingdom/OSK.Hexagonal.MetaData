using System;

namespace OSK.Hexagonal.MetaData
{
    [Obsolete("Use HexagonalIntegrationType and associated attribute instead. Will be removed in future update")]
    [AttributeUsage(validOn: AttributeTargets.Interface, AllowMultiple = false)]
    public class HexagonalPortAttribute: HexagonalIntegrationAttribute
    {
        public HexagonalPortAttribute(HexagonalPort portType)
            : base(portType == HexagonalPort.Primary 
                  ? HexagonalIntegrationType.LibraryProvided : HexagonalIntegrationType.ConsumerRequired)
        {
        }
    }
}
