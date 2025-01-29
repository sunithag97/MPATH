using System;
using System.Collections.Generic;

namespace mPath.DBModels;

public partial class RecommendationType
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedDate { get; set; }
}
