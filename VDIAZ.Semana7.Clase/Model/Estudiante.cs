using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace VDIAZ.Semana7.Clase.Model
{
    public class Estudiante
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255)]
        public String Nombre { get; set; }
        [MaxLength(255)]
        public String Usuario { get; set; }
        [MaxLength(255)]
        public String Clave { get; set; }

    }
}
