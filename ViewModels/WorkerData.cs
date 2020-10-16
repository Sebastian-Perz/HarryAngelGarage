using HarryAngelGarage.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HarryAngelGarage.ViewModels
{
    public class WorkerData
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
        public IEnumerable<Worker> Workers { get; set; }
        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<Helper> Helpers { get; set; }
    }
}