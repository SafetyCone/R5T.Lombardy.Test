using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using R5T.Salamis;


namespace R5T.Lombardy.Test
{
    public abstract class StringlyTypedPathOperatorGetRelativePathTestFixture
    {
        #region Test-Fixture

        public IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public StringlyTypedPathOperatorGetRelativePathTestFixture(IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        #endregion


        #region Windows Paths

        /// <summary>
        /// Tests that getting the relative path from one file to another file works for Windows paths.
        /// </summary>
        [TestMethod]
        public void GetRelativePathFileToFileWindows()
        {
            var sourcePath = ExampleFilePaths.WindowsFile01Path;
            var destinationPath = ExampleFilePaths.WindowsFile02Path;
            var expected = ExampleRelativePaths.WindowsFile01ToWindowsFile02Path;

            var actual = this.StringlyTypedPathOperator.GetRelativePath(sourcePath, destinationPath);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests that getting the relative path from a file to a directory works for Windows paths.
        /// </summary>
        [TestMethod]
        public void GetRelativePathFileToDirectoryWindows()
        {
            var sourcePath = ExampleFilePaths.WindowsFile01Path;
            var destinationPath = ExampleDirectoryPaths.WindowsDirectory03Path;
            var expected = ExampleRelativePaths.WindowsFile01ToWindowsDirectory03Path;

            var actual = this.StringlyTypedPathOperator.GetRelativePath(sourcePath, destinationPath);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests that getting the relative path from a directory to a file works for Windows paths.
        /// </summary>
        [TestMethod]
        public void GetRelativePathDirectoryToFileWindows()
        {
            var sourcePath = ExampleDirectoryPaths.WindowsDirectory04Path;
            var destinationPath = ExampleFilePaths.WindowsFile01Path;
            var expected = ExampleRelativePaths.WindowsDirectory04ToWindowsFile01Path;

            var actual = this.StringlyTypedPathOperator.GetRelativePath(sourcePath, destinationPath);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests that getting the relative path from one directory to another directory works for Windows paths.
        /// </summary>
        [TestMethod]
        public void GetRelativePathDirectoryToDirectoryWindows()
        {
            var sourcePath = ExampleDirectoryPaths.WindowsDirectory01Path;
            var destinationPath = ExampleDirectoryPaths.WindowsDirectory02Path;
            var expected = ExampleRelativePaths.WindowsDirectory01ToWindowsDirectory02Path;

            var actual = this.StringlyTypedPathOperator.GetRelativePath(sourcePath, destinationPath);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests that the relative path 
        /// </summary>
        [TestMethod]
        public void GetRelativePathFileToSameFileWindows()
        {
            var sourcePath = ExampleFilePaths.WindowsFile03Path;
            var destinationPath = ExampleFilePaths.WindowsFile03Path;
            var expected = ExampleRelativePaths.SameToSame;

            var actual = this.StringlyTypedPathOperator.GetRelativePath(sourcePath, destinationPath);

            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
