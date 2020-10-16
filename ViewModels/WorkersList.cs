using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HarryAngelGarage.ViewModels
{
    public class WorkersList
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime? BirthYear { get; set; }
        public decimal Salary { get; set; }

    }
}