using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Build.Model
{
    public class Building_User
    {
        [Key]
        public int Building_id { set; get; }
        public int User_id { set; get; }
    }
}
