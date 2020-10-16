using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HarryAngelGarage.Models
{
    public enum BodyStyleType
    {
        Sedan, SUV, PickupTruck, Wagon, Minivan, Van, Hatchback, Crossover, Coupe
    }
    public class Car
    {
        public int CarID { get; set; }
        public int ClientID { get; set; }
        public int WorkerID { get; set; }
        [DisplayName("Marka")]
        public string Brand { get; set; }
        public string Model { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Data oddania")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CarHandInDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Rok produkcji")]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ProductionYear { get; set; }
        [DisplayFormat(NullDisplayText = "Inny")]
        [DisplayName("Nadwozie")]
        public BodyStyleType BodyStyleType { get; set; }
        public string VIN { get; set; }

        public virtual Worker Worker { get; set; }
        public virtual ICollection<Helper> Helpers { get; set; }
        public virtual Client Client { get; set; }



    }
}