using PrescriptionService.Entities;
using PrescriptionService.RequestModels;

namespace PrescriptionService.Services;

public interface IPrescriptionService
{
    bool AddPrescription(PrescriptionRequest request);
    Patient GetPatientDetails(int idPatient);
}