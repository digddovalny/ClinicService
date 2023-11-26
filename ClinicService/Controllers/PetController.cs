using ClinicService.Models;
using ClinicService.Models.Requests;
using ClinicService.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private IPetRepository _petRepository;

        public PetController(IPetRepository petRepository) 
        {
            _petRepository = petRepository;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreatePetRequest createPetRequest) 
        {
            Pet pet = new Pet();
            pet.ClientId = createPetRequest.ClientId;
            pet.Name = createPetRequest.Name;
            pet.BirthDay = createPetRequest.BirthDay;

            return Ok(_petRepository.Create(pet));
        }

        [HttpPut("edit")]
        public IActionResult Update([FromBody] UpdatePetRequest updatePetRequest)
        {
            Pet pet = new Pet();
            pet.PetId = updatePetRequest.PetId;
            pet.ClientId = updatePetRequest.ClientId;
            pet.Name = updatePetRequest.Name;
            pet.BirthDay = updatePetRequest.BirthDay;

            return Ok(_petRepository.Update(pet));
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] int petid)
        {
            int res = _petRepository.Delete(petid);
            return Ok();
        }

        [HttpGet("get-all", Name = "PetGetAll")]
        public ActionResult<List<Pet>> GetAll()
        {
            return Ok(_petRepository.GetAll());
        }

        [HttpGet("get-pet/{petid}")]
        public IActionResult GetById([FromRoute] int petid)
        {
            return Ok(_petRepository.GetById(petid));
        }

        [HttpGet("get-pets/{clientid}")]
        public IActionResult GetAllClientPets([FromRoute] int clientid)
        {
            return Ok(_petRepository.GetAllClientPets(clientid));
        }

    }
}
