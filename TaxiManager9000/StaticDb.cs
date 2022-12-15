using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiManager9000.Models;
using TaxiManager9000.Models.Enums;

namespace TaxiManager9000
{
    public static class StaticDb
    {
        public static int UserId = 0;
        public static List<User> users = new List<User>
        {
            new User()
            {
                Id = ++UserId,
                Username = "admin",
                Password = "admin",
                Role =  Role.Administrator
            },
            new User()
            {
                Id = ++UserId,
                Username = "manager",
                Password = "manager",
                Role =  Role.Manager
            },
            new User()
            {
                Id = ++UserId,
                Username = "maintenance",
                Password = "maintenance",
                Role =  Role.Maintenance
            },
        };

        public static int CarId = 0;
        public static List<Car> cars = new List<Car>
            {
                new Car()
                {
                    Id = ++CarId,
                    Model = Model.Golf_6,
                    LicensePlate = "AFW950",
                    LicensePlateExpieryDate  = new DateTime(2023, 1, 1),
                    //AsignedDrivers = new List<Driver>()
                    //{
                    //    drivers.ElementAt(1),
                    //    drivers.ElementAt(2),
                    //    drivers.ElementAt(3)
                    //}
                },
                new Car()
                {
                    Id = ++CarId,
                    Model = Model.Mercedes_Benz_S_Class,
                    LicensePlate = "CKE480",
                    LicensePlateExpieryDate = new DateTime(2021, 10, 15),
                    //AsignedDrivers = new List<Driver>()
                    //{
                    //    drivers.ElementAt(5)

                    //}
                },
                new Car()
                {
                    Id = ++CarId,
                    Model = Model.Mercedes_Benz_E_Class,
                    LicensePlate = "GZDR69",
                    LicensePlateExpieryDate = new DateTime(2024, 5, 30),
                    //AsignedDrivers = new List<Driver>()
                    //{
                    //    drivers.ElementAt(6),
                    //    drivers.ElementAt(7)

                    //}

                },
                //new Car()
                //{
                //    Id = ++CarId,
                //    Model= 
                //}
        };

        public static int DriverId = 0;
        public static List<Driver> drivers = new List<Driver>
        {
            new Driver()
            {
                 Id= ++DriverId,
                  FirstName ="Romario",
                  LastName = "Walsh",
                  CarId = null,
                  License  = "LC12456123",
                  LicenseExpieryDate = new DateTime(2023, 11, 5),
                  Shift = Shift.NoShift
            },
            new Driver()
            {
                  Id= ++DriverId,
                  FirstName ="Kathleen",
                  LastName = "Rankin",
                  CarId = cars.ElementAt(0).Id,
                  License = "LC54435234",
                  LicenseExpieryDate =  new DateTime(2022, 1, 12),
                  Shift = Shift.Morning,
            },
             new Driver()
            {
                  Id= ++DriverId,
                  FirstName ="Ashanti",
                  LastName = "Mooney",
                  CarId = cars.ElementAt(0).Id,
                  License = "LC65803245",
                  LicenseExpieryDate = new DateTime(2022, 5, 19),
                  Shift = Shift.Evening,
            },
             new Driver()
            {
                  Id= ++DriverId,
                  FirstName ="Zakk",
                  LastName = "Hook",
                  CarId = cars.ElementAt(0).Id,
                  License = "LC20897583",
                  LicenseExpieryDate = new DateTime(2023, 9, 28),
                  Shift = Shift.Afternoon,
            },
             new Driver()
             {
                  Id= ++DriverId,
                  FirstName ="Xavier",
                  LastName = "Kelly",
                  CarId = null,
                  License = "LC15636280",
                  LicenseExpieryDate = new DateTime(2024, 6, 1),
                  Shift = Shift.NoShift,
             },
             new Driver()
             {
                  Id= ++DriverId,
                  FirstName ="Joy",
                  LastName = "Shelton",
                  CarId = cars.ElementAt(1).Id,
                  License = "LC47845611",
                  LicenseExpieryDate = new DateTime(2023, 7, 3),
                  Shift = Shift.Evening,
             },
             new Driver()
             {
                  Id= ++DriverId,
                  FirstName ="Kristy",
                  LastName = "Riddle",
                  CarId = cars.ElementAt(2).Id,
                  License = "LC19006543",
                  LicenseExpieryDate = new DateTime(2024, 6, 12),
                  Shift = Shift.Morning,
             },
             new Driver()
             {
                  Id= ++DriverId,
                  FirstName ="Stuart",
                  LastName = "Mayer",
                  CarId = cars.ElementAt(2).Id,
                  License = "LC53187767",
                  LicenseExpieryDate = new DateTime(2023, 10, 10),
                  Shift = Shift.Evening,
             },
        };

    }
}
