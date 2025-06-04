using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace VehiclesApp.Models
{
    public class Vehicle
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManufacturingDate { get; set; }
        public int ModelDate { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string? Observation { get; set; }
    }
}
