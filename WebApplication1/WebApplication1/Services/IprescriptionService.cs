using WebApplication1.DTO;

namespace WebApplication1.Services;

public interface IprescriptionService
{
    public  Task<PrescriptionClientDTO> insertReceip(PrescriptionClientDTO PCDTO);
}