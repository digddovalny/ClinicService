﻿namespace ClinicService.Models.Requests
{
    public class CreatePetRequest
    {
        /// <summary>
        /// Идентификатор клиента
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Имя питомца
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата рождения питомца
        /// </summary>
        public DateTime BirthDay { get; set; }
    }
}
