using System;
using System.Collections.Generic;
using System.Text;

namespace OSK.Hexagonal.MetaData.Exceptions
{
    public class HexagonalMetaDataException(string message)
        : Exception(message)
    {
    }
}
