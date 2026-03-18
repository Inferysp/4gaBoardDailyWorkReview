using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _4gaDailyWorkReview.Server.DTOs
{
    [Table("board")]
    public class BoardDTO
    {
        [Key]

        public long Id { get; set; }

        public long ProjectId { get; set; }

        public string Name { get; set; } = null!;

        public string GithubRepo { get; set; } = null!;

    }
}
