using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using R5T.Rugia;


namespace R5T.Lombardy.Test
{
    /// <summary>
    /// The explicit platform indirection <see cref="R5T.Rugia.Platform"/> 
    /// </summary>
    public abstract class DirectorySeparatorPlatformSpecificTestFixture
    {
        #region Test Fixture

        public IDirectorySeparatorOperator DirectorySeparatorOperator { get; set; }


        public DirectorySeparatorPlatformSpecificTestFixture(IDirectorySeparatorOperator directorySeparatorOperator)
        {
            this.DirectorySeparatorOperator = directorySeparatorOperator;
        }

        #endregion


        /// <summary>
        /// Provided by derived class to enable platform indirection.
        /// </summary>
        public abstract char PlatformDirectorySeparatorChar { get; }
        public abstract string PlatformDirectorySeparator { get; }


        [TestMethod]
        public void PlatformDefaultDirectorySeparatorChar()
        {
            var platformDefaultDirectorySeparatorChar = this.DirectorySeparatorOperator.PlatformDefaultDirectorySeparatorChar;

            Assert.AreEqual(platformDefaultDirectorySeparatorChar, this.PlatformDirectorySeparatorChar);
        }

        [TestMethod]
        public void PlatformDefaultDirectorySeparator()
        {
            var platformDefaultDirectorySeparator = this.DirectorySeparatorOperator.PlatformDefaultDirectorySeparator;

            Assert.AreEqual(platformDefaultDirectorySeparator, this.PlatformDirectorySeparator);
        }
    }
}
