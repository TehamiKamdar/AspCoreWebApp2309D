using System.ComponentModel.DataAnnotations;

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

        public string? Product_Image { get; set;}
    }
}
