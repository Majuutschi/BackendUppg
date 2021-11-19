using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BE2AspNetMvc.Models
{
    public class User
    {


        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Firstname must be at least {2} characters long", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Lastname must be at least {2} characters long", MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Enter a valid Email address")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Enter a valid Password")]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string PhoneNumber { get; set; }


        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string AddressLine { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string Zipcode { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string City { get; set; }




        public virtual ICollection<Order> Orders { get; set; }
    }
}
