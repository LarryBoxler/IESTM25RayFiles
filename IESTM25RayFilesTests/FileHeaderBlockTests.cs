using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IESTM25RayFiles.Tests
{
    [TestClass()]
    public class FileHeaderBlockTests
    {
        [TestMethod()]
        public void CheckHeaderBlockisValidTest()
        {
            //Arrange
            FileHeaderBlock headerBlock;
            headerBlock.FileType = Helpers.GetFixedSizeByteArrayFromBinaryString("TM25", 4);
            headerBlock.FileVersion = 2013;
            headerBlock.CreationMethod = 0;
            headerBlock.TotalLuminousFlux = 2300.12F;
            headerBlock.TotalRadiantFlux = 6700.59F;
            headerBlock.NumberOfRays = 1000000;
            headerBlock.FileCreationDateAndTime = Helpers.GetFixedSizeByteArrayFromBinaryString("2013-09-04T08:30:29+01:00", 28);
            headerBlock.RayStartPosition = 0;
            headerBlock.SpectralDataIdentifier = 1;
            headerBlock.SingleWavelength = 555.5F;
            headerBlock.MinimumWavelength = 450.0F;
            headerBlock.MaximumWavelength = 750.1F;
            headerBlock.NumberOfSpectralTables = 1;
            headerBlock.NumberOfAdditionalRayDataItemsPerRay = 0;
            headerBlock.SizeOfAdditionalTextBlock = 0;

            //Act
            var result = headerBlock.CheckHeaderBlockisValid();
            
            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void CheckFileTypeToASCII()
        {
            //Arrange
            FileHeaderBlock headerBlock = new FileHeaderBlock();
            headerBlock.FileType=Helpers.GetFixedSizeByteArrayFromBinaryString("TM25", 4);
            var expected = "TM25";

            //Act
            string result = headerBlock.FileTypeToASCII();

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void CheckFileCreationDateToASCII()
        {
            //Arrange
            FileHeaderBlock headerBlock = new FileHeaderBlock();
            headerBlock.FileCreationDateAndTime = Helpers.GetFixedSizeByteArrayFromBinaryString("2013-09-04T08:30:29+01:00", 28);
            var expected = "2013-09-04T08:30:29+01:00   ";

            //Act
            string result = headerBlock.FileCreationDatetoASCII();

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}