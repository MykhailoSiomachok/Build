using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Build.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [CustomNameValid]
        public string First_name { get; set; }

        [CustomSurnameValid]
        public string Last_name { get; set; }
        [CustomEmailValid]
        public string Email { get; set; }
        [CustomPasswordValid]
        public string Password { get; set; }
        [CustomRoleValid]
        public string Role { get; set; }
    }
}
