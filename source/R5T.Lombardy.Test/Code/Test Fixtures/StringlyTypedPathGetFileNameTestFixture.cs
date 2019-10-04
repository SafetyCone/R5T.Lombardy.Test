using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using R5T.Salamis;


namespace R5T.Lombardy.Test
{
    public class StringlyTypedPathGetFileNameTestFixture
    {
        #region Test Fixture

        public IStringlyTypedPathOperator StringlyTypedPathOperator { get; set; }


        public StringlyTypedPathGetFileNameTestFixture(IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        #endregion


        /// <summary>
        /// Does getting the file name from a basic Windows file path work?
        /// </summary>
        [TestMethod]
        public void BasicWindows()
        {
            var filePath = ExampleFilePaths.WindowsFilePath1;
            var expectedFileName = ExampleFileNames.FileName1;

            var actualFileName = this.StringlyTypedPathOperator.GetFileName(filePath);

            Assert.AreEqual(expectedFileName, actualFileName);
        }
    }
}
