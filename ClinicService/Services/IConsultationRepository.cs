using ClinicService.Models;

namespace ClinicService.Services
{
    public interface IConsultationRepository : IRepository<Consultation, int>
    {
        IList<Consultation> GetAllClientConsultations(int id);
    }
}
