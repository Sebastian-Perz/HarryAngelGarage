namespace HarryAngelGarage.Migrations
{
    using HarryAngelGarage.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HarryAngelGarage.DAL.HarryAngelGarageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HarryAngelGarage.DAL.HarryAngelGarageContext context)
        {
            var clients = new List<Client>
            {
            new Client{LastName="Vega",FirstName="Vincent", City="Detroit", PhoneNumber="506407303"},
            new Client{LastName="Hanzo",FirstName="Hattori", City="Detroit", PhoneNumber="808607404"},
            new Client{LastName="Wolf",FirstName="Winston", City="Michigan", PhoneNumber="666999666"},
            new Client{LastName="Von Shaft",FirstName="Broomhilda", City="Michigan", PhoneNumber="666999666"},
            new Client{LastName="Pandemonium",FirstName="Santanico", City="Michigan", PhoneNumber="666999666"},
            new Client{LastName="Dalton",FirstName="Rick", City="Michigan", PhoneNumber="666999666"},
            new Client{LastName="Knox",FirstName="Mallory", City="Michigan", PhoneNumber="666999666"},
            };

            clients.ForEach(s => context.Clients.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var garages = new List<Garage>
            {
            new Garage{GarageName=GarageName.A, Space=10},
            new Garage{GarageName=GarageName.B, Space=10},
            new Garage{GarageName=GarageName.C, Space=10},
            new Garage{GarageName=GarageName.D, Space=10},
            };
            garages.ForEach(s => context.Garages.AddOrUpdate(p => p.GarageName, s));
            context.SaveChanges();

            var workers = new List<Worker>
            {
            new Worker{WorkerID=1050, GarageID=1, FirstName="Oswaldo", LastName="Mobray", BirthYear=DateTime.Parse("1995-09-01"), Salary=3000},
            new Worker{WorkerID=2050, GarageID=2, FirstName="Charlie", LastName="Razor", BirthYear=DateTime.Parse("1993-09-01"), Salary=4000},
            new Worker{WorkerID=3050, GarageID=3, FirstName="Johnny", LastName="Mo", BirthYear=DateTime.Parse("1985-09-01"), Salary=5000},
            };
            workers.ForEach(s => context.Workers.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();



            var helpers = new List<Helper>
            {
            new Helper{WorkerID=1050, FirstName="Lee", LastName="Donowtiz", BirthYear=DateTime.Parse("1993-04-14") },
            new Helper{WorkerID=1050, FirstName="Dick", LastName="Ritchie", BirthYear=DateTime.Parse("1996-09-01") },
            new Helper{WorkerID=2050, FirstName="Hugo", LastName="Stiglitz", BirthYear=DateTime.Parse("1998-03-15") },
            new Helper{WorkerID=2050, FirstName="Elle", LastName="Driver", BirthYear=DateTime.Parse("1999-01-09") },
            new Helper{WorkerID=3050, FirstName="Donnie", LastName="Donowtiz", BirthYear=DateTime.Parse("2001-11-11") },
            new Helper{WorkerID=3050, FirstName="Jules", LastName="Winnfield", BirthYear=DateTime.Parse("2004-05-03") },
            };
            helpers.ForEach(s => context.Helpers.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();


            var cars = new List<Car>
            {
            new Car{
                ClientID = clients.Single(s => s.LastName == "Vega").ID,
                WorkerID = workers.Single(c => c.LastName == "Razor").WorkerID,
                Brand="Ford",
                Model="Ranger",
                CarHandInDate=DateTime.Parse("2005-08-01"),
                ProductionYear=DateTime.Parse("2014-06-01"),
                BodyStyleType=BodyStyleType.PickupTruck,
                VIN="444535234"
            },
            new Car{
                ClientID = clients.Single(s => s.LastName == "Wolf").ID,
                WorkerID = workers.Single(c => c.LastName == "Mobray").WorkerID,
                Brand="Suzuki",
                Model="Vitara",
                CarHandInDate=DateTime.Parse("2005-07-01"),
                ProductionYear=DateTime.Parse("2015-06-01"),
                BodyStyleType=BodyStyleType.SUV,
                VIN="334535234"
            },
            new Car{
                ClientID = clients.Single(s => s.LastName == "Hanzo").ID,
                WorkerID = workers.Single(c => c.LastName == "Razor").WorkerID,
                Brand="Nissan",
                Model="Skyline",
                CarHandInDate=DateTime.Parse("2020-09-01"),
                ProductionYear=DateTime.Parse("2016-06-01"),
                BodyStyleType=BodyStyleType.Sedan,
                VIN="2223253234"
            },
            new Car{
                ClientID = clients.Single(s => s.LastName == "Hanzo").ID,
                WorkerID = workers.Single(c => c.LastName == "Razor").WorkerID,
                Brand="Chevrolet",
                Model="Camaro",
                CarHandInDate=DateTime.Parse("2020-09-01"),
                ProductionYear=DateTime.Parse("2018-06-01"),
                BodyStyleType=BodyStyleType.Coupe,
                VIN="7536535234"
            }
       };
            foreach (Car e in cars)
            {
                var carInDataBase = context.Cars.Where(
                    s =>
                         s.Client.ID == e.ClientID &&
                         s.Worker.WorkerID == e.WorkerID).FirstOrDefault();
                if (carInDataBase == null)
                {
                    context.Cars.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}