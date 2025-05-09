using System;

namespace AutonomIA.Models
{
    public class Nota : IEntity
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
