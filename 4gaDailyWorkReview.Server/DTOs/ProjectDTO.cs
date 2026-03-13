using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _4gaDailyWorkReview.Server.DTOs
{
    public class ProjectDTO
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public string? Background { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string? BackgroundImage { get; set; }

        public long CreatedById { get; set; }

        public long? UpdatedById { get; set; }
    }
}