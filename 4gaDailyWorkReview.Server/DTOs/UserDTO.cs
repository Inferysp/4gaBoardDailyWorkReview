using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _4gaDailyWorkReview.Server.DTOs
{
    public class UserDTO
    {
        [Key]
        [Column("id")]
        public string Id { get; set; }

        public string? Name { get; set; }
    }
}
