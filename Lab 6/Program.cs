using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab_6
{
    class Program
    {
        static int GetCount(char[] array, char[] ar)
        {
            int Count = 0;

            foreach (char ch in array)
            {
                foreach (char cha in ar)
                {
                    if (ch == cha)
                    {
                        Count++;
                    }
                }
            }
            return Count;
        }

        static int GetCount1( List <char> array,  List <char> ar)
        {
            int Count = 0;

            foreach (char ch in array)
            {
                foreach (char cha in ar)
                {
                    if (ch == cha)
                    {
                        Count++;
                    }
                }
            }
            return Count;
        }


        public static double PrintMeanValueForEachMonth(int sum)
        {

            return sum / 30;
        }








        static void Main(string[] args)
        {

            Console.WriteLine("Задание 1");
            char[] vowels = "АЕЁИОУЫЭЮЯ".ToLower().ToCharArray(); 
            char[] consonants = "БВГДЖЗЙКЛМНПРСТФХЦЧШЩЬЪ".ToLower().ToCharArray(); 

            string str = File.ReadAllText(@"09.10.2021.txt");
            char[] array = str.ToLower().ToCharArray(); 

            int vowelsCount = GetCount(array, vowels);
            int consonantsCount = GetCount(array, consonants); 

            Console.WriteLine("Гласных в массиве: " + vowelsCount);
            Console.WriteLine("Согласных в массиве: " + consonantsCount);



            Console.WriteLine("\nМесяцы");
            Random rnd = new Random();
            int[,] tem = new int[12,30];
            
            for (int i = 0; i < tem.GetLength(0); i++)
            {
                int sum = 0;
                for (int j = 0; j < tem.GetLength(1); j++)
                {
                    tem[i, j] = rnd.Next(-30, 30);
                    Console.Write(tem[i, j] + " ");
                    sum += tem[i, j];
                    if (j == tem.GetLength(1) - 1)
                    {
                        Console.WriteLine("\nСреднее");

                        Console.WriteLine(PrintMeanValueForEachMonth(sum));
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n List");
            List<char> Vowels = new List<char>("АЕЁИОУЫЭЮЯ".ToLower().ToCharArray()); 
            List<char> Consonants = new List<char>("БВГДЖЗЙКЛМНПРСТФХЦЧШЩЬЪ".ToLower().ToCharArray()); 
            FileStream Stream = new FileStream(@"09.10.2021.txt", FileMode.Open);
            StreamReader Reader = new StreamReader(Stream);
            string stR1 = Reader.ReadToEnd();
            Stream.Close();

            List<char> Str1 = new List<char>(stR1.ToLower().ToCharArray()); 

            int VowelsCount = GetCount1(Str1, Vowels); 
            int ConsonantsCount = GetCount1(Str1, Consonants); 

            Console.WriteLine("Гласных в массиве: " + VowelsCount);
            Console.WriteLine("Согласных в массиве: " + ConsonantsCount);



            Console.WriteLine("\nПроверка пароля - двоичный в строку");
            string s = File.ReadAllText(@"password.txt");
            string result = new string(s.Split(new[] { ' ' }).Select(i => (char)(Convert.ToInt32(i, 2))).ToArray());
            Console.WriteLine("\nЗадание 3");
            int col = Convert.ToInt32(Console.ReadLine());
            string[] passvords = new string[col];
            bool temp = true;
            for (int i = 0; i < passvords.Length; i++)
            {
                passvords[i] = Console.ReadLine();
                if (passvords[i] == result)
                {
                    Console.WriteLine(result);
                    temp = false;
                }

            }
            if (temp)
            {
                Console.WriteLine("False");
            }

            Console.WriteLine("\nАдская кухня");
            string stR = Console.ReadLine();
            string[] words = stR.Split(new char[] { ' ' });
            string word1 = words[0];
            string word2 = words[1];
            string word3 = words[2];
            string word4 = words[3];
            string alfavit = "ЕЁИОУЫЭЮЯ";
            for (int i = 0; i < 4; i++)
            {

                words[i] = words[i].ToUpper();
                words[i] = words[i] + "!!!!";
                words[i] = words[i].Replace("А", "@");
                foreach (var k in alfavit)
                {
                    words[i] = words[i].Replace(k, '*');
                }

            }
            for (int i = 0; i < 4; i++)
            {
                Console.Write(words[i]);
            }









            Console.ReadKey();
        }

    }
}
