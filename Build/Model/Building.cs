using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Build.Model
{
    public class Building
    {
        [Key]
        public int Id { get; set; }
        [CustomNameValid]
        public string Street { get; set; }
        [CustomNumberValid]
        public int Number { get; set; }
        [CustomNumberValid]
        public double Square{ get; set; }
        [CustomNumberValid]
        public int Price { get; set; }
        [CustomYearValid]
        public int  Year{ get; set; }
    }
}
