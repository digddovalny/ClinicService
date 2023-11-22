namespace ClinicService.Models
{
    public class Client
    {
        /// <summary>
        /// Индентификатор клиента
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Документ
        /// </summary>
        public string Document { get; set; }
        
        /// <summary>
        /// Фамилия клиента
        /// </summary>
        public string SurName { get; set; }

        /// <summary>
        /// Имя клиента
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Отчетсво клиента
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Дата рождения клиента
        /// </summary>
        public DateTime BirthDay { get; set; }
    }
}
