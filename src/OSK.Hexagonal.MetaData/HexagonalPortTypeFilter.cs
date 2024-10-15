using System;

namespace OSK.Hexagonal.MetaData
{
    [Flags]
    public enum HexagonalPortTypeFilter
    {
        None = 0,
        Primary = 1,
        Secondary = 2,

        All = Primary | Secondary
    }
}
