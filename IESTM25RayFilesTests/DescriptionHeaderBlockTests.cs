using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace IESTM25RayFiles.Tests
{
    [TestClass()]
    public class DescriptionHeaderBlockTests
    {
        [TestMethod()]
        public void CheckDescriptionBlockisValidWithTM25ExampleData()
        {
            //Arrange
            DescriptionHeaderBlock descriptionHeaderBlock;
            descriptionHeaderBlock.NameOFLightSource = Helpers.GetTM25DescriptionString("1W LED");
            descriptionHeaderBlock.ManufacturerOfLightSource = Helpers.GetTM25DescriptionString("LED Company");
            descriptionHeaderBlock.CreatorofOpticalLightSourceModel= Helpers.GetTM25DescriptionString("Engineer 1");
            descriptionHeaderBlock.CreatorOfRayFile = Helpers.GetTM25DescriptionString("Measurement Company");
            descriptionHeaderBlock.Equipment_Software_Used = Helpers.GetTM25DescriptionString("Ray Maker 2000");
            descriptionHeaderBlock.CameraInformation = Helpers.GetTM25DescriptionString("Fixed Focus");
            descriptionHeaderBlock.LightSourceOperationInformation = Helpers.GetTM25DescriptionString("350mA, 25C");
            descriptionHeaderBlock.AdditionalInformation = Helpers.GetTM25DescriptionString("Sample LED 1 of 12");
            descriptionHeaderBlock.DataReferencetoSourceGeometry = Helpers.GetTM25DescriptionString("top of dome is 1 mm above ray file origin");

            var expected = true;

            //Act
            var result = descriptionHeaderBlock.CheckDescriptionBlockisValid();

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
