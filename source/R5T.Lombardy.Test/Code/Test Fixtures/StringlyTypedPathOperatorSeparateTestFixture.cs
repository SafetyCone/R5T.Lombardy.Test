using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using R5T.Salamis;


namespace R5T.Lombardy.Test
{
    public abstract class StringlyTypedPathOperatorSeparateTestFixture
    {
        #region Test-Fixture

        public IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public StringlyTypedPathOperatorSeparateTestFixture(IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        #endregion


        /// <summary>
        /// Tests that a Windows file path can be separated into path parts.
        /// </summary>
        [TestMethod]
        public void GetPathSegmentsWindows()
        {
            var filePath = ExampleFilePaths.WindowsFile04Path;
            var expected = ExampleFilePaths.WindowsFile04PathParts;

            var actual = this.StringlyTypedPathOperator.GetPathParts(filePath);

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests that a non-Windows file path can be separated into path parts.
        /// </summary>
        [TestMethod]
        public void GetPathSegmentsNonWindows()
        {
            var filePath = ExampleFilePaths.NonWindowsFile01Path;
            var expected = ExampleFilePaths.NonWindowsFile01PathParts;

            var actual = this.StringlyTypedPathOperator.GetPathParts(filePath);

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Does getting the file name from a basic Windows file path work?
        /// </summary>
        [TestMethod]
        public void GetFileNameBasicWindows()
        {
            var filePath = ExampleFilePaths.WindowsFile01Path;
            var expectedFileName = ExampleFileNames.File01Name;

            var actualFileName = this.StringlyTypedPathOperator.GetFileName(filePath);

            Assert.AreEqual(expectedFileName, actualFileName);
        }

        /// <summary>
        /// Does getting the file name from a basic Windows file path work?
        /// </summary>
        [TestMethod]
        public void GetFileNameBasicNonWindows()
        {
            var filePath = ExampleFilePaths.NonWindowsFile01Path;
            var expectedFileName = ExampleFileNames.File01Name;

            var actualFileName = this.StringlyTypedPathOperator.GetFileName(filePath);

            Assert.AreEqual(expectedFileName, actualFileName);
        }

        /// <summary>
        /// Tests that the file name without file extension can be separated out of a Windows file path.
        /// </summary>
        [TestMethod]
        public void GetFileNameWithoutExtensionBasicWindows()
        {
            var filePath = ExampleFilePaths.WindowsFile01Path;
            var expectedFileNameWithoutExtension = ExampleFileNames.File01WithoutExtension;

            var actual = this.StringlyTypedPathOperator.GetFileNameWithoutExtension(filePath);

            Assert.AreEqual(expectedFileNameWithoutExtension, actual);
        }

        /// <summary>
        /// Tests that the file name without file extension can be separated out of a non-Windows file path.
        /// </summary>
        [TestMethod]
        public void GetFileNameWithoutExtensionBasicNonWindows()
        {
            var filePath = ExampleFilePaths.NonWindowsFile01Path;
            var expectedFileNameWithoutExtension = ExampleFileNames.File01WithoutExtension;

            var actual = this.StringlyTypedPathOperator.GetFileNameWithoutExtension(filePath);

            Assert.AreEqual(expectedFileNameWithoutExtension, actual);
        }

        /// <summary>
        /// Tests that the file extension can be separated out of a Windows file path.
        /// </summary>
        [TestMethod]
        public void GetFileExtensionBasicWindows()
        {
            var filePath = ExampleFilePaths.WindowsFile01Path;
            var expectedFileExtension = ExampleFileExtensions.Text;

            var actual = this.StringlyTypedPathOperator.GetFileExtension(filePath);

            Assert.AreEqual(expectedFileExtension, actual);
        }

        /// <summary>
        /// Tests that the file extension can be separated out of a non-Windows file path.
        /// </summary>
        [TestMethod]
        public void GetFileExtensionBasicNonWindows()
        {
            var filePath = ExampleFilePaths.NonWindowsFile01Path;
            var expectedFileExtension = ExampleFileExtensions.Text;

            var actual = this.StringlyTypedPathOperator.GetFileExtension(filePath);

            Assert.AreEqual(expectedFileExtension, actual);
        }

        /// <summary>
        /// Tests that the directory path can be separated out of a Windows file path.
        /// </summary>
        [TestMethod]
        public void GetDirectoryPathForFilePathBasicWindows()
        {
            var filePath = ExampleFilePaths.WindowsFile01Path;
            var expectedDirectoryPath = ExampleDirectoryPaths.WindowsDirectory01Path;

            var actual = this.StringlyTypedPathOperator.GetDirectoryPathForFilePath(filePath);

            Assert.AreEqual(expectedDirectoryPath, actual);
        }

        /// <summary>
        /// Tests that the directory path can be separated out of a non-Windows file path.
        /// </summary>
        [TestMethod]
        public void GetDirectoryPathForFilePathBasicNonWindows()
        {
            var filePath = ExampleFilePaths.NonWindowsFile01Path;
            var expectedDirectoryPath = ExampleDirectoryPaths.NonWindowsDirectory01Path;

            var actual = this.StringlyTypedPathOperator.GetDirectoryPathForFilePath(filePath);

            Assert.AreEqual(expectedDirectoryPath, actual);
        }

        /// <summary>
        /// Tests that the directory name can be separated out of a Windows file path.
        /// </summary>
        [TestMethod]
        public void GetDirectoryNameForFilePathBasicWindows()
        {
            var filePath = ExampleFilePaths.WindowsFile01Path;
            var expectedDirectoryName = ExampleDirectoryNames.Directory01;

            var actual = this.StringlyTypedPathOperator.GetDirectoryNameForFilePath(filePath);

            Assert.AreEqual(expectedDirectoryName, actual);
        }

        /// <summary>
        /// Tests that the directory name can be separated out of a non-Windows file path.
        /// </summary>
        [TestMethod]
        public void GetDirectoryNameForFilePathBasicNonWindows()
        {
            var filePath = ExampleFilePaths.NonWindowsFile01Path;
            var expectedDirectoryName = ExampleDirectoryNames.Directory01;

            var actual = this.StringlyTypedPathOperator.GetDirectoryNameForFilePath(filePath);

            Assert.AreEqual(expectedDirectoryName, actual);
        }

        /// <summary>
        /// Tests that the directory name can be separated out of a Windows directory path.
        /// </summary>
        [TestMethod]
        public void GetDirectoryNameForDirectoryPathWindows()
        {
            var directoryPath = ExampleDirectoryPaths.WindowsDirectory01Path;
            var expectedDirectoryName = ExampleDirectoryNames.Directory01;

            var actual = this.StringlyTypedPathOperator.GetDirectoryNameForDirectoryPath(directoryPath);

            Assert.AreEqual(expectedDirectoryName, actual);
        }

        /// <summary>
        /// Tests that the directory name can be separated out of a Windows directory path.
        /// </summary>
        [TestMethod]
        public void GetDirectoryNameForDirectoryPathNonWindows()
        {
            var directoryPath = ExampleDirectoryPaths.NonWindowsDirectory01Path;
            var expectedDirectoryName = ExampleDirectoryNames.Directory01;

            var actual = this.StringlyTypedPathOperator.GetDirectoryNameForDirectoryPath(directoryPath);

            Assert.AreEqual(expectedDirectoryName, actual);
        }

        /// <summary>
        /// Tests that the parent directory path can be separated out of a Windows directory path.
        /// </summary>
        [TestMethod]
        public void GetParentDirectoryPathForDirectoryPathWindows()
        {
            var directoryPath = ExampleDirectoryPaths.WindowsDirectory02Path;
            var expectedParentDirectoryPath = ExampleDirectoryPaths.WindowsDirectory01Path;

            var actual = this.StringlyTypedPathOperator.GetParentDirectoryPathForDirectoryPath(directoryPath);

            Assert.AreEqual(expectedParentDirectoryPath, actual);
        }

        /// <summary>
        /// Tests that the parent directory path can be separated out of a Windows directory path.
        /// </summary>
        [TestMethod]
        public void GetParentDirectoryPathForDirectoryPathNonWindows()
        {
            var directoryPath = ExampleDirectoryPaths.NonWindowsDirectory02Path;
            var expectedParentDirectoryPath = ExampleDirectoryPaths.NonWindowsDirectory01Path;

            var actual = this.StringlyTypedPathOperator.GetParentDirectoryPathForDirectoryPath(directoryPath);

            Assert.AreEqual(expectedParentDirectoryPath, actual);
        }
    }
}
