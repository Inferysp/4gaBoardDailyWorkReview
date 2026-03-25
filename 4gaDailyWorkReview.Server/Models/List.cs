namespace _4gaDailyWorkReview.Server.Models;

public partial class List
{
    public long Id { get; set; }

    public long BoardId { get; set; }

    public double Position { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsCollapsed { get; set; }

    public long CreatedById { get; set; }

    public long? UpdatedById { get; set; }
}
