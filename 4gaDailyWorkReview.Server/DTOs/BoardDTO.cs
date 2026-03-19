using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace _4gaDailyWorkReview.Server.DTOs
{
    [Table("board")]
    public class BoardDTO
    {
        [Key]

        public string Id { get; set; }

        public string ProjectId { get; set; }

        public string Name { get; set; } = null!;

        public string GithubRepo { get; set; } = null!;

    }
}
