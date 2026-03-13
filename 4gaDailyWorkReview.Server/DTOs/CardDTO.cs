using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _4gaDailyWorkReview.Server.DTOs
{
    [Table("card")]
    public partial class CardDTO
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("board_id")]
        public long BoardId { get; set; }
        [Column("list_id")]
        public long ListId { get; set; }
        [Column("created_by_id")]
        public long CreatedById { get; set; }
        [Column("cover_attachment_id")]
        public long? CoverAttachmentId { get; set; }
        [Column("position")]
        public double? Position { get; set; }
        [Column("name")]
        public string Name { get; set; } = null!;
        [Column("description")]
        public string? Description { get; set; }
        [Column("due_date")]
        public DateTime? DueDate { get; set; }
        [Column("timer", TypeName = "jsonb")] // Mapowanie specyficznego typu Postgresa
        public string? Timer { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        [Column("comment_count")]
        public int CommentCount { get; set; }
        [Column("updated_by_id")]
        public long? UpdatedById { get; set; }
    }
}
