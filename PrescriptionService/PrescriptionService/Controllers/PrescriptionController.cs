using Microsoft.AspNetCore.Mvc;
using PrescriptionService.RequestModels;
using PrescriptionService.Services;

namespace PrescriptionService.Controllers;

[ApiController]
[Route("api/prescription")]
public class PrescriptionController : ControllerBase
{
    private readonly IPrescriptionService _service;

    public PrescriptionController(IPrescriptionService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult AddPrescription(PrescriptionRequest request)
    {
        if (!_service.AddPrescription(request))
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpGet("{idPatient}")]
    public IActionResult GetPatientDetails(int idPatient)
    {
        var patient = _service.GetPatientDetails(idPatient);
        if (patient == null)
        {
            return NotFound();
        }
        return Ok(patient);
    }
}
