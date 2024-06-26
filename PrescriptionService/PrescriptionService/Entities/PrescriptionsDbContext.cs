using Microsoft.EntityFrameworkCore;
using PrescriptionService.Entities.Config;

namespace PrescriptionService.Entities;

public class PrescriptionsDbContext : DbContext
{
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }
    public PrescriptionsDbContext(DbContextOptions<PrescriptionsDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PrescriptionConfig).Assembly);
    }
}