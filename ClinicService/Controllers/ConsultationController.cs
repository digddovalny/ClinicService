using ClinicService.Models.Requests;
using ClinicService.Models;
using ClinicService.Services;
using ClinicService.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultationController : ControllerBase
    {
        private IConsultationRepository _consultationRepository;

        public ConsultationController(IConsultationRepository consultationRepository) 
        {
            _consultationRepository = consultationRepository;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateConsultationRequest createConsultationRequest)
        {
            Consultation consultation = new Consultation();
            consultation.ClientId = createConsultationRequest.ClientId;
            consultation.PetId = createConsultationRequest.PetId;
            consultation.ConsultationDate = createConsultationRequest.ConsultationDate;
            consultation.Description = createConsultationRequest.Description;

            return Ok(_consultationRepository.Create(consultation));
        }

        [HttpPut("edit")]
        public IActionResult Update([FromBody] UpdateConsultationRequest updateConsultationRequest)
        {
            Consultation consultation = new Consultation();
            consultation.ConsultationId = updateConsultationRequest.ConsultationId;
            consultation.ClientId = updateConsultationRequest.ClientId;
            consultation.PetId = updateConsultationRequest.PetId;
            consultation.ConsultationDate = updateConsultationRequest.ConsultationDate;
            consultation.Description = updateConsultationRequest.Description;

            return Ok(_consultationRepository.Update(consultation));
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] int consultationid)
        {
            int res = _consultationRepository.Delete(consultationid);
            return Ok();
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            return Ok(_consultationRepository.GetAll());
        }

        [HttpGet("get-pet/{consultationid}")]
        public IActionResult GetById([FromRoute] int consultationid)
        {
            return Ok(_consultationRepository.GetById(consultationid));
        }

        [HttpGet("get-pets/{clientid}")]
        public IActionResult GetAllClientPets([FromRoute] int clientid)
        {
            return Ok(_consultationRepository.GetAllClientConsultations(clientid));
        }
    }
}
