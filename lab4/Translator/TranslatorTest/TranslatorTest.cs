using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TranslatorTest
{
    [TestClass]
    public class TranslateTest
    {
        Translator.Models.Translator dict = new Translator.Models.Translator("../../../dictionary.txt");

        [TestMethod]
        public void Transalte_EnglishWord_ReturnTranslation()
        {
            string word = "red";
            string result = dict.Transalte(word);
            Assert.AreEqual("красный", result);
        }

        [TestMethod]
        public void Transalte_RussianWord_ReturnTranslation()
        {
            string word = "привет";
            string result = dict.Transalte(word);
            Assert.AreEqual("hello", result);
        }

        [TestMethod]
        public void Transalte_NotExistingWord_ReturnNullTranslation()
        {
            string word = "lol";
            string result = dict.Transalte(word);
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void Transalte_EmptyString_ReturnNullTranslation()
        {
            string word = "";
            string result = dict.Transalte(word);
            Assert.AreEqual("", result);
        }
    }
}
