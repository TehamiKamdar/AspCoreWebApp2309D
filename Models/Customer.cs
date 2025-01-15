using System.ComponentModel.DataAnnotations;

namespace AspCoreWebApp2309D.Models
{
    public class Customer
    {
        [Key]
        public int Customer_Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name cannot be null")]
        public string Customer_Name { get; set; }

        [EmailAddress]
        public string Customer_Email { get; set; }

        [Phone]
        public string Customer_Phone { get; set; }

        [Required]
        [Range(8, 32, ErrorMessage ="Password must contain letter between 8 and 32")]
        [DataType(DataType.Password)]
        public string Customer_Password {  get; set; }

        
        [StringLength(50)]
        public string Customer_City { get; set; }
        
        
        
        [StringLength(200)]
        public string? Customer_Address { get; set; }
    }
}
