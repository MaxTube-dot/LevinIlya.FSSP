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

                var taskProgress = fSSPClient.TaskProgress;

                if (taskProgress == TaskProgress.Ready)
                {

                    Console.WriteLine("Запрос выполнен!");

                    break;
                }
                else if(taskProgress == TaskProgress.Wait)
                {

                    Console.WriteLine("Запрос ожидает выполнения!");

                }
                else if (taskProgress == TaskProgress.ReadyWithError)
                {

                    Console.WriteLine("Запрос частично выполненен!");

                }


                Console.WriteLine("Чтобы повторить проверку готовности запроса введите 1, чтобы получить результат любую другую.");

                int.TryParse(Console.ReadLine(),out int key);

                if (key!=1)
                {
                    break;
                }

            }

            Console.WriteLine("Получение результата");

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
