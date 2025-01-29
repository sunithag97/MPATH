using System;
using System.Collections.Generic;

namespace mPath.DBModels;

public partial class AuditLog
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public string? Action { get; set; }

    public string? Details { get; set; }

    public DateTime? CreatedDate { get; set; }
}
