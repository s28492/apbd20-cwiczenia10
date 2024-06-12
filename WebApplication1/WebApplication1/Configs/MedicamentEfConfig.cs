using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Entities;

namespace WebApplication1.Configs;

public class MedicamentEfConfig : IEntityTypeConfiguration<Medicament>
{
    public void Configure(EntityTypeBuilder<Medicament> builder)
    {
        builder
            .HasKey(a => a.IdMedicament) // Wybieram dla jakiego atrybutu ustawiam PK
            .HasName("medicament_pk");                    // Ustalam nazwę dla PK

        builder
            .Property(a => a.IdMedicament) // Wybieram dla jakiego atrybutu wybrać ustawienia
            .ValueGeneratedNever(); // Aby klucz główny nie generował się automatycznie

        builder
            .Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(100);
        
        builder
            .Property(a => a.Description)
            .IsRequired()
            .HasMaxLength(100);
        
        builder
            .Property(a => a.Type)
            .IsRequired()
            .HasMaxLength(100);

        builder.ToTable(nameof(Medicament)); // Warunkuję istnienie tylko jednej tabeli w bazie danych
    }
}