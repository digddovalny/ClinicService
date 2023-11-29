using ClinicService.Models;
using ClinicService.Models.Requests;
using ClinicService.Services;
using ClinicService.Services.Impl;
using Microsoft.AspNetCore.Mvc;

namespace ClinicService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository) 
        {
            _clientRepository = clientRepository;
        }

        [HttpPost("create", Name = "AddClient")]
        public ActionResult<int> Create([FromBody] CreateClientRequest request) 
        {
            if (string.IsNullOrEmpty(request.SurName))
                return Ok(new
                {
                    ErrCode = -10,
                    ErrMessage = "Фамилия указана некорректно."
                });

            if (string.IsNullOrEmpty(request.FirstName))
                return Ok(new
                {
                    ErrCode = -11,
                    ErrMessage = "Имя указано некорректно."
                });

            if (string.IsNullOrEmpty(request.Patronymic))
                return Ok(new
                {
                    ErrCode = -12,
                    ErrMessage = "Отчество указана некорректно."
                });

            if (request.BirthDay < DateTime.Now.AddYears(-100))
                return Ok(new
                {
                    ErrCode = -13,
                    ErrMessage = "Дата рождения указана некорректно."
                });

            if (string.IsNullOrEmpty(request.Document))
                return Ok(new
                {
                    ErrCode = -14,
                    ErrMessage = "Документ указан некорректно."
                });

            Client client = new Client();
            client.Document = request.Document;
            client.SurName = request.SurName;
            client.FirstName = request.FirstName;
            client.Patronymic = request.Patronymic;
            client.BirthDay = request.BirthDay;

            return Ok(_clientRepository.Create(client));
        }

        [HttpPut("edit", Name = "EditClient")]
        public ActionResult<int> Update([FromBody] UpdateClientRequest request)
        {
            Client client = new Client();
            client.ClientId = request.ClientId;
            client.Document = request.Document;
            client.SurName = request.SurName;
            client.FirstName = request.FirstName;
            client.Patronymic = request.Patronymic;
            client.BirthDay = request.BirthDay;

            return Ok(_clientRepository.Update(client));
        }

        [HttpDelete("delete", Name = "ClientDelete")]
        public ActionResult<int> Delete([FromQuery] int clientid)
        {
            //int res = _clientRepository.Delete(clientid);
            return Ok(_clientRepository.Delete(clientid));
        }

        [HttpGet("get-all", Name = "ClientGetAll")]
        public ActionResult<List<Client>> GetAll()
        {
            return Ok(_clientRepository.GetAll());
        }

        [HttpGet("get/{clientid}", Name = "GetClientbyId")]
        public ActionResult<Client> GetById([FromRoute] int clientid)
        {
            return Ok(_clientRepository.GetById(clientid));
        }
    }
}
