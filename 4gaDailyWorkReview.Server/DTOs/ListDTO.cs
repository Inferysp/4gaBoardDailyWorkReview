using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _4gaDailyWorkReview.Server.DTOs
{
    public class ListDTO
    {
        [Key]
        [Column("id")]
        public  string Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
    }
}
