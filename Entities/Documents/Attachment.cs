using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Documents
{
    [Table("attachments")]
    public class Attachment
    {
        [Key]
        public int? Id { get; set; }
        public int? DocumentId { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }

        [ForeignKey("DocumentId")]
        public virtual Document Document { get; set; }
    }
}
