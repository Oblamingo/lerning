using System;

namespace Lerning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] sentence;

            string text = "Я есмь Альфа и Омега начало и конец жаждущему дам даром от источника воды живой";
            char splitChar = ' ';

            sentence = text.Split(splitChar);

            foreach (string word in sentence)
            {
                Console.WriteLine(word);
            }

            Console.ReadKey();
        }
    }
}
