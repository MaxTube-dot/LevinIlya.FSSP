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


            fSSPClient.GetPhysical(region:"46",firstName: "Илья", lastName: "Левин", secondName: "Владимирович",birthDate: "01.11.1999");

            Console.WriteLine("Запрос отправлен!");

             

           int progress;

            while (true)
            {

                progress = fSSPClient.GetProgress();

                switch (progress)
                {
                    case 1:
                        Console.WriteLine("Запрос выполнен!");
                        break;
                    case 2:
                        Console.WriteLine("Запрос ожидает выполнения!");
                        break;
                    case 3:
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
                        Console.WriteLine($"Имя {user.name}");

                        Console.WriteLine($"Детали {user.details}");
                    }

                }


            }


          
        }
    }
}
