using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryConsoleNET
{
    public class InMemoryDatabase
    {
        public List<Producto> Productos { get; set; } = new List<Producto>();

        public InMemoryDatabase()
        {
            Productos.Add(new Producto { Id = 1, Nombre = "Producto A", Precio = 10.99m });
            Productos.Add(new Producto { Id = 2, Nombre = "Producto B", Precio = 15.49m });
            Productos.Add(new Producto { Id = 3, Nombre = "Producto C", Precio = 7.25m });
            Productos.Add(new Producto { Id = 4, Nombre = "Producto D", Precio = 12.00m });
            Productos.Add(new Producto { Id = 5, Nombre = "Producto E", Precio = 20.00m });
        }
    }
}