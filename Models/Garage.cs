using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HarryAngelGarage.Models
{
    public enum GarageName { A, B, C, D }
    public class Garage
    {
        [Display(Name = "Hala")]
        public int GarageID { get; set; }
        public GarageName GarageName { get; set; }
        public int Space { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}