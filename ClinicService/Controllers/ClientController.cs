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

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateClientRequest request) 
        {
            Client client = new Client();
            client.Document = request.Document;
            client.SurName = request.SurName;
            client.FirstName = request.FirstName;
            client.Patronymic = request.Patronymic;
            client.BirthDay = request.BirthDay;

            return Ok(_clientRepository.Create(client));
        }

        [HttpPut("edit")]
        public IActionResult Update([FromBody] UpdateClientRequest request)
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

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] int clientid)
        {
            int res = _clientRepository.Delete(clientid);
            return Ok();
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            return Ok(_clientRepository.GetAll());
        }

        [HttpGet("get/{clientid}")]
        public IActionResult GetById([FromRoute] int clientid)
        {
            return Ok(_clientRepository.GetById(clientid));
        }
    }
}
