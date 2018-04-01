using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ30._03
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "This was all, together with the picture of the hellish image; but what" +
                " a train of ideas it started in my mind! Had my uncle, in his latter years, become" +
                " credulous of the most superficial impostures? Behind the figure was a vague suggestion" +
                " of a Cyclopean architectural background.";
            int count = 0;
            int x = 1;
            int[] arr = new int[3];
            string[] lastwords = new string[3];
            string[] words = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            //считаем кол-во слов в каждом предложении и записываем последнее слово каждого предложения
            foreach (string a in words)
            {
                if (a.EndsWith("!") || a.EndsWith("?") || a.EndsWith("."))
                {
                    Console.WriteLine("The " + x + " sentence containt " + (count + 1) + " words.");
                    arr[x - 1] = count;
                    lastwords[x - 1] = a;
                    count = -1;
                    x++;
                }
                count++;
            }
            //для сокращения создем переменные равные последним словам в предложениях
            string w1 = lastwords[0];
            string w2 = lastwords[1];
            string w3 = lastwords[2];
            //определем номер первой буквы последнего слова предложения в строке
            int startIndex = s.IndexOf(w1);
            int middleIndex = s.IndexOf(w2);
            int endIndex = s.IndexOf(w3);
            //находим предложение с минимальным количеством слов и выводим его с помощью Substring
            if (arr[0] < arr[1] && arr[0] < arr[2])
            {
                Console.WriteLine("The sentence number " + 1 + " contains the smallest number of words :\n"
                    + s.Substring(0, startIndex) + w1);
            }
            else if (arr[1] < arr[0] && arr[1] < arr[2])
            {
                Console.WriteLine("The sentence number " + 2 + " contains the smallest number of words :\n"
                    + s.Substring(startIndex + w1.Length, middleIndex + w2.Length - startIndex - w1.Length));
            }
            else
            {
                Console.WriteLine("The sentence number " + 3 + " contains the smallest number of words :\n"
                    + s.Substring(middleIndex + w2.Length, endIndex + w3.Length - middleIndex - w2.Length));
            }
            Console.ReadKey();
        }
    }
}
