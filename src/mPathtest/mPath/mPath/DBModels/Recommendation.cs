using System;
using System.Collections.Generic;

namespace mPath.DBModels;

public partial class Recommendation
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public string? Type { get; set; }

    public string? Description { get; set; }

    public bool? Completed { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual Patient? Patient { get; set; }
}
