using System.ComponentModel.DataAnnotations;

namespace GenericTypeTest.Models
{
    public class Product
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
        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
