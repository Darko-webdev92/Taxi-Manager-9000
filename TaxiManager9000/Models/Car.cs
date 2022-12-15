using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiManager9000.Models.Enums;

namespace TaxiManager9000.Models
{
    public class Car
    {
        public int Id { get; set; }
        public Model? Model { get; set; }
        public string LicensePlate { get; set; }
        public DateTime LicensePlateExpieryDate { get; set; }
        public List<Driver> AsignedDrivers { get; set; }
    }
}
