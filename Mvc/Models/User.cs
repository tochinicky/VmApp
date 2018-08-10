using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc.Models
{
    public class User
    {
       
        
        [Key]
        public int UserId { get; set; }
        public General general { get; set; }

        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Purpose { get; set; }
        public string Name_of_company { get; set; }
        public string Whom_to_see { get; set; }
        public string Company_name { get; set; }
        public string Name_of_event { get; set; }
        public string From_where { get; set; }
        public string To_whom { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Sign_in { get; set; }

      


    }
    public class General
    {
        [Key]
        public int GenId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string Purpose { get; set; }
        public string Name_of_company { get; set; }
        public string Whom_to_see { get; set; }
        public string Company_name { get; set; }
        public string Name_of_event { get; set; }
        public string From_where { get; set; }
        public string To_whom { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Sign_in { get; set; }
    }
  
   

}
