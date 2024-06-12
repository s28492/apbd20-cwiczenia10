using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Entities;

namespace WebApplication1.Configs;

public class PrescriptionEfConfig: IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder
            .HasKey(pm => pm.IdPrescription)
            .HasName("prescription_pk");

        builder
            .Property(pm => pm.IdPrescription)
            .ValueGeneratedNever();

        builder
            .Property(pm => pm.Date)
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()");
        
        builder
            .Property(pm => pm.DueDate)
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()");

        builder
            .HasOne(pm => pm.Patient)
            .WithMany(pm => pm.Prescriptions)
            .HasForeignKey(pm => pm.IdPatient)
            .HasConstraintName("patient_fk")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(pm => pm.Doctor)       //jeden
            .WithMany(pm => pm.Prescriptions) // do wielu
            .HasForeignKey(pm => pm.IdDoctor)               // atrybut odbiorczy
            .HasConstraintName("doctor_fk")
            .OnDelete(DeleteBehavior.Restrict);
        
        
        builder.ToTable(nameof(Prescription)); // Warunkuję istnienie tylko jednej tabeli w bazie danych



    }
}