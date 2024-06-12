using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Entities;

namespace WebApplication1.Configs;

public class DoctorEfConfig : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder
            .HasKey(a => a.IdDoctor) // Wybieram dla jakiego atrybutu ustawiam PK
            .HasName("doctor_pk");                    // Ustalam nazwę dla PK

        builder
            .Property(a => a.IdDoctor) // Wybieram dla jakiego atrybutu wybrać ustawienia
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
            .Property(a => a.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.ToTable(nameof(Doctor)); // Warunkuję istnienie tylko jednej tabeli w bazie danych
    }
}