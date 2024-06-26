namespace PrescriptionService.Models;

public class PatientDto
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime Birthdate { get; set; }
    public List<PrescriptionDto> Prescriptions { get; set; } = new();
}