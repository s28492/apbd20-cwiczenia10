using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionController: ControllerBase
{
    private readonly IprescriptionService _prescriptionService;

    public PrescriptionController(IprescriptionService prescriptionService)
    {
        _prescriptionService = prescriptionService;
    }

    [HttpPost]
    public async Task<IActionResult> insertReceip(PrescriptionClientDTO PCDTO)
    {
        Console.WriteLine("PCDTO.Patient");
        if (PCDTO.DueDate < PCDTO.Date)
        {
            return BadRequest(" YOU HAVE ENTERED WRONG DATES");
        }

        if (PCDTO.Medicaments.Count > 10)
        {
            return BadRequest("Smafadgdg");
        }

        await _prescriptionService.insertReceip(PCDTO);
        return Ok();
    }
    
}