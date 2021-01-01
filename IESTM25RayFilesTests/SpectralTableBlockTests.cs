using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace IESTM25RayFiles.Tests
{
    [TestClass()]
    public class SpectralTableBlockTests
    {
        [TestMethod()]
        public void CheckSpectralTableisValidWithValidExampleDataTest()
        {
            //Arrange
            SpectralTableBlock spectralTableBlock = new SpectralTableBlock();
            using (BinaryReader reader = new BinaryReader(Helpers.GetExampleSpectralTableMemoryStream()))
            {
                Helpers.ReadSpectralTableBlock(reader, 3, ref spectralTableBlock);
            }
            var expected = true;

            //Act
            var  result = spectralTableBlock.CheckSpectralTableisValid();

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}