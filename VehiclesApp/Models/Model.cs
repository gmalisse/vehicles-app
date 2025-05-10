using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace VehiclesApp.Models
{
    class Model
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
