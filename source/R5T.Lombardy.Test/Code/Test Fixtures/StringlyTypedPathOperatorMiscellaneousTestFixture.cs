using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using R5T.Salamis;


namespace R5T.Lombardy.Test
{
    public abstract class StringlyTypedPathOperatorMiscellaneousTestFixture
    {
        #region Test-Fixture

        public IDirectorySeparatorOperator DirectorySeparatorOperator { get; }
        public IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public StringlyTypedPathOperatorMiscellaneousTestFixture(IDirectorySeparatorOperator directorySeparatorOperator, IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.DirectorySeparatorOperator = directorySeparatorOperator;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        #endregion


        /// <summary>
        /// Test of ability to detect Windows directory separator.
        /// </summary>
        [TestMethod]
        public void DetectDirectorySeparatorWindows()
        {
            var path = ExampleFilePaths.WindowsFile01Path;
            var expectedDirectorySeparator = this.DirectorySeparatorOperator.WindowsDirectorySeparator;

            var actualDirectorySeparator = this.StringlyTypedPathOperator.DetectDirectorySeparator(path);

            Assert.AreEqual(expectedDirectorySeparator, actualDirectorySeparator);
        }

        /// <summary>
        /// Test of ability to detect non-Windows directory separator.
        /// </summary>
        [TestMethod]
        public void DetectDirectorySeparatorNonWindows()
        {
            var path = ExampleFilePaths.NonWindowsFile01Path;
            var expectedDirectorySeparator = this.DirectorySeparatorOperator.NonWindowsDirectorySeparator;

            var actualDirectorySeparator = this.StringlyTypedPathOperator.DetectDirectorySeparator(path);

            Assert.AreEqual(expectedDirectorySeparator, actualDirectorySeparator);
        }

        /// <summary>
        /// Test of ability to detect Windows directory separator in mixed, but Windows-dominant paths.
        /// </summary>
        [TestMethod]
        public void DetectDirectorySeparatorMixedWindowsDominant()
        {
            var path = ExampleFilePaths.MixedWindowsDominantFile01Path;
            var expectedDirectorySeparator = this.DirectorySeparatorOperator.WindowsDirectorySeparator;

            var actualDirectorySeparator = this.StringlyTypedPathOperator.DetectDirectorySeparator(path);

            Assert.AreEqual(expectedDirectorySeparator, actualDirectorySeparator);
        }

        /// <summary>
        /// Test of ability to detect non-Windows directory separator in mixed, but non-Windows dominant paths.
        /// </summary>
        [TestMethod]
        public void DetectDirectorySeparatorMixedNonWindowsDominant()
        {
            var path = ExampleFilePaths.MixedNonWindowsDominantFile01Path;
            var expectedDirectorySeparator = this.DirectorySeparatorOperator.NonWindowsDirectorySeparator;

            var actualDirectorySeparator = this.StringlyTypedPathOperator.DetectDirectorySeparator(path);

            Assert.AreEqual(expectedDirectorySeparator, actualDirectorySeparator);
        }
    }
}
