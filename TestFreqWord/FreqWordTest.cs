using FreqWord;

namespace TestFreqWord
{
    [TestClass]
    public class FreqWordTest
    {
        [TestMethod]
        public void Test_true()
        {
            Assert.IsTrue(true);
        }
        
        [TestMethod]
        public void Test_1_CountWords()
        {
            string[] words = { "test", "test", "test", "te st" };
            Assert.AreEqual(4, FreqWord.UniqueWord.CountWords(words, "test"));
        }
        
        [TestMethod]
        public void Test_2_CountWords()
        {
            string[] words = { "test", "Test", "test", "test" };
            Assert.AreEqual(4, FreqWord.UniqueWord.CountWords(words, "test"));
        }
        
        [TestMethod]
        public void Test_3_CountWords()
        {
            string[] words = { "test", "test", "test,", "test." };
            Assert.AreEqual(4, FreqWord.UniqueWord.CountWords(words, "test"));
        }

        [TestMethod]
        public void Test_4_CountWords()
        {
            string[] words = { "test", "test", "test ", "  test" };
            Assert.AreEqual(4, FreqWord.UniqueWord.CountWords(words, "test"));
        }

    }
}
