namespace PrescriptionService.Models;

public class NewPrescriptionDto
{
    public PatientDto Patient { get; set; } = new();
    public List<MedicamentsDto> Medicaments { get; set; } = new();
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
}