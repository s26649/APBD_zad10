using Microsoft.EntityFrameworkCore;
using PrescriptionService.Entities;
using PrescriptionService.RequestModels;

namespace PrescriptionService.Services;

public class PrescriptionService : IPrescriptionService
{
    private readonly PrescriptionsDbContext _dbContext;

    public PrescriptionService(PrescriptionsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool AddPrescription(PrescriptionRequest request)
    {
        using var transaction = _dbContext.Database.BeginTransaction();
        try
        {
            var patient = _dbContext.Patients.FirstOrDefault(p => p.IdPatient == request.Patient.IdPatient);
            if (patient == null)
            {
                patient = new Patient
                {
                    FirstName = request.Patient.FirstName,
                    LastName = request.Patient.LastName,
                    Birthdate = request.Patient.Birthdate
                };
                _dbContext.Patients.Add(patient);
                _dbContext.SaveChanges();
            }

            if (request.Medicaments.Count>10 || request.DueDate<request.Date)
            {
                return false;
            }

            var medicamentIds = request.Medicaments.Select(m => m.IdMedicament).ToArray();
            var medicaments = _dbContext.Medicaments.Where(m => medicamentIds.Contains(m.IdMedicament)).ToList();
            if (medicaments.Count != medicamentIds.Length)
            {
                return false;
            }
            var prescription = new Prescription
            {
                Date = request.Date,
                DueDate = request.DueDate,
                IdPatient = patient.IdPatient,
                IdDoctor = 1
            };

            _dbContext.Prescriptions.Add(prescription);
            _dbContext.SaveChanges();

            foreach (var medicamentRequest in request.Medicaments)
            {
                var prescriptionMedicament = new Prescription_Medicament
                {
                    IdMedicament = medicamentRequest.IdMedicament,
                    IdPrescription = prescription.IdPrescription,
                    Dose = medicamentRequest.Dose,
                    Details = medicamentRequest.Details
                };
                _dbContext.Prescription_Medicaments.Add(prescriptionMedicament);
            }

            _dbContext.SaveChanges();
            transaction.Commit();
            return true;
        }
        catch (Exception)
        {
            transaction.Rollback();
            return false;
        }
    }

    public Patient GetPatientDetails(int idPatient)
    {
        return _dbContext.Patients
            .Include(p => p.Prescriptions)
            .ThenInclude(p => p.Prescription_Medicaments)
            .ThenInclude(pm => pm.Medicament)
            .Include(p => p.Prescriptions)
            .ThenInclude(p => p.Doctor)
            .FirstOrDefault(p => p.IdPatient == idPatient);
    }
}