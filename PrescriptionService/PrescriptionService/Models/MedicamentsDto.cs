namespace PrescriptionService.Models;

public class MedicamentsDto
{
    public int IdMedicament { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public int Dose { get; set; }
    public string Details { get; set; } = string.Empty;
}