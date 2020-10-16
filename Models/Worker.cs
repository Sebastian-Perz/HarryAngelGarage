using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HarryAngelGarage.Models
{
    public class Worker
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [Display(Name = "Numer karty")]
        public int WorkerID { get; set; }
        [Display(Name = "Hala")]
        public int GarageID { get; set; }
        [Display(Name = "Imię")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Nazwisko")]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Data urodzenia")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime BirthYear { get; set; }
        [Display(Name = "Pensja miesięczna")]
        [Required]
        public decimal Salary { get; set; }

        public virtual Garage Garage { get; set; }


        [Display(Name = "Lakiernik:")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Helper> Helpers { get; set; }

    }
}