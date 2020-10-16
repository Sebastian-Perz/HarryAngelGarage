using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HarryAngelGarage.Models
{
    public class Helper
    {
        public int HelperID { get; set; }
        public int WorkerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthYear { get; set; }

        public virtual Worker Worker { get; set; }
    }
}