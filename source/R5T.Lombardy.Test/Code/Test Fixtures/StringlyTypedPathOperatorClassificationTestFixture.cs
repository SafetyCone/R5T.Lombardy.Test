using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using R5T.Salamis;


namespace R5T.Lombardy.Test
{
    public abstract class StringlyTypedPathOperatorClassificationTestFixture
    {
        #region Test-Fixture

        public IStringlyTypedPathOperator StringlyTypedPathOperator { get; set; }


        public StringlyTypedPathOperatorClassificationTestFixture(IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        #endregion

        #region Windows and non-Windows

        /// <summary>
        /// Tests that a Windows path is recognized as a Windows path.
        /// </summary>
        [TestMethod]
        public void IsWindowsPathWindowsPath()
        {
            var windowsPath = ExampleFilePaths.WindowsFile01Path;
            var expected = true;

            var actual = this.StringlyTypedPathOperator.IsWindowsPath(windowsPath);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests that a non-Windows path is not recognized as a Windows path.
        /// </summary>
        [TestMethod]
        public void IsNonWindowsPathNotWindowsPath()
        {
            var nonWindowsPath = ExampleFilePaths.NonWindowsFile01Path;
            var expected = false;

            var actual = this.StringlyTypedPathOperator.IsWindowsPath(nonWindowsPath);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests that a non-Windows path is recognized as a non-Windows path.
        /// </summary>
        [TestMethod]
        public void IsNonWindowsPathNonWindowsPath()
        {
            var nonWindowsPath = ExampleFilePaths.NonWindowsFile01Path;
            var expected = true;

            var actual = this.StringlyTypedPathOperator.IsNonWindowsPath(nonWindowsPath);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests that a Windows path is not recognized as a non-Windows path.
        /// </summary>
        [TestMethod]
        public void IsWindowsPathNotNonWindowsPath()
        {
            var windowsPath = ExampleFilePaths.WindowsFile01Path;
            var expected = false;

            var actual = this.StringlyTypedPathOperator.IsNonWindowsPath(windowsPath);

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Rooted (Absolute) and Relative

        /// <summary>
        /// Tests that a rooted path is recognized as rooted.
        /// </summary>
        [TestMethod]
        public void IsRootedPathRooted()
        {
            var rootedPath = ExampleFilePaths.WindowsFile01Path;
            var expected = true;

            var actual = this.StringlyTypedPathOperator.IsRootedPath(rootedPath);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests that a relative path is recognized as not rooted.
        /// </summary>
        [TestMethod]
        public void IsRelativePathNotRooted()
        {
            var relativePath = ExampleFilePaths.WindowsFile01FromRootRelativePath;
            var expected = false;

            var actual = this.StringlyTypedPathOperator.IsRootedPath(relativePath);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests that a relative path is recognized as relative.
        /// </summary>
        [TestMethod]
        public void IsRelativePathPathRelative()
        {
            var relativePath = ExampleFilePaths.WindowsFile01FromRootRelativePath;
            var expected = true;

            var actual = this.StringlyTypedPathOperator.IsRelativePath(relativePath);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests that a rooted path is recognized as not relative.
        /// </summary>
        [TestMethod]
        public void IsRootedPathNotRelative()
        {
            var rootedPath = ExampleFilePaths.WindowsFile01Path;
            var expected = false;

            var actual = this.StringlyTypedPathOperator.IsRootedPath(rootedPath);

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Directory and File

        /// <summary>
        /// Tests that a directory path is recognized as a directory path.
        /// </summary>
        [TestMethod]
        public void IsDirectoryPathDirectoryPath()
        {
            var directoryPath = ExampleDirectoryPaths.WindowsDirectory01Path;
            var expected = true;

            var actual = this.StringlyTypedPathOperator.IsDirectoryPath(directoryPath);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests that a not-directory indicated path is not recognized as a directory path.
        /// </summary>
        [TestMethod]
        public void IsNotDirectoryIndicatedPathNotDirectoryPath()
        {
            var directoryPath = ExampleDirectoryPaths.WindowsDirectory01PathUnindicated; // Could be a file path! At the string level of abstraction there is no way to know for sure without asking the file system!
            var expected = false;

            var actual = this.StringlyTypedPathOperator.IsDirectoryPath(directoryPath);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests that a file path is recognized as a file path.
        /// </summary>
        [TestMethod]
        public void IsFilePathFilePath()
        {
            var filePath = ExampleFilePaths.WindowsFile01Path;
            var expected = true;

            var actual = this.StringlyTypedPathOperator.IsFilePath(filePath);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests that a directory-indicated file path is not recognized as a file path.
        /// </summary>
        [TestMethod]
        public void IsDirectoryIndicatedFilePathNotFilePath()
        {
            var filePath = ExampleFilePaths.WindowsFile01DirectoryIndicatedPath;
            var expected = false;

            var actual = this.StringlyTypedPathOperator.IsFilePath(filePath);

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Resolved and Unresolved

        /// <summary>
        /// Tests that a resolved path is recognized as resolved.
        /// </summary>
        [TestMethod]
        public void IsResolvedPathResolved()
        {
            var resolvedPath = ExampleFilePaths.WindowsFile01Path;
            var expected = true;

            var actual = this.StringlyTypedPathOperator.IsResolvedPath(resolvedPath);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests that an unresolved path is not recognized as resolved.
        /// </summary>
        [TestMethod]
        public void IsUnresolvedPathNotResolved()
        {
            var unresolvedPath = ExampleFilePaths.WindowsFile01FromWindowsDirectory02PathUnresolved;
            var expected = false;

            var actual = this.StringlyTypedPathOperator.IsResolvedPath(unresolvedPath);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests that an unresolved path is recognized as unresolved.
        /// </summary>
        [TestMethod]
        public void IsUnresolvedPathUnresolved()
        {
            var unresolvedPath = ExampleFilePaths.WindowsFile01FromWindowsDirectory02PathUnresolved;
            var expected = true;

            var actual = this.StringlyTypedPathOperator.IsUnresolvedPath(unresolvedPath);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests that an resolved path is not recognized as unresolved.
        /// </summary>
        [TestMethod]
        public void IsResolvedPathNotUnresolved()
        {
            var resolvedPath = ExampleFilePaths.WindowsFile01Path;
            var expected = false;

            var actual = this.StringlyTypedPathOperator.IsUnresolvedPath(resolvedPath);

            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
