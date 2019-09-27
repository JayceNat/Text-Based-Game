using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextBasedGame.Character.Handlers;
using TextBasedGameTests.TestConstants;

namespace TextBasedGameTests.CharacterTests.HandlerTests
{
    [TestClass]
    public class PlayerActionHandlerTests
    {
        [TestMethod]
        public void CreateSubstringOfActionInput_ShouldReturnSubstring()
        {
            var fullCmdLineInput = "enter observatory";
            var firstWordKeyword = "enter";
            var expectedOutput = "observatory";

            var result = PlayerActionHandler.CreateSubstringOfActionInput(fullCmdLineInput, firstWordKeyword);

            Assert.AreEqual(expectedOutput, result);
        }
    }
}