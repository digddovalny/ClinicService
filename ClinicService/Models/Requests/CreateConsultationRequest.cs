namespace ClinicService.Models.Requests
{
    public class CreateConsultationRequest
    {
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
