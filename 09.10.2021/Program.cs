using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
namespace _09._10._2021
{
    class Program
    {
        public class Worker
        {
            public static bool IsStupid(Worker worker)
            {
                return worker._isStupid;
            }
            public static ushort GetDegree(Worker worker)
            {
                return worker._degreeImpudence;
            }
            public Worker(string name, string direction, ushort degreeImpudence, bool isStupid)
            {
                _name = name;
                _direction = direction;
                _degreeImpudence = degreeImpudence;
                _isStupid = isStupid;
            }
            private string _name;
            private string _direction;
            private ushort _degreeImpudence;
            private bool _isStupid;
        }
        
        static string CountFives (int[] FiveOne, int[] FiveTwo)
        {
            int countOne = 0, countTwo = 0;
            for (int i = 0; i < FiveTwo.Length; i++)
            {
                FiveOne[i] = Convert.ToInt32(Console.ReadLine());
                if (FiveOne[i] == 5)
                {
                    countOne++;
                }
            }

            for (int i = 0; i < FiveOne.Length; i++)
            {
                FiveTwo[i] = Convert.ToInt32(Console.ReadLine());
                if (FiveTwo[i] == 5)
                {
                    countTwo++;
                }
            }

            if (countOne == countTwo)
            {
                return "Drinks All Round! Free Beers on Bjorg!";
            }
            else
            {

                return "Ой, Бьорг - пончик! Ни для кого пива!";

            }





        }


        static void Main(string[] args)
        {

            Console.WriteLine("Задание 1");
            Console.WriteLine("\nБухаловка");
            int [] FiveOne = new int [10];
            int[] FiveTwo = new int[10];
            Console.WriteLine(CountFives(FiveOne,FiveTwo));





            Console.WriteLine("\nЗадание 3");
            var People = new Dictionary<string, (int, int)>
            {
                ["Tixonov Alex"] = ( 2004, 250),
                ["Zinnatullina Regina"] = ( 2003, 260),
                ["Senkyм Lila"] = (2003, 267),
                ["Ivanoм Ivan"] = ( 2002, 257),
                ["Kipikov Pavel"] = ( 2004, 269),
                ["Trockiy Dima"] = ( 2002, 270),
                ["Remil Anila"] = ( 2003, 240),
                ["Artix Fox"] = ( 2003, 250),
                ["Atim Alia"] = ( 2003, 240)
            };
            
            bool contin = true;
            string vvod;

            while (contin) {
                vvod = Console.ReadLine();

         
                if (vvod == "Новый студент")
                {
                    Console.WriteLine("\nВведите фамилию и имя");
                    string sn = Console.ReadLine();
                    Console.WriteLine("\nВведите год рождения");
                    int y = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\nВведите кол-во баллов");
                    int points = Convert.ToInt32(Console.ReadLine());
                    People.Add(sn, (y,points));
                    Console.WriteLine(People);
                }
                if (vvod == "Удалить")
                {

                    string Sn = Console.ReadLine();
                    People.Remove(Sn);

                    Console.WriteLine(People);

                }

                if (vvod == "Сортировать")
                {

                    People = People.OrderBy(x => x.Value.Item2).ToDictionary(x => x.Key,x => x.Value) ;

                    Console.WriteLine(People);
                }
                if (vvod == "Закрыть") {

                    contin = false;
                }


            }



            Console.WriteLine("4");
            Console.WriteLine("Сколько работников?");
            int countWorkers;
            while (!int.TryParse(Console.ReadLine(), out countWorkers) || countWorkers < 0)
            {
                Console.Write("Неверный ввод,повторите! ");
            }
            int countTables = countWorkers / 2;
            int capacityTables = 4;
            Console.Clear();
            var listWorkers = new List<Worker>();
            for (int i = 0; i < countWorkers; i++)
            {
                Console.Write("Введите имя работника - ");
                string name = Console.ReadLine();
                Console.Write("Где он работает? - ");
                string direction = Console.ReadLine();
                Console.Write("Введите его степень наглости(только целое значение) - ");
                ushort degreeImpudence;
                while (!ushort.TryParse(Console.ReadLine(), out degreeImpudence) || degreeImpudence < 0)
                {
                    Console.WriteLine("Неверный ввод!");
                }
                bool isStupid;
                Console.WriteLine("Введите тупой ли он? да / нет");
                if (Console.ReadLine().ToLower().Equals("да"))
                {
                    isStupid = true;
                }
                else
                {
                    isStupid = false;
                }
                listWorkers.Add(new Worker(name, direction, degreeImpudence, isStupid));
            }

            
            for (int i = 0; i < listWorkers.Count; i++)
            {
                for (int j = 0; j < listWorkers.Count - 1; j++)
                {
                    if (Worker.GetDegree(listWorkers[j]) > Worker.GetDegree(listWorkers[j + 1]) && Worker.IsStupid(listWorkers[j]))
                    {
                        var temp = listWorkers[j + Worker.GetDegree(listWorkers[j])];
                        listWorkers[j + Worker.GetDegree(listWorkers[j])] = listWorkers[j];
                        listWorkers[j] = temp;
                    }
                }

            }
            var queue = new Queue<Worker>();
            for (int i = 0; i < listWorkers.Count; i++)
            {
                queue.Enqueue(listWorkers[i]);
            }
            var listTables = new List<Stack<Worker>>();
            for (int i = 0; i < countTables; i++)
            {
                listTables.Add(new Stack<Worker>());
                for (int j = 0; j < capacityTables; j++)
                {
                    listTables[i].Push(queue.Peek());
                }
            }






            Console.ReadKey();
        }
    }
}
