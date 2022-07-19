namespace FreqWord
{
    internal class Program
    {
        public static void InputFromConsole(out string inputString)
        {
            Console.WriteLine("Введите исследуемый текст:");
            inputString = Console.ReadLine();
        }

        static void Main(string[] args)
        {
            /**
             *  Подсчет частоты слов в тексте
             *  1. Ввод текста с клавиатуры
             *  2. Ввод из файла 
             */
            //----------------------------------------------
            string inputString;
            Console.Write("Хотите ввести текст из файла(Y/n):");
            if(Console.ReadLine().Trim().ToLower().Equals("y"))
            {
                Console.Write("Укажите путь к файлу:");
                string filname = Console.ReadLine();
                if (System.IO.File.Exists(filname) == false)
                {
                    Console.Write("Вы ввели несуществующий путь к файлу. ");
                    InputFromConsole(out inputString);
                }
                else
                {
                    inputString = System.IO.File.ReadAllText(filname);
                }
            }    
            else
            {
                InputFromConsole(out inputString);
            }
            
            string[]? words = inputString.Split(" ");// $1
            int allWords = words.Length;
            Console.WriteLine("Общее количество слов в тексте: {0}",allWords);

            List<UniqueWord> uniqWords = new List<UniqueWord>();
            foreach(string word in words.Distinct().ToArray())
            {
                uniqWords.Add(new UniqueWord() { Word = word, Count = UniqueWord.CountWords(words,word) });
            }

            foreach(UniqueWord uniqueWord in uniqWords)
            {
                double freq = (double)uniqueWord.Count / (double)allWords;
                Console.WriteLine("{0} - {1}", uniqueWord.Word, freq);
            }
        }
    }

    public class UniqueWord
    {
        public string Word { get; set; }
        public int Count { get; set; }

        public static int CountWords(string[] words, string word)
        {
            int i = 0;
            foreach (string freq in words)
            {
                if (freq.ToLower().Equals(word.ToLower())) i++;
            }
            return i;
        }
    }
}