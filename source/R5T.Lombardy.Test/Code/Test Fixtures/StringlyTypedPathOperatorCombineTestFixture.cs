using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using R5T.Salamis;


namespace R5T.Lombardy.Test
{
    public abstract class StringlyTypedPathOperatorCombineTestFixture
    {
        #region Test-Fixture

        public IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public StringlyTypedPathOperatorCombineTestFixture(IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        #endregion

        #region Windows

        /// <summary>
        /// Tests that path parts can be combined into a Windows path.
        /// </summary>
        [TestMethod]
        public void CombineWindowsFile04Parts()
        {
            var pathParts = ExampleFilePaths.WindowsFile04PathParts;
            var expected = ExampleFilePaths.WindowsFile04Path;

            var actual = this.StringlyTypedPathOperator.CombineWindows(pathParts);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test that a Windows directory path and a file name can be combined to get a Windows file path.
        /// </summary>
        [TestMethod]
        public void GetFilePathWindows()
        {
            var directoryPath = ExampleDirectoryPaths.WindowsDirectory01Path;
            var fileName = ExampleFileNames.File01Name;
            var expected = ExampleFilePaths.WindowsFile01Path;

            var actual = this.StringlyTypedPathOperator.GetFilePath(directoryPath, fileName);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests that a Windows directory path a directory name can be combined to get a Windows directory path.
        /// </summary>
        [TestMethod]
        public void GetDirectoryPathWindows()
        {
            var directoryPath = ExampleDirectoryPaths.WindowsDirectory01Path;
            var directoryName = ExampleDirectoryNames.Directory02;
            var expected = ExampleDirectoryPaths.WindowsDirectory02Path;

            var actual = this.StringlyTypedPathOperator.GetDirectoryPath(directoryPath, directoryName);

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Non-Windows

        /// <summary>
        /// Tests that path parts can be combined into a non-Windows path.
        /// </summary>
        [TestMethod]
        public void CombineNonWindowsFile01Parts()
        {
            var pathParts = ExampleFilePaths.NonWindowsFile01PathParts;
            var expected = ExampleFilePaths.WindowsFile01Path;

            var actual = this.StringlyTypedPathOperator.CombineWindows(pathParts);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test that a non-Windows directory path and a file name can be combined to get a non-Windows file path.
        /// </summary>
        [TestMethod]
        public void GetFilePathNonWindows()
        {
            var directoryPath = ExampleDirectoryPaths.NonWindowsDirectory01Path;
            var fileName = ExampleFileNames.File01Name;
            var expected = ExampleFilePaths.NonWindowsFile01Path;

            var actual = this.StringlyTypedPathOperator.GetFilePath(directoryPath, fileName);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests that a non-Windows directory path a directory name can be combined to get a non-Windows directory path.
        /// </summary>
        [TestMethod]
        public void GetDirectoryPathNonWindows()
        {
            var directoryPath = ExampleDirectoryPaths.NonWindowsDirectory01Path;
            var directoryName = ExampleDirectoryNames.Directory02;
            var expected = ExampleDirectoryPaths.NonWindowsDirectory02Path;

            var actual = this.StringlyTypedPathOperator.GetDirectoryPath(directoryPath, directoryName);

            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
