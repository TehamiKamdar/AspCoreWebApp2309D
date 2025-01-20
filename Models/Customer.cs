using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string? Customer_Phone { get; set; }

        
        [StringLength(50)]
        public string? Customer_City { get; set; }
        
        
        [StringLength(200)]
        public string? Customer_Address { get; set; }

        public int User_Id { get; set; }
        [ForeignKey("User_Id")]
        public virtual Users users { get; set; }
    }
}
