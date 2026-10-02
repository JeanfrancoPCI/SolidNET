using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryConsoleNET
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly InMemoryDatabase _database;

        public ProductoRepository(InMemoryDatabase database)
        {
            _database = database;
        }

        public int GetNextId()
        {
            return _database.Productos.Select(p => p.Id).DefaultIfEmpty(0).Max() + 1;
        }

        public void Add(Producto producto)
        {
            int nuevoId = GetNextId();
            producto.Id = nuevoId;
            _database.Productos.Add(producto);
        }

        public void Delete(int id)
        {
            var producto = _database.Productos.FirstOrDefault(p => p.Id == id);
            if (producto != null)
            {
                _database.Productos.Remove(producto);
            }
        }

        public IEnumerable<Producto> GetAll()
        {
            return _database.Productos;
        }

        public Producto? GetById(int id)
        {
            return _database.Productos.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Producto producto)
        {
            var productoEncontrado = _database.Productos.FirstOrDefault(p => p.Id == producto.Id);
            if (productoEncontrado != null)
            {
                productoEncontrado.Nombre = producto.Nombre;
                productoEncontrado.Precio = producto.Precio;
            }
        }
    }
}