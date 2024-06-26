using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PrescriptionService.Entities.Config;

public class Prescription_MedicamentConfig : IEntityTypeConfiguration<Prescription_Medicament>
{
    public void Configure(EntityTypeBuilder<Prescription_Medicament> builder)
    {
        builder.HasKey(e => new { e.IdMedicament, e.IdPrescription });
        builder.Property(e => e.Details).IsRequired().HasMaxLength(100);
        builder.HasOne(e => e.Medicament).WithMany(m => m.Prescription_Medicaments).HasForeignKey(e => e.IdMedicament);
        builder.HasOne(e => e.Prescription).WithMany(p => p.Prescription_Medicaments).HasForeignKey(e => e.IdPrescription);
        builder.ToTable("Prescription_Medicament");
    }
}
