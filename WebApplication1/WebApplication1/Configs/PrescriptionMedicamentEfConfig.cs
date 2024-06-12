using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Entities;

namespace WebApplication1.Configs;

public class PrescriptionMedicamentEfConfig: IEntityTypeConfiguration<PrescriptionMedicament>
{

    public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
    {
        builder
            .HasKey(pm => new { pm.IdMedicament, pm.IdPrescription })
            .HasName("prescription_medicament_pk");

        builder
            .HasOne(pm => pm.Prescription)
            .WithMany(pm => pm.PrescriptionsMedicaments) // oznacza icollections w klasie Prescription
            .HasForeignKey(pm => pm.IdPrescription)
            .HasConstraintName("prescription_fk")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(pm => pm.Medicament)
            .WithMany(pm => pm.PrescriptionsMedicaments) // oznacza icollections w klasie Prescription
            .HasForeignKey(pm => pm.IdMedicament)
            .HasConstraintName("medicament_fk")
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Property(pm => pm.Dose)
            .IsRequired(false);

        builder
            .Property(pm => pm.Details)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.ToTable(nameof(PrescriptionMedicament)); // Warunkuję istnienie tylko jednej tabeli w bazie danych


    }
}