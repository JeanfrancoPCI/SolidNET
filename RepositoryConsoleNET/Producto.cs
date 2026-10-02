using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryConsoleNET
{
    public class Producto
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required decimal Precio { get; set; }
    }
}