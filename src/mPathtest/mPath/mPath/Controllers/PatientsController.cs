using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using mPath.DBModels;
using mPath.Services;

namespace mPath.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class PatientsController : ControllerBase
  {
    private readonly PatientManagementDbContext _context;
    IAuditService _auditService;
    private ILogger<PatientsController> _logger;
    public PatientsController(PatientManagementDbContext context,
      IAuditService auditService, ILogger<PatientsController> logger)
    {
      _context = context;
      _auditService = auditService;
      _logger = logger;
    }

    // GET: api/Patients
    [HttpGet]
    public async Task<IActionResult> GetPatients()
    {
      var patients = await _context.Patients
                              .Include(p => p.Recommendations)
                              .ToListAsync();
      return Ok(patients);
    }

    // GET: api/Patients/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Patient>> GetPatient([FromRoute] int id)
    {
      var patient = await _context.Patients.FindAsync(id);

      if (patient == null)
      {
        _logger.LogInformation($"Patient Not Found {id}");

        return NotFound();
      }

      return patient;
    }

    // PUT: api/Patients/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPatient([FromRoute]int id, [FromBody]Patient patient)
    {
      if (id != patient.Id)
      {
        return BadRequest();
      }

      _context.Entry(patient).State = EntityState.Modified;

      try
      {
        foreach (var recommendation in patient.Recommendations)
        {
          _context.Recommendations.Update(recommendation);

        }

       await _context.SaveChangesAsync();

       await _auditService.LogAsync(patient.Id, "UpdatePatient",
         $"Update patient {patient.Id}-{patient.Name}");
       _logger.LogInformation($"Patient Updated {patient.Id}");

      }
      catch (DbUpdateConcurrencyException)
      {
        if (!PatientExists(id))
        {
          _logger.LogError("Patient not found");
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/Patients
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<IActionResult> PostPatient([FromBody] Patient patient)
    {
      var pateitns = await _context.Patients.ToListAsync();
      var patientFound = pateitns.Find(id=> id.DateOfBirth == patient.DateOfBirth && id.Name == patient.Name);
      if (patientFound != null)
      {
        return Ok("Patient already exists");
      }

      patient.Recommendations = _context.RecommendationTypes.Select(rt => new Recommendation
      {
        Type = rt.Type,
        Description = rt.Description,
        CreatedDate = DateTime.Now
      }).ToList();
      _context.Patients.Add(patient);
      await _context.SaveChangesAsync();
      await _auditService.LogAsync(patient.Id, "CreatePatient",
        $"Create patient {patient.Id}-{patient.Name}");
      _logger.LogInformation($"Patient Created {patient.Id}");

      return Ok(patient);
    }

    // DELETE: api/Patients/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePatient([FromRoute] int id)
    {
      var patient = await _context.Patients.FindAsync(id);
      if (patient == null)
      {
        return NotFound();
      }

      _context.Patients.Remove(patient);
      await _context.SaveChangesAsync();
      await _auditService.LogAsync(patient.Id, "DeletePatient",
        $"Delete patient {patient.Id}-{patient.Name}");
      _logger.LogInformation($"Patient Deleted {patient.Id}");

      return NoContent();
    }

    private bool PatientExists(int id)
    {
      return _context.Patients.Any(e => e.Id == id);
    }
  }
}
