using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace R5T.Lombardy.Test
{
    public abstract class DirectorySeparatorOperatorTestArticleTestFixture
    {
        #region Initialization

        public IDirectorySeparatorOperatorTestArticle DirectorySeparatorOperatorTestArticle { get; }


        public DirectorySeparatorOperatorTestArticleTestFixture(IDirectorySeparatorOperatorTestArticle directorySeparatorOperatorTestArticle)
        {
            this.DirectorySeparatorOperatorTestArticle = directorySeparatorOperatorTestArticle;
        }

        #endregion
    }
}
