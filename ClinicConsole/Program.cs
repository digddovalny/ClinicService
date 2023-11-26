using ClinicServiceNamespace;

namespace ClinicConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Нажмите любую клавишу для загрузки данных...");
            Console.ReadKey();

            ClinicClient clinicClient = new ClinicClient("http://localhost:5240/", new HttpClient());

            List<Client> clients = clinicClient.ClientGetAllAsync().Result.ToList();

            foreach (Client client in clients) 
            {
                Console.WriteLine("Фамилия: " + client.SurName);
                Console.WriteLine("Имя: " + client.FirstName);
                Console.WriteLine("Отчество: " + client.Patronymic);
                Console.WriteLine("Дата рождения: " + client.BirthDay.DateTime);
                Console.WriteLine("Документ: " + client.Document);

                Console.WriteLine();
            }

            Console.WriteLine("Нажмите любую клавишу для завершения рпботы приложения...");
            Console.ReadKey();
        }
    }
}