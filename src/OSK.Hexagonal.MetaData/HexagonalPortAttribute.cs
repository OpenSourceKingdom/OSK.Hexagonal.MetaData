using System;

namespace OSK.Hexagonal.MetaData
{
    /// <summary>
    /// An attribute that can be used to desginate an interface as a type of hexagonal port
    /// </summary>
    [AttributeUsage(validOn: AttributeTargets.Interface, AllowMultiple = false)]
    public class HexagonalPortAttribute: Attribute
    {
        #region Variables

        public HexagonalPort HexagonalPort { get; }

        #endregion

        #region Constructors

        public HexagonalPortAttribute(HexagonalPort hexagonalPort)
        {
            HexagonalPort = hexagonalPort;
        }

        #endregion
    }
}
