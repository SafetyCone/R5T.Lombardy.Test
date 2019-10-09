using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using R5T.Salamis;


namespace R5T.Lombardy.Test
{
    public abstract class StringlyTypedPathOperatorResolvePathTestFixture
    {
        #region Test-Fixture

        public IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public StringlyTypedPathOperatorResolvePathTestFixture(IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        #endregion

        #region Windows

        /// <summary>
        /// Tests resolution of a Windows file path.
        /// </summary>
        [TestMethod]
        public void ResolveWindowsFilePath()
        {
            var unresolvedPath = ExampleFilePaths.WindowsFile01FromWindowsDirectory02PathUnresolved;
            var expected = ExampleFilePaths.WindowsFile01Path;

            var actual = this.StringlyTypedPathOperator.ResolvePath(unresolvedPath);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests resolution of a Windows directory path.
        /// </summary>
        [TestMethod]
        public void ResolveWindowsDirectoryPath()
        {
            var unresolvedPath = ExampleDirectoryPaths.WindowsDirectory01FromWindowsDirectory04PathUnresolved;
            var expected = ExampleDirectoryPaths.WindowsDirectory01Path;

            var actual = this.StringlyTypedPathOperator.ResolvePath(unresolvedPath);

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Non-Windows

        /// <summary>
        /// Tests resolution of a non-Windows file path.
        /// </summary>
        [TestMethod]
        public void ResolveNonWindowsFilePath()
        {
            var unresolvedPath = ExampleFilePaths.NonWindowsFile01FromNonWindowsDirectory02PathUnresolved;
            var expected = ExampleFilePaths.NonWindowsFile01Path;

            var actual = this.StringlyTypedPathOperator.ResolvePath(unresolvedPath);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests resolution of a non-Windows directory path.
        /// </summary>
        [TestMethod]
        public void ResolveNonWindowsDirectoryPath()
        {
            var unresolvedPath = ExampleDirectoryPaths.WindowsDirectory01FromWindowsDirectory04PathUnresolved;
            var expected = ExampleDirectoryPaths.WindowsDirectory01Path;

            var actual = this.StringlyTypedPathOperator.ResolvePath(unresolvedPath);

            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
