using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace VehiclesApp.Models
{
    class Vehicle
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManufacturingDate { get; set; }
        public int ModelDate { get; set; }
        public string Brand { get; set; } // Posteriormente puxar da tabela das marcas como lista suspensa
        public string? Observation { get; set; }
    }
}
