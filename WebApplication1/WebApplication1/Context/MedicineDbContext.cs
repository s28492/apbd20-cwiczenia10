using Microsoft.EntityFrameworkCore;
using WebApplication1.Configs;
using WebApplication1.Entities;

namespace WebApplication1.Context;

public class MedicineDbContext : DbContext
{
    public virtual DbSet<Medicament> Medicaments { get; set; }
    public virtual DbSet<Doctor> Doctors { get; set; }
    public virtual DbSet<Patient> Patients { get; set; }
    public virtual DbSet<Prescription> Prescriptions { get; set; }
    public virtual DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    
    public  MedicineDbContext (){}          // pusty konstruktor, kij wie co robi

    public MedicineDbContext(DbContextOptions<MedicineDbContext> options) : base(options) // 
    {

    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MedicamentEfConfig).Assembly);
    }
    
}