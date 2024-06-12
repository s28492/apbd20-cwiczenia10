using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Entities;

namespace WebApplication1.Configs;

public class PatientEfConfig : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder
            .HasKey(p => p.IdPatient)
            .HasName("patient_pk");
        
        builder
            .Property(a => a.IdPatient) // Wybieram dla jakiego atrybutu wybrać ustawienia
            .ValueGeneratedNever(); // Aby klucz główny nie generował się automatycznie
        
        builder
            .Property(a => a.FirstName)
            .IsRequired()
            .HasMaxLength(100);
        
        builder
            .Property(a => a.LastName)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(a => a.Birthdate)
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()"); //Zwraca datę w odpowiedniej strefie czasowej
        
        builder.ToTable(nameof(Patient)); // Warunkuję istnienie tylko jednej tabeli w bazie danych
    }
}