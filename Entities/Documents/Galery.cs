using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Documents
{
    [Table("galeries")]
    public class Galery
    {
        [Key]
        public int? Id { get; set; }
        public int? DocumentId { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public int? Order { get; set; }

        [ForeignKey("DocumentId")]
        public virtual Document Document { get; set; }
    }
}
