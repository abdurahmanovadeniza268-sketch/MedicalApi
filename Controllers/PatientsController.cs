using Microsoft.AspNetCore.Mvc;
using MedicalApi.Models;

namespace MedicalApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private static List<Patient> patients = new List<Patient>();

    [HttpGet]
    public ActionResult<List<Patient>> GetAll()
    {
        return Ok(patients);
    }

    [HttpPost]
    public ActionResult<Patient> Create(Patient patient)
    {
        patient.Id = patients.Count + 1;
        patients.Add(patient);
        return CreatedAtAction(nameof(GetById),
            new { id = patient.Id }, patient);
    }

    [HttpGet("{id}")]
    public ActionResult<Patient> GetById(int id)
    {
        var patient = patients.FirstOrDefault(p => p.Id == id);

        if (patient == null)
            return NotFound();

        return Ok(patient);
    }
}
