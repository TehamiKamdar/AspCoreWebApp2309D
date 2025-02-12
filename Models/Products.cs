using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspCoreWebApp2309D.Models
{
    public class Products
    {
        [Key]
        public int Product_Id { get; set; }
        [Required]
        public string Product_Name { get; set;}
        [Required]
        public string Product_Description { get; set;}
        
        public int Product_Price { get; set;}
        public string Slug { get; set;}

        public string? Product_Image { get; set;}

        public int Product_Category { get; set;}
        [ForeignKey("Product_Category")]
        public virtual Category category { get; set;}
    }
}
