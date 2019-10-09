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
        #region Test-Fixture

        public IDirectorySeparatorOperator DirectorySeparatorOperator { get; set; }


        public DirectorySeparatorPlatformSpecificTestFixture(IDirectorySeparatorOperator directorySeparatorOperator)
        {
            this.DirectorySeparatorOperator = directorySeparatorOperator;
        }

        #endregion


        /// <summary>
        /// Provided by derived class to enable platform indirection.
        /// </summary>
        public abstract Platform Platform { get; }
        public abstract char PlatformDirectorySeparatorChar { get; }
        public abstract string PlatformDirectorySeparator { get; }


        /// <summary>
        /// Set the platform for use in testing.
        /// This should be in a <see cref="ClassInitializeAttribute"/> static method to avoid performing the same work for each test, but that would have to be done as a static method of the derived class, which would mean the test-fixture would require setup outside of itself.
        /// </summary>
        [TestInitialize]
        public void Initialization(TestContext testContext)
        {
            PlatformOperator.Platform = Platform.NonWindows;
        }

        [TestCleanup]
        public void Cleanup()
        {
            PlatformOperator.ResetPlatform();
        }

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
