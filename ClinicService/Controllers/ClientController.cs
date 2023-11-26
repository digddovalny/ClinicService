using ClinicService.Models;
using ClinicService.Models.Requests;
using ClinicService.Services;
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
            int res = _clientRepository.Delete(clientid);
            return Ok();
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
