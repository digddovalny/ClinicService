namespace ClinicService.Models
{
    public class Consultation
    {
        /// <summary>
        /// Индентификатор консультации
        /// </summary>
        public int ConsultationId { get; set; }

        /// <summary>
        /// Идентификатор клиента
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Идентификатор питомца
        /// </summary>
        public int PetId { get; set; }

        /// <summary>
        /// Дата консультации
        /// </summary>
        public DateTime ConsultationDate { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
    }
}
