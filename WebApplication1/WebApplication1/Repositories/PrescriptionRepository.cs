using Microsoft.AspNetCore.Http.HttpResults;
using WebApplication1.Context;
using WebApplication1.DTO;
using WebApplication1.Entities;

namespace WebApplication1.Repositories;

public class PrescriptionRepository : IPrescriptionRepository
{
    private readonly MedicineDbContext _medicineDbContext;

    public PrescriptionRepository(MedicineDbContext medicineDbContext)
    {
        _medicineDbContext = medicineDbContext;
    }

    public async Task<PrescriptionClientDTO> insertReceip(PrescriptionClientDTO PCDTO)
    {
        var patienTask = await _medicineDbContext.Patients.FindAsync(PCDTO.IdPatient);
        
        Console.WriteLine(PCDTO.FirstName);
        
        if (patienTask == null)
        {
            var patient = new Patient
            {
                IdPatient = PCDTO.IdPatient,
                FirstName = PCDTO.FirstName,
                LastName = PCDTO.LastName,
                Birthdate = PCDTO.Birthdate
            };
            Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            
            await _medicineDbContext.Patients.AddAsync(patient);
            await _medicineDbContext.SaveChangesAsync();
        }

        bool isMedIn = false;
        foreach (var medicament in PCDTO.Medicaments)
        {
            var medicineTask = await _medicineDbContext.Medicaments.FindAsync(medicament.IdMedicament);
            if (medicament == null)
            {
                return null;
            }
        }

        var add = new Prescription
        {
            IdPrescription = PCDTO.IdPrescription,
            Date = PCDTO.Date,
            DueDate = PCDTO.DueDate,
            IdPatient = PCDTO.IdPatient,
            IdDoctor = PCDTO.IdDoctor
        };
        await _medicineDbContext.Prescriptions.AddAsync(add);
        await _medicineDbContext.SaveChangesAsync();
        
        return null;

    }
}