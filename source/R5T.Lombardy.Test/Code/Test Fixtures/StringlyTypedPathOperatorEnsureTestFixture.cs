using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using R5T.Magyar.Extensions;
using R5T.Salamis;


namespace R5T.Lombardy.Test
{
    public abstract class StringlyTypedPathOperatorEnsureTestFixture
    {
        #region Test-Fixture
        
        public IDirectorySeparatorOperator DirectorySeparatorOperator { get; }
        public IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public StringlyTypedPathOperatorEnsureTestFixture(IDirectorySeparatorOperator directorySeparatorOperator, IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.DirectorySeparatorOperator = directorySeparatorOperator;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        #endregion

        #region Windows and non-Windows

        /// <summary>
        /// Tests that a non-Windows path is converted to a Windows path by ensuring it is a Windows path.
        /// </summary>
        [TestMethod]
        public void EnsureWindowsPathOnNonWindowsPath()
        {
            var nonWindowsPath = ExampleFilePaths.NonWindowsFile01Path;
            var expected = nonWindowsPath.Replace(this.DirectorySeparatorOperator.NonWindowsDirectorySeparatorChar, this.DirectorySeparatorOperator.WindowsDirectorySeparatorChar);

            var actual = this.StringlyTypedPathOperator.EnsureWindowsPath(nonWindowsPath);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests that no change is made to a Windows path by ensuring it is a Windows path.
        /// </summary>
        [TestMethod]
        public void EnsureWindowsPathOnWindowsPath()
        {
            var windowsPath = ExampleFilePaths.WindowsFile01Path;
            var expected = windowsPath;

            var actual = this.StringlyTypedPathOperator.EnsureWindowsPath(windowsPath);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests that a Windows path is converted to a non-Windows path by ensuring it is a non-Windows path.
        /// </summary>
        [TestMethod]
        public void EnsureNonWindowsPathOnWindowsPath()
        {
            var windowsPath = ExampleFilePaths.WindowsFile01Path;
            var expected = windowsPath.Replace(this.DirectorySeparatorOperator.WindowsDirectorySeparatorChar, this.DirectorySeparatorOperator.NonWindowsDirectorySeparatorChar);

            var actual = this.StringlyTypedPathOperator.EnsureNonWindowsPath(windowsPath);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests that no change is made to a non-Windows path by ensuring it is a non-Windows path.
        /// </summary>
        [TestMethod]
        public void EnsureNonWindowsPathOnNonWindowsPath()
        {
            var nonWindowsPath = ExampleFilePaths.NonWindowsFile01Path;
            var expected = nonWindowsPath;

            var actual = this.StringlyTypedPathOperator.EnsureNonWindowsPath(nonWindowsPath);

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Rooted and Relative

        /// <summary>
        /// Tests that a Windows relative path is converted to a rooted path by ensuring it is rooted.
        /// </summary>
        [TestMethod]
        public void EnsureRootedPathOnRelativePathWindows()
        {
            var relativePath = ExampleFilePaths.WindowsFile01FromRootRelativePath;
            var expected = relativePath.Prefix(this.DirectorySeparatorOperator.WindowsDirectorySeparatorChar);

            var actual = this.StringlyTypedPathOperator.EnsureRootedPath(relativePath);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests that a no change is made to a Windows rooted path by ensuring it is a rooted path.
        /// </summary>
        [TestMethod]
        public void EnsureRootedPathOnRootedPathWindows()
        {
            var rootedPath = ExampleFilePaths.WindowsFile01Path;
            var expected = rootedPath;

            var actual = this.StringlyTypedPathOperator.EnsureRootedPath(rootedPath);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests that a Windows rooted path is converted to a relative path by ensuring it is relative.
        /// </summary>
        [TestMethod]
        public void EnsureRelativePathOnRootedPathWindows()
        {
            var rootedPath = ExampleFilePaths.WindowsFile01Path;
            var expected = ExampleFilePaths.WindowsFile01FromRootRelativePath;

            var actual = this.StringlyTypedPathOperator.EnsureRelativePath(rootedPath);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests that no change is made to a Windows relative path by ensuring it is a relative path.
        /// </summary>
        [TestMethod]
        public void EnsureRelativePathOnRelativePathWindows()
        {
            var relativePath = ExampleFilePaths.WindowsFile01FromRootRelativePath;
            var expected = relativePath;

            var actual = this.StringlyTypedPathOperator.EnsureRelativePath(relativePath);

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Directory and File

        /// <summary>
        /// Tests that a Windows file-indicated path is converted to a directory-indicated path by ensuring it is directory-indicated.
        /// </summary>
        [TestMethod]
        public void EnsureDirectoryPathOnFilePathWindows()
        {
            var filePath = ExampleFilePaths.WindowsFile01Path;
            var expected = filePath.Suffix(this.DirectorySeparatorOperator.WindowsDirectorySeparatorChar);

            var actual = this.StringlyTypedPathOperator.EnsureDirectoryPathIsDirectoryIndicated(filePath);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests that no change is made to a Windows directory-indicated path by ensuring it is directory-indicated.
        /// </summary>
        [TestMethod]
        public void EnsureDirectoryPathOnDirectoryPathWindows()
        {
            var directoryPath = ExampleDirectoryPaths.WindowsDirectory01Path;
            var expected = directoryPath;

            var actual = this.StringlyTypedPathOperator.EnsureDirectoryPathIsDirectoryIndicated(directoryPath);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests that a Windows directory-indicated path is converted to a file-indicated path by ensuring it is file-indicated.
        /// </summary>
        [TestMethod]
        public void EnsureFilePathOnDirectoryPathWindows()
        {
            var directoryPath = ExampleDirectoryPaths.WindowsDirectory01Path;
            var expected = directoryPath.ExceptLast();

            var actual = this.StringlyTypedPathOperator.EnsureFileIndicatedPath(directoryPath);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests that no change is made to a Windows file-indicated path by ensuring it is file-indicated.
        /// </summary>
        [TestMethod]
        public void EnsureFilePathOnFilePathWindows()
        {
            var filePath = ExampleFilePaths.WindowsFile01Path;
            var expected = filePath;

            var actual = this.StringlyTypedPathOperator.EnsureFilePathIsNotDirectoryIndicated(filePath);

            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
