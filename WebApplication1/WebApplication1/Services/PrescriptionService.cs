using WebApplication1.Context;
using WebApplication1.DTO;
using WebApplication1.Repositories;

namespace WebApplication1.Services;

public class PrescriptionService : IprescriptionService
{
    private readonly IPrescriptionRepository _medicineRepository;

    public PrescriptionService(IPrescriptionRepository medicineRepository)
    {
        _medicineRepository = medicineRepository;
    }

    public async Task<PrescriptionClientDTO> insertReceip(PrescriptionClientDTO PCDTO)
    {
        return await _medicineRepository.insertReceip(PCDTO);
    }
}