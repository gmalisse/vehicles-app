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
        public required string Name { get; set; }
        public required int ManufacturingDate { get; set; }
        public required int ModelDate { get; set; }
        public required string Brand { get; set; } // Posteriormente puxar da tabela das marcas como lista suspensa
        public string? Observation { get; set; }
    }
}
