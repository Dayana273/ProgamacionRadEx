using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace ProgamacionRadEx.Models
{
    public class Personas
    {
       
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }

        [MaxLength(100)]
        public string Nombre { get; set; }


        [MaxLength(100)]
        public string Apellido { get; set; }

        [Unique,NotNull]   
        public string Telefono { get; set; }

        [MaxLength(5),NotNull]
        public string Edad { get; set; }

        [MaxLength (1000),NotNull] 
        public string Nota { get; set; }    

        public byte[] foto { get; set; }

        public Double Latitud { get; set; }

        public Double Longitud { get; set; }
        public object PersonaSeleccionado { get; }
    }
}
