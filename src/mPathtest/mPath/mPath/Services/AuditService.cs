using mPath.DBModels;

namespace mPath.Services;

public class AuditService : IAuditService
{
  private readonly PatientManagementDbContext _context;

  public AuditService(PatientManagementDbContext context)
  {
    _context = context;
  }

  public async Task LogAsync(int patientId, string action, string details)
  {
    var auditLog = new AuditLog
    {
      PatientId = patientId,
      Action = action,
      CreatedDate = DateTime.UtcNow,
      Details = details
    };

    _context.AuditLogs.Add(auditLog);
    await _context.SaveChangesAsync();
  }
}
