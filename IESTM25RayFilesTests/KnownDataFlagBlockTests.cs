using Microsoft.VisualStudio.TestTools.UnitTesting;
using IESTM25RayFiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace IESTM25RayFiles.Tests
{
    [TestClass()]
    public class KnownDataFlagBlockTests
    {
        [TestMethod()]
        public void CheckKnownFlagBlockisValidTest()
        {
            //Arrange
            KnownDataFlagBlock dataFlagBlock;
            dataFlagBlock.PositionFlag = 1;
            dataFlagBlock.DirectionFlag = 1;
            dataFlagBlock.RadiantFlux_StokesS0Flag = 0;
            dataFlagBlock.WavelengthFlag = 0;
            dataFlagBlock.LuminousFlux_TristimulusYFlag = 0;
            dataFlagBlock.StokesFlag = 0;
            dataFlagBlock.TristimulusFlag = 0;
            dataFlagBlock.SpetrumIndexFlag = 0;

            var expected = true;

            //Act
            var result = dataFlagBlock.CheckKnownDataFlagBlockisValid();

            //Assert
            Assert.AreEqual(expected, result);

        }

    }
}
