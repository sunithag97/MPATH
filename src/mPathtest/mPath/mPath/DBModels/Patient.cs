using System;
using System.Collections.Generic;

namespace mPath.DBModels;

public partial class Patient
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public virtual List<Recommendation> Recommendations { get; set; } = new List<Recommendation>();
}
