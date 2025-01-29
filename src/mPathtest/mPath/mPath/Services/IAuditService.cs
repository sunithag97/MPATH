namespace mPath.Services;

public interface IAuditService
{
  Task LogAsync(int patientId, string action, string details);
}
