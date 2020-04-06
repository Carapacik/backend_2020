using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordStrength;

namespace PasswordStrengthTests
{
    [TestClass]
    public class ParseArgsTests
    {
        [TestMethod]
        public void ParseArgsTests_CorrectInput_ReturnTrue()
        {
            // Act
            string[] args = new string[] { "passmydog" };
            string password = "";

            bool result = Program.ParseArgs(args, ref password);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ParseArgs_EmptyInput_ReturnFalse()
        {
            // Act
            string[] args = new string[] { };
            string password = "";

            bool result = Program.ParseArgs(args, ref password);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ParseArgs_IncorrectQuantityArguments_ReturnFalse()
        {
            // Act
            string[] args = new string[] { "omniknight", "sven" };
            string password = "";

            bool result = Program.ParseArgs(args, ref password);

            // Assert
            Assert.IsFalse(result);
        }
    }

    [TestClass]
    public class IsEnglishLetterInUpperCaseTests
    {
        [TestMethod]
        public void IsEnglishLetterInUpperCase_EnglishLetterInUpperCase_ReturnTrue()
        {
            // Act
            char character = 'F';
            bool result = Program.IsEnglishLetterInUpperCase(character);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsEnglishLetterInUpperCase_NotEnglishLetter_ReturnFalse()
        {
            // Act
            char character = '!';
            bool result = Program.IsEnglishLetterInUpperCase(character);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsEnglishLetterInUpperCase_EnglishLetterInLowerCase_ReturnFalse()
        {
            // Act
            char character = 'f';
            bool result = Program.IsEnglishLetterInUpperCase(character);

            // Assert
            Assert.IsFalse(result);
        }
    }

    [TestClass]
    public class IsEnglishLetterInLowerCaseTests
    {
        [TestMethod]
        public void IsEnglishLetterInLowerCase_EnglishLetterInLowerCase_ReturnTrue()
        {
            // Act
            char character = 'f';
            bool result = Program.IsEnglishLetterInLowerCase(character);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsEnglishLetterInLowerCase_EnglishLetterInUpperCase_ReturnFalse()
        {
            // Act
            char character = 'F';
            bool result = Program.IsEnglishLetterInLowerCase(character);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsEnglishLetterInLowerCase_NotEnglishLetter_ReturnFalse()
        {
            // Act
            char character = '!';
            bool result = Program.IsEnglishLetterInLowerCase(character);

            // Assert
            Assert.IsFalse(result);
        }
    }

    [TestClass]
    public class DoesStringContainOnlyEnglishCharacterOrDigitTests
    {
        [TestMethod]
        public void DoesStringContainOnlyEnglishCharacterOrDigit_CorrectString_ReturnTrue()
        {
            // Act
            string password = "OlOloev987";
            bool result = Program.DoesStringContainOnlyEnglishCharacterOrDigit(password);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DoesStringContainOnlyEnglishCharacterOrDigit_StringContainWrongCharcter_ReturnFalse()
        {
            // Act
            string password = "OlOloev@";
            bool result = Program.DoesStringContainOnlyEnglishCharacterOrDigit(password);

            // Assert
            Assert.IsFalse(result);
        }
    }

    [TestClass]
    public class ReliabilityBasedOnNumberOfAllCharactersTests
    {
        [TestMethod]
        public void ReliabilityBasedOnNumberOfAllCharacters_OneCharacter()
        {
            // Act
            string password = "1";
            int reliability = password.Length * 4;
            int result = Program.ReliabilityBasedOnNumberOfAllCharacters(password);

            // Assert
            Assert.AreEqual(reliability, result);
        }

        [TestMethod]
        public void ReliabilityBasedOnNumberOfAllCharacters_CommonPassword()
        {
            // Act
            string password = "uncommon123";
            int reliability = password.Length * 4;
            int result = Program.ReliabilityBasedOnNumberOfAllCharacters(password);

            // Assert
            Assert.AreEqual(reliability, result);
        }
    }

    [TestClass]
    public class ReliabilityBasedOnNumberOfDigitsTests
    {
        [TestMethod]
        public void ReliabilityBasedOnNumberOfDigits_StringContainOnlyLetters()
        {
            // Act
            string password = "abc";
            int result = Program.ReliabilityBasedOnNumberOfDigits(password);
            int reliability = 0;

            // Assert
            Assert.AreEqual(reliability, result);
        }

        [TestMethod]
        public void ReliabilityBasedOnNumberOfDigits_CommonPassword()
        {
            // Act
            string password = "kiki12345";
            int result = Program.ReliabilityBasedOnNumberOfDigits(password);
            int reliability = 4 * 5;

            // Assert
            Assert.AreEqual(reliability, result);
        }
    }

    [TestClass]
    public class ReliabilityBasedOnNumberOfLettersInUpperCaseTests
    {
        [TestMethod]
        public void ReliabilityBasedOnNumberOfLettersInUpperCase_NotLettersInUpperCase()
        {
            // Act
            string password = "kiki12345";
            int result = Program.ReliabilityBasedOnNumberOfLettersInUpperCase(password);
            int reliability = 0;

            // Assert
            Assert.AreEqual(reliability, result);
        }

        [TestMethod]
        public void ReliabilityBasedOnNumberOfLettersInUpperCase_ConsistLettersInUpperCase()
        {
            // Act
            string password = "MEM228";
            int result = Program.ReliabilityBasedOnNumberOfLettersInUpperCase(password);
            int reliability = (password.Length - 3) * 2;

            // Assert
            Assert.AreEqual(reliability, result);
        }
    }

    [TestClass]
    public class ReliabilityBasedOnNumberOfLettersInLowerCaseTests
    {
        [TestMethod]
        public void ReliabilityBasedOnNumberOfLettersInLowerCase_NotLettersInLowerCase()
        {
            // Act
            string password = "MONSTER7";
            int result = Program.ReliabilityBasedOnNumberOfLettersInLowerCase(password);
            int reliability = 0;

            // Assert
            Assert.AreEqual(reliability, result);
        }

        [TestMethod]
        public void ReliabilityBasedOnNumberOfLettersInUpperCase_ConsistLettersInLowerCase()
        {
            // Act
            string password = "XXXalexXXX";
            int result = Program.ReliabilityBasedOnNumberOfLettersInLowerCase(password);
            int reliability = (password.Length - 4) * 2;

            // Assert
            Assert.AreEqual(reliability, result);
        }
    }

    [TestClass]
    public class ReliabilityWhenPasswordConsistsOnlyOfLettersTests
    {
        [TestMethod]
        public void ReliabilityWhenPasswordConsistsOnlyOfLetters_OnlyLettersInString()
        {
            // Act
            string password = "alealealenushka";
            int result = Program.ReliabilityWhenPasswordConsistsOnlyOfLetters(password);
            int reliability = password.Length;

            // Assert
            Assert.AreEqual(reliability, result);
        }

        [TestMethod]
        public void ReliabilityWhenPasswordConsistsOnlyOfLetters_ConsistLettersAndDigits()
        {
            // Act
            string password = "Mama1Papa2";
            int result = Program.ReliabilityWhenPasswordConsistsOnlyOfLetters(password);
            int reliability = 0;

            // Assert
            Assert.AreEqual(reliability, result);
        }
    }

    [TestClass]
    public class ReliabilityWhenPasswordConsistsOnlyOfDigitsTests
    {
        [TestMethod]
        public void ReliabilityWhenPasswordConsistsOnlyOfDigits_OnlyDigitsInString()
        {
            // Act
            string password = "12345";
            int result = Program.ReliabilityWhenPasswordConsistsOnlyOfDigits(password);
            int reliability = password.Length;

            // Assert
            Assert.AreEqual(reliability, result);
        }

        [TestMethod]
        public void ReliabilityWhenPasswordConsistsOnlyOfDigits_ConsistLettersAndDigits()
        {
            // Act
            string password = "mama1papa2";
            int result = Program.ReliabilityWhenPasswordConsistsOnlyOfDigits(password);
            int reliability = 0;

            // Assert
            Assert.AreEqual(reliability, result);
        }
    }

    [TestClass]
    public class ReliabilityHowManyRepetitionsCharactersTests
    {
        [TestMethod]
        public void ReliabilityHowManyRepetitionsCharacters_NotRepetitions()
        {
            // Act
            string password = "abc12345";
            int result = Program.ReliabilityHowManyRepetitionsCharacters(password);
            int reliability = 0;

            // Assert
            Assert.AreEqual(reliability, result);
        }

        [TestMethod]
        public void ReliabilityHowManyRepetitionsCharacters_OneRepetition()
        {
            // Act
            string password = "abc12345a";
            int result = Program.ReliabilityHowManyRepetitionsCharacters(password);
            int reliability = 2;

            // Assert
            Assert.AreEqual(reliability, result);
        }

        [TestMethod]
        public void ReliabilityHowManyRepetitionsCharacters_ManyRepetitions()
        {
            // Act
            string password = "AAAtree1234";
            int result = Program.ReliabilityHowManyRepetitionsCharacters(password);
            int reliability = 3 + 2;

            // Assert
            Assert.AreEqual(reliability, result);
        }

        [TestMethod]
        public void ReliabilityHowManyRepetitionsCharacters_SoManyRepetitions()
        {
            // Act
            string password = "AAAtree12344444444444";
            int result = Program.ReliabilityHowManyRepetitionsCharacters(password);
            int reliability = 3 + 2 + 11;

            // Assert
            Assert.AreEqual(reliability, result);
        }
    }

    [TestClass]
    public class FindPassStrengthTests
    {
        [TestMethod]
        public void FindPassStrength_EmptyString()
        {
            // Act
            string password = "";
            int result = Program.FindPassStrength(password);
            int reliability = 0;

            // Assert
            Assert.AreEqual(reliability, result);
        }

        [TestMethod]
        public void FindPassStrength_OneLetter()
        {
            // Act
            string password = "a";
            int result = Program.FindPassStrength(password);
            int reliability = 4 - 1;

            // Assert
            Assert.AreEqual(reliability, result);
        }

        [TestMethod]
        public void FindPassStrength_OneDigit()
        {
            // Act
            string password = "1";
            int result = Program.FindPassStrength(password);
            int reliability = 4 + 4 - 1;

            // Assert
            Assert.AreEqual(reliability, result);
        }

        [TestMethod]
        public void FindPassStrength_CommonPassword()
        {
            // Act
            string password = "uncommon123";
            int result = Program.FindPassStrength(password);
            int reliability = 4 * 11 + 4 * 3 + (11 - 8) * 2 - 2 - 2 - 2;

            // Assert
            Assert.AreEqual(reliability, result);
        }
    }
}