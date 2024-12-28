using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using OSK.Hexagonal.MetaData.Models;

namespace OSK.Hexagonal.MetaData
{
    public static class AssemblyExtensions
    {
        /// <summary>
        /// Gets all hexagonal integrations in the given assembly
        /// </summary>
        /// <param name="assembly">The assembly to get hexagonal integrations from</param>
        /// <returns>A list of all the types that possess hexaogonal integration attributes</returns>
        public static IEnumerable<HexagonalIntegrationDescriptor> GetHexagonalIntegrations(this Assembly assembly)
            => assembly.GetHexagonalIntegrations([]);

        /// <summary>
        /// Gets all hexagonal integrations that are either <see cref="HexagonalIntegrationType.ConsumerRequired"/> or <see cref="HexagonalIntegrationType.IntegrationRequired"/>
        /// </summary>
        /// <param name="assembly">The assembly to get hexagonal integrations from</param>
        /// <returns>A list of all the types that possess hexaogonal integration attributes that are considered required.</returns>
        public static IEnumerable<HexagonalIntegrationDescriptor> GetRequiredHexagonalIntegrations(this Assembly assembly)
            => assembly.GetHexagonalIntegrations(HexagonalIntegrationType.IntegrationRequired, HexagonalIntegrationType.ConsumerRequired);

        /// <summary>
        /// Gets all hexagonal integrations that are either <see cref="HexagonalIntegrationType.ConsumerOptional"/> or <see cref="HexagonalIntegrationType.IntegrationOptional"/>
        /// </summary>
        /// <param name="assembly">The assembly to get hexagonal integrations from</param>
        /// <returns>A list of all the types that possess hexaogonal integration attributes that are considered optional.</returns>
        public static IEnumerable<HexagonalIntegrationDescriptor> GetOptionalHexagonalIntegrations(this Assembly assembly)
            => assembly.GetHexagonalIntegrations(HexagonalIntegrationType.IntegrationOptional, HexagonalIntegrationType.ConsumerOptional);

        /// <summary>
        /// Gets all hexagonal integrations that are a <see cref="HexagonalIntegrationType.ConsumerPointOfEntry"/>
        /// </summary>
        /// <param name="assembly">The assembly to get hexagonal integrations from</param>
        /// <returns>A list of all the types that possess hexaogonal integration attributes that are considered points of entry into a codebase for consumers.</returns>
        public static IEnumerable<HexagonalIntegrationDescriptor> GetPointsOfEntryHexagonalIntegrations(this Assembly assembly)
            => assembly.GetHexagonalIntegrations(HexagonalIntegrationType.ConsumerPointOfEntry);

        /// <summary>
        /// Gets a filtered list of hexagonal integrations.
        /// </summary>
        /// <param name="assembly">The assembly to get hexagonal integrations from</param>
        /// <param name="hexagonalIntegrationFilter">
        /// A collection of <see cref="HexagonalIntegrationType"/> that will filter types in the assembly.
        /// 
        /// Note: an empty collection returns an unfiltered list of hexagonal integrations, i.e. all of them.
        /// </param>
        /// <returns>A list of all the types that possess hexagonal integration attributes that meet the filter requirements.</returns>
        public static IEnumerable<HexagonalIntegrationDescriptor> GetHexagonalIntegrations(this Assembly assembly, 
            params HexagonalIntegrationType[] hexagonalIntegrationFilter)
        {
            var hexagonalFilterSet = hexagonalIntegrationFilter.ToHashSet();
            return assembly
                .GetExportedTypes()
                .Select(type =>
                {
                    if (!type.IsInterface)
                    {
                        return null;
                    }

                    var hexagonalIntegration = type.GetCustomAttribute<HexagonalIntegrationAttribute>();
                    if (hexagonalIntegration == null)
                    {
                        return null;
                    }

                    if (hexagonalFilterSet.Count == 0)
                    {
                        return new HexagonalIntegrationDescriptor()
                        {
                            AbstractionType = type,
                            IsRequired = hexagonalIntegration.HexagonalIntregrationTypes.Any(integrationType => integrationType.IsRequired()),
                            HexagonalIntegrationTypes = [.. hexagonalIntegration.HexagonalIntregrationTypes]
                        };
                    }

                    return hexagonalFilterSet.Intersect(hexagonalIntegration.HexagonalIntregrationTypes).Any()
                        ? new HexagonalIntegrationDescriptor()
                        {
                            AbstractionType = type,
                            IsRequired = hexagonalIntegration.HexagonalIntregrationTypes.Any(integrationType => integrationType.IsRequired()),
                            HexagonalIntegrationTypes = [.. hexagonalIntegration.HexagonalIntregrationTypes]
                        }
                        : null;
                })
                .Where(descriptor => descriptor is not null);
        }
    }
}
