using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FSSP
{
   public enum TaskProgress
    {
        Ready,
        Wait,
        ReadyWithError
    }

    public class FSSPClient
    {

        private string Token { get; }

        private string TaskNumber { get; set; }

        /// <summary>
        /// Получить прогресс задачи.
        /// </summary>
        public TaskProgress  TaskProgress { get { return GetInfoProgress(); } }



        public FSSPClient(string token)
        {
            Token = token;
        }

        /// <summary>
        /// Получение данных о физ. лице.
        /// </summary>
        /// <param name="region">Регион</param>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="birthDate">Дата рождения.</param>
        /// <param name="secondName">Отчество.</param>
        /// <returns>Данные о долгах.</returns>
        public void SearchPhysicalPeople(string region, string firstName, string lastName, string birthDate, string secondName = null)
        {
            GetTask(region, firstName, lastName, secondName, birthDate);
        }


        /// <summary>
        /// Получение результата.
        /// </summary>
        /// <param name="task">Номер задачи.</param>
        /// <returns>Результат запроса.</returns>
        public ResponseRezult GetResult()
        {
            using (var webClient = new WebClient())
            {
                string url = "https://api-ip.fssp.gov.ru/api/v1.0/result";

                webClient.QueryString.Add("token", Token);

                webClient.QueryString.Add("task", TaskNumber);

                // Выполняем запрос по адресу и получаем ответ в виде строки
                var response = webClient.DownloadString(url);

                var answer = JsonSerializer.Deserialize<ResponseRezult>(response);

                return answer;

            }
        }

        /// <summary>
        /// Получение сведений о прогрессе.
        /// </summary>
        /// <param name="task">Номер задачи. </param>
        private TaskProgress GetInfoProgress()
        {

            using (var webClient = new WebClient())
            {

                string url = "https://api-ip.fssp.gov.ru/api/v1.0/status";

                webClient.QueryString.Add("token", Token);

                webClient.QueryString.Add("task", TaskNumber);

                int i = 10;


                var response = webClient.DownloadString(url);

                var answer = JsonSerializer.Deserialize<ResponseProgress>(response);

                return  (TaskProgress) answer.Response.Status;

            }
        }


        /// <summary>
        /// Получение кода запроса.
        /// </summary>
        /// <param name="region">Регион.</param>
        /// <param name="firstName">Имя.</param>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="secondName">Отчество.</param>
        /// <param name="birthDate">Дата рождения.</param>
        /// <returns>Код запроса.</returns>
        private void GetTask(string region, string firstName, string lastName, string secondName, string birthDate)
        {
            var webClient = new WebClient();

            string url = "https://api-ip.fssp.gov.ru/api/v1.0/search/physical";

            webClient.QueryString.Add("token", Token);

            webClient.QueryString.Add("region", region);

            webClient.QueryString.Add("firstname", firstName);

            webClient.QueryString.Add("lastname", lastName);

            if (secondName != null)
            {
                webClient.QueryString.Add("secondname", secondName);
            }

            webClient.QueryString.Add("birthdate ", birthDate);


            var response = webClient.DownloadString(url);


            var answer = JsonSerializer.Deserialize<ResponseTask>(response);

            TaskNumber = answer.Response.Task;
        }

    }




}
