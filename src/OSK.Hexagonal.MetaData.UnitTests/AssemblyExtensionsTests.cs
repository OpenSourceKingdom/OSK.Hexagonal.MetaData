using OSK.Hexagonal.MetaData.UnitTests.Helpers;
using System.Reflection;
using Xunit;

namespace OSK.Hexagonal.MetaData.UnitTests
{
    public class AssemblyExtensionsTests
    {
        #region Variables

        private readonly Assembly _assembly;

        #endregion

        #region Constructors

        public AssemblyExtensionsTests()
        {
            _assembly = Assembly.GetExecutingAssembly();
        }

        #endregion

        #region GetHexagonalPortTypes

        [Fact]
        public void GetHexagonalPortTypes_None_ReturnsUnmarkedTypes()
        {
            // Arrange/Act
            var types = _assembly.GetHexagonalPortTypes(HexagonalPortTypeFilter.None).ToList();

            // Assert
            Assert.Empty(types);
        }

        [Fact]
        public void GetHexagonalPortTypes_Primary_ReturnsOnlyPrimaryPorts()
        {
            // Arrange/Act
            var types = _assembly.GetHexagonalPortTypes(HexagonalPortTypeFilter.Primary).ToList();

            // Assert
            Assert.Single(types);
            Assert.True(types.Exists(t => t == typeof(IHexagonalTestService)));
        }

        [Fact]
        public void GetHexagonalPortTypes_Secondary_ReturnsOnlySecondaryPorts()
        {
            // Arrange/Act
            var types = _assembly.GetHexagonalPortTypes(HexagonalPortTypeFilter.Secondary).ToList();

            // Assert
            Assert.Single(types);
            Assert.True(types.Exists(t => t == typeof(IHexagonalTestRepository)));
        }

        [Fact]
        public void GetHexagonalPortTypes_All_ReturnsAllPorts()
        {
            // Arrange/Act
            var types = _assembly.GetHexagonalPortTypes(HexagonalPortTypeFilter.All).ToList();

            // Assert
            Assert.Equal(2, types.Count);
            Assert.True(types.Exists(t => t == typeof(IHexagonalTestService)));
            Assert.True(types.Exists(t => t == typeof(IHexagonalTestRepository)));
        }

        #endregion
    }
}
