using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
   public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please provide a first name.")]
        [Display(Name = "User Name")]

        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please provide a last name.")]
        [Display(Name = "User Name")]
        public string LastName { get; set; }
        public string Nationality { get; set; }
        [EmailAddress(ErrorMessage = "Your email address is invalid.")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; }
        public int Wins { get; set; }

        public User() 
        { 

        }

        public User(int id, string firstName, string password)
        {
                this.Id = id;
            this.FirstName = firstName;
            this.Password = password;
        }
    }
}
