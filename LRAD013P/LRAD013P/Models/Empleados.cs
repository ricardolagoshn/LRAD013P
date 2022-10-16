using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace LRAD013P.Models
{
    public class Empleados
    {
        [PrimaryKey , AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string nombres { get; set; }

        [MaxLength(100)]
        public string apellidos { get; set; }

        [MaxLength(20)]
        public int telefono { get; set; }
        public string correo { get; set; }
    }
}
