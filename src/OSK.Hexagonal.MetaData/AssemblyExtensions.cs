using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OSK.Hexagonal.MetaData
{
    public static class AssemblyExtensions
    {
        public static IEnumerable<Type> GetHexagonalPortTypes(this Assembly assembly)
            => assembly.GetHexagonalPortTypes(HexagonalPortTypeFilter.All);

        public static IEnumerable<Type> GetHexagonalPortTypes(this Assembly assembly, HexagonalPortTypeFilter filter)
            => filter == HexagonalPortTypeFilter.None 
             ? Type.EmptyTypes 
             : assembly.GetExportedTypes().Where(type =>
             {
                 if (!type.IsInterface)
                 {
                     return false;
                 }

                 var hexagonalPort = type.GetCustomAttribute<HexagonalPortAttribute>();
                 if (hexagonalPort == null)
                 {
                    return false;
                 }
                 if (filter == HexagonalPortTypeFilter.All)
                 {
                    return true;
                 }

                 return filter.HasFlag(HexagonalPortTypeFilter.Primary)
                    ? hexagonalPort.HexagonalPort == HexagonalPort.Primary
                    : hexagonalPort.HexagonalPort == HexagonalPort.Secondary;
             });
    }
}
