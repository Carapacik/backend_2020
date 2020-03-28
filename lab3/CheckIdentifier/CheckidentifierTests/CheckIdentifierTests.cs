using CheckIdentifier;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckidentifierTests
{
    [TestClass]
    public class CheckIdentifierTests
    {
        [TestMethod]
        public void CheckIdentifierTests_IncorrectSymbol()
        {
            // Act
            string[] wrongStr = new string[1]{ "Silens!" };

            int endValue = Program.Main(wrongStr);

            // Assert
            Assert.AreEqual(1, endValue);

        }

        [TestMethod]
        public void CheckIdentifierTests_IncorrectArgumentsCount()
        {
            // Act
            string[] wrongStr = new string[2] { "Privet", "Alo" };

            int endValue = Program.Main(wrongStr);

            // Assert
            Assert.AreEqual(1, endValue);
        }

        [TestMethod]
        public void CheckIdentifierTests_StartWithDigit()
        {
            // Act
            string[] wrongStr = new string[1] { "1Begin" };

            int endValue = Program.Main(wrongStr);

            // Assert
            Assert.AreEqual(1, endValue);
        }

        [TestMethod]
        public void CheckIdentifierTests_InputIsEmptyString()
        {
            // Act
            string[] wrongStr = new string[1] {""};

            int endValue = Program.Main(wrongStr);

            // Assert
            Assert.AreEqual(1, endValue);
        }

        [TestMethod]
        public void CheckIdentifierTests_EmptyInput()
        {
            // Act
            string[] wrongStr = new string[0] {};

            int endValue = Program.Main(wrongStr);

            // Assert
            Assert.AreEqual(1, endValue);
        }

        [TestMethod]
        public void CheckIdentifierTests_CorrectInput()
        {
            // Act
            string[] correctStr = new string[1] { "Begin" };

            int endValue = Program.Main(correctStr);

            // Assert
            Assert.AreEqual(0, endValue);
        }

        [TestMethod]
        public void IsNumber_Number_ReturnTrue()
        {
            // Act
            char number = '1';
            bool resresult = CheckIdentifier.Program.IsNumber(number);

            // Assert
            Assert.AreEqual(true, resresult);
        }

        [TestMethod]
        public void IsNumber_NotNumber_ReturnTrue()
        {
            // Act
            char notnumber = '[';
            bool resresult = CheckIdentifier.Program.IsNumber(notnumber);

            // Assert
            Assert.AreEqual(false, resresult);
        }

        [TestMethod]
        public void IsLetter_WithLetterUpperCase_ReturnTrue()
        {
            // Act
            char letter = 'B';
            bool resresult = CheckIdentifier.Program.IsLetter(letter);

            // Assert
            Assert.AreEqual(true, resresult);
        }


        [TestMethod]
        public void IsLetter_WithLetterLowerCase_ReturnTrue()
        {
            // Act
            char letter = 'c';
            bool resresult = CheckIdentifier.Program.IsLetter(letter);

            // Assert
            Assert.AreEqual(true, resresult);
        }

        [TestMethod]
        public void IsLetter_WithNotLetter_ReturnFalse()
        {
            // Act
            char notletter = '[';
            bool resresult = CheckIdentifier.Program.IsLetter(notletter);

            // Assert
            Assert.AreEqual(false, resresult);
        }
    }
}
