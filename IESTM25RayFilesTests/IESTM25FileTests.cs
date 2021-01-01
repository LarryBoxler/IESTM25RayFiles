using Microsoft.VisualStudio.TestTools.UnitTesting;
using IESTM25RayFiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace IESTM25RayFiles.Tests
{
    [TestClass()]
    public class IESTM25FileTests
    {
        [DeploymentItem("rayfile_LERTDUW_S2WP_green_100k_20161013_IES_TM25.TM25RAY")]
        [TestMethod()]
        public void IESTM25FileReadFromValidFileAndHeaderIsValidTest()
        {
            //Arrange
            IESTM25File testRayset = new IESTM25File("rayfile_LERTDUW_S2WP_green_100k_20161013_IES_TM25.TM25RAY");
            var expected = true;
            //Act
            var result = testRayset.FileHeader.CheckHeaderBlockisValid();
            //
            Assert.AreEqual(expected, result);
        }

        [DeploymentItem ("rayfile_LERTDUW_S2WP_green_100k_20161013_IES_TM25.TM25RAY")]
        [TestMethod()]
        public void IESTM25FileReadFromValidFileAndFlagsAreValidTest()
        {
            //Arrange
            IESTM25File testRayset = new IESTM25File("rayfile_LERTDUW_S2WP_green_100k_20161013_IES_TM25.TM25RAY");
            var expected = true;
            //Act
            var result = testRayset.DataFlags.CheckKnownDataFlagBlockisValid();
            //
            Assert.AreEqual(expected, result);
        }

        [DeploymentItem("rayfile_LERTDUW_S2WP_green_100k_20161013_IES_TM25.TM25RAY")]
        [TestMethod()]
        public void IESTM25FileReadFromValidFileAndDescriptionsAreValidTest()
        {
            //Arrange
            IESTM25File testRayset = new IESTM25File("rayfile_LERTDUW_S2WP_green_100k_20161013_IES_TM25.TM25RAY");
            var expected = true;
            //Act
            var result = testRayset.DescriptionHeader.CheckDescriptionBlockisValid();
            //
            Assert.AreEqual(expected, result);
        }
    }
}