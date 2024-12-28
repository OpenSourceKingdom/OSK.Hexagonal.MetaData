using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSK.Hexagonal.MetaData.UnitTests.Helpers
{
    [HexagonalIntegration(HexagonalIntegrationType.IntegrationRequired)]
    public interface IIntegrationRequiredRepository
    {
    }
}
