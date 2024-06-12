using WebApplication1.Entities;

namespace WebApplication1.DTO;

public class PrescriptionClientDTO
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }

    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    
    public int IdDoctor { get; set; }
    public string FirstDoctorName { get; set; }
    public string LastDoctorName { get; set; }
    public string Email { get; set; }
    public List<Medicament> Medicaments { get; set; }
    
}