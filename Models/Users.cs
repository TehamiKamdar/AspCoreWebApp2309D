using System.ComponentModel.DataAnnotations;

namespace AspCoreWebApp2309D.Models
{
    public class Users
    {
        [Key]
        public int User_Id { get; set; }
        public string User_Name { get; set;}
        [EmailAddress]
        public string User_Email { get; set;}
        [DataType(DataType.Password)]
        public string User_Password { get; set;}
        public string User_Role { get; set;}
    }
}
