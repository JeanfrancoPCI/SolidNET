using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryConsoleNET
{
    public interface IProductoRepository
    {
        int GetNextId();
        IEnumerable<Producto> GetAll();
        Producto? GetById(int id);
        void Add(Producto producto);
        void Update(Producto producto);
        void Delete(int id);
    }
}