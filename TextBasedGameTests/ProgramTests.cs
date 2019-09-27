using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextBasedGame.Shared.Constants;

namespace TextBasedGameTests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void GameTitle_ShouldBeChanged()
        {
            var defaultGameTitle = "Awesome Title!";
            var actualGameTitle = TextBasedGame.Program.GameTitle.Title;

            Assert.AreNotEqual(defaultGameTitle, actualGameTitle);
        }

        [TestMethod]
        public void GameAuthor_ShouldBeChanged()
        {
            var defaultGameAuthor = "<Your Name Here!>";
            var actualGameAuthor = TextBasedGame.Program.GameTitle.Author;

            Assert.AreNotEqual(defaultGameAuthor, actualGameAuthor);
        }

        [TestMethod]
        public void GameIntroText_ShouldBeChanged()
        {
            var defaultGameIntroText = "It was a dark and stormy night... \n";
            var actualGameIntroText = ConsoleStrings.GameIntro;

            Assert.AreNotEqual(defaultGameIntroText, actualGameIntroText);
        }
    }
}