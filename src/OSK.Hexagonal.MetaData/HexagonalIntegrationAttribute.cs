using System;
using System.Collections.Generic;
using System.Linq;
using OSK.Hexagonal.MetaData.Internal.Helpers;

namespace OSK.Hexagonal.MetaData
{
    /// <summary>
    /// An attribute that can be used to desginate an interface as a type of hexagonal integration
    /// </summary>
    [AttributeUsage(validOn: AttributeTargets.Interface, AllowMultiple = false)]
    public class HexagonalIntegrationAttribute: Attribute
    {
        #region Variables

        public ISet<HexagonalIntegrationType> HexagonalIntregrationTypes { get; }

        #endregion

        #region Constructors

        public HexagonalIntegrationAttribute(params HexagonalIntegrationType[] hexagonalIntegrationTypes)
        {
            HexagonalIntregrationTypes = hexagonalIntegrationTypes.ToHashSet();
            HexagonalHelper.ValidateHexagonalIntegration(HexagonalIntregrationTypes);
        }

        #endregion
    }
}
