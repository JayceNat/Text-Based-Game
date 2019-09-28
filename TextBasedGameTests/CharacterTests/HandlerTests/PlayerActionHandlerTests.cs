using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextBasedGame.Character.Handlers;

namespace TextBasedGameTests.CharacterTests.HandlerTests
{
    [TestClass]
    public class PlayerActionHandlerTests
    {
        [TestMethod]
        public void CreateSubstringOfActionInput_ShouldReturnSubstring()
        {
            const string fullCmdLineInput = "enter observatory";
            const string firstWordKeyword = "enter";
            const string expectedOutput = "observatory";

            var result = PlayerActionHandler.CreateSubstringOfActionInput(fullCmdLineInput, firstWordKeyword);

            Assert.AreEqual(expectedOutput, result);
        }
    }
}