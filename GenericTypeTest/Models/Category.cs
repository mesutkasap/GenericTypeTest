using System.ComponentModel.DataAnnotations;

namespace GenericTypeTest.Models
{
    public class Category
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }

    }
}
