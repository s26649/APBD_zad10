using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PrescriptionService.Entities.Config;

public class PrescriptionConfig : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.HasKey(e => e.IdPrescription).HasName("Prescription_pk");
        builder.Property(e => e.IdPrescription).UseIdentityColumn();
        builder.Property(e => e.Date).IsRequired();
        builder.Property(e => e.DueDate).IsRequired();
        builder.HasOne(e => e.Patient).WithMany(p => p.Prescriptions).HasForeignKey(e => e.IdPatient);
        builder.HasOne(e => e.Doctor).WithMany(d => d.Prescriptions).HasForeignKey(e => e.IdDoctor);
        builder.ToTable("Prescription");
    }
}
