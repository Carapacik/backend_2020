using CheckIdentifier;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckidentifierTests
{
    [TestClass]
    public class CheckIdentifierTests
    {
        [TestMethod]
        public void CheckIdentifier_EmptyString_ReturnFalse()
        {
            // Act
            string str = "";
            int result  = Program.CheckIdentifier(str);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CheckIdentifier_StartingWithDigit_ReturnFalse()
        {
            // Act
            string str = "0Alo";
            int result = Program.CheckIdentifier(str);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CheckIdentifier_StringWithIncorrectSymbol_ReturnFalse()
        {
            // Act
            string str = "Alo[";
            int result = Program.CheckIdentifier(str);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CheckIdentifier_CorrectString_ReturnTrue()
        {
            // Act
            string str = "End11";
            int result = Program.CheckIdentifier(str);

            // Assert
            Assert.AreEqual(0, result);
        }
    }

    [TestClass]
    public class IsSymbolLetterOrDigitTests
    {
        [TestMethod]
        public void IsSymbolLetterOrDigit_EmptyString_ReturnTrue()
        {
            // Act
            string str = "";
            bool result = Program.IsSymbolLetterOrDigit(str);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsSymbolLetterOrDigit_IncorrectSymbolInString_ReturnFalse()
        {
            // Act
            string str = "lala&lola";
            bool result = Program.IsSymbolLetterOrDigit(str);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsSymbolLetterOrDigit_CorrectSymbols_ReturnTrue()
        {
            // Act
            string str = "False";
            bool result = Program.IsSymbolLetterOrDigit(str);

            // Assert
            Assert.IsTrue(result);
        }
    }

    [TestClass]
    public class IsLetterTests
    {
        [TestMethod]
        public void IsLetter_EnglishLetterInUpperCase_ReturnTrue()
        {
            // Act
            char letter = 'S';
            bool result = Program.IsLetter(letter);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsLetter_EnglishLetterInLowerCase_ReturnTrue()
        {
            // Act
            char letter = 's';
            bool result = Program.IsLetter(letter);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsLetter_Digit_ReturnFalse()
        {
            // Act
            char notletter = '2';
            bool result = Program.IsLetter(notletter);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsLetter_WithNotLetter_ReturnFalse()
        {
            // Act
            char notletter = '[';
            bool result = Program.IsLetter(notletter);

            // Assert
            Assert.IsFalse(result);
        }
    }

    [TestClass]
    public class ParseArgsTests
    {
        [TestMethod]
        public void ParseArgs_EmptyInput_ReturnFalse()
        {            
            // Act
            string[] args = new string[] { };
            string inputStr = "";

            bool endValue = Program.ParseArgs(args, ref inputStr);

            // Assert
            Assert.IsFalse(endValue);
        }

        [TestMethod]
        public void ParseArgs_IncorrectArgumentsInInput_ReturnFalse()
        {
            // Act
            string[] args = new string[2] { "Alo", "Privet" };
            string inputStr = "";

            bool endValue = Program.ParseArgs(args, ref inputStr);

            // Assert
            Assert.IsFalse(endValue);
        }

        [TestMethod]
        public void ParseArgs_CorrectInput_ReturnTrue()
        {
            // Act
            string[] args = new string[] { "Begin" };
            string inputStr = "";

            bool endValue = Program.ParseArgs(args, ref inputStr);

            // Assert
            Assert.IsTrue(endValue);
        }
    }
}
