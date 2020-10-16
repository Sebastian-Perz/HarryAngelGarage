using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HarryAngelGarage.Models
{
    public class Client
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
        [Display(Name = "Imię")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Miasto")]
        public string City { get; set; }
        [Required]
        [Display(Name = "Numer komórkowy")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Klient:")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }


        public virtual ICollection<Car> Cars { get; set; }
    }
}