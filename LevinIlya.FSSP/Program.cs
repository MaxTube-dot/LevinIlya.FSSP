using System;
using System.Linq;
using FSSP;

namespace LevinIlya.FSSP
{
    class Program
    {
        static void Main(string[] args)
        {
            string token = "1F17XtiPnvPj";

            FSSPClient fSSPClient = new FSSPClient(token);


            fSSPClient.SearchPhysicalPeople(region:"46",firstName: "Илья", lastName: "Левин", secondName: "Владимирович",birthDate: "01.11.1999");

            Console.WriteLine("Запрос отправлен!");


            while (true)
            {

                var taskPr = fSSPClient.TaskProgress;

                switch (taskPr)
                {
                    case TaskProgress.Ready:
                        Console.WriteLine("Запрос выполнен!");
                        break;
                    case TaskProgress.Wait:
                        Console.WriteLine("Запрос ожидает выполнения!");
                        break;
                    case TaskProgress.ReadyWithError:
                        Console.WriteLine("Запрос частично выполненен!");
                        break;

                }

                Console.WriteLine("Чтобы повторить проверку готовности запроса нажмите 1.");

                int key = int.Parse(Console.ReadLine());

                if (key!=1)
                {
                    break;
                }

            }

            var response = fSSPClient.GetResult();

            foreach (var infoRezult in response.response.result)
            {
                if (infoRezult.result == null)
                {
                    Console.WriteLine("Данных не найдено!");
                    break;
                }
                foreach (var user in infoRezult.result)
                {
                    if (user == null )
                    {
                        Console.WriteLine($"Имя {user.Name}");

                        Console.WriteLine($"Детали {user.Details}");
                    }

                }


            }


          
        }
    }
}
