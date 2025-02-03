using System.ComponentModel.DataAnnotations;

namespace Abby.Models
{
    public class FoodType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Type Name")]
        public string Name { get; set; }
       
    }
}
