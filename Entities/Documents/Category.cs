using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Documents
{
    [Table("categories")]
    public class Category
    {
        [Key]
        public int? Id { get; set; }
        public int? ParentCategoryId { get; set; }
        public string Name { get; set; }
        public int? Order { get; set; }
        public bool IsPublic { get; set; }

        [ForeignKey("ParentCategoryId")]
        public virtual Category ParentCategory { get; set; }
    }
}
