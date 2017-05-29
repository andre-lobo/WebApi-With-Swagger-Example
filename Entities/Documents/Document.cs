using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Users;
using System.Collections.Generic;

namespace Entities.Documents
{
    [Table("documents")]
    public class Document
    {
        [Key]
        public int? Id { get; set; }

        public int? CategoryId { get; set; }

        public int? UserId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public bool IsPublic { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey("CategoryId")]
        [NotMapped]
        public virtual Category Category { get; set; }

        [ForeignKey("UserId")]
        [NotMapped]
        public virtual User User { get; set; }

        public virtual ICollection<Galery> Galeries { get; set; }

        public virtual ICollection<Attachment> Attachments { get; set; }
    }
}

