using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemoveExtraBlanks;

namespace RemoveExtraBlanksTests
{
    [TestClass]
    public class ParseArgsTests
    {
        [TestMethod]
        public void ParseArgs_EmptyInput_ReturnFalse()
        {
            // Act
            string[] args = new string[] { };
            string inputFile = "";
            string outputFile = "";

            bool endValue = Program.ParseArgs(args, ref inputFile, ref outputFile);

            // Assert
            Assert.IsFalse(endValue);
        }

        [TestMethod]
        public void ParseArgs_IncorrectQuantityArguments_ReturnFalse()
        {
            // Act
            string[] args = new string[3] { "input.txt", "output.txt", "translate" };
            string inputFile = "";
            string outputFile = "";

            bool endValue = Program.ParseArgs(args, ref inputFile, ref outputFile);

            // Assert
            Assert.IsFalse(endValue);
        }


        [TestMethod]
        public void ParseArgs_CorrectInput_ReturnTrue()
        {
            // Act
            string[] args = new string[2] { "input.txt", "output1.txt" };
            string inputFile = "";
            string outputFile = "";

            bool endValue = Program.ParseArgs(args, ref inputFile, ref outputFile);

            // Assert
            Assert.IsTrue(endValue);
        }
    }

    [TestClass]
    public class RemoveExtraBlankInStringTests
    {
        [TestMethod]
        public void RemoveExtraBlankInString_CorrectInput_ReturnTrue()
        {
            // Act
            string extraBlanksStr = "    oy      a kak  tut     ubrat'     probeli      i            tabi";
            extraBlanksStr = Program.RemoveExtraBlankInString(extraBlanksStr);
            string allegedResult = "oy a kak tut ubrat' probeli i tabi";


            // Assert
            Assert.AreEqual(allegedResult, extraBlanksStr);
        }
    }
}
