using System;
using System.Collections.Generic;

namespace _4gaDailyWorkReview.Server.Models;

public partial class Board
{
    public long Id { get; set; }

    public long ProjectId { get; set; }

    public double Position { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsGithubConnected { get; set; }

    public string GithubRepo { get; set; } = null!;

    public bool? IsImportedBoard { get; set; }

    public long CreatedById { get; set; }

    public long? UpdatedById { get; set; }
}
