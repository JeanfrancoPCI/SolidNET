using RepositoryConsoleNET;

IProductoRepository repositorio = new ProductoRepository(new InMemoryDatabase());

while (true)
{
    Console.WriteLine("\n=== Patrón Repository - Productos ===");
    Console.WriteLine("1. Listar productos");
    Console.WriteLine("2. Buscar por Id");
    Console.WriteLine("3. Agregar producto");
    Console.WriteLine("4. Actualizar producto");
    Console.WriteLine("5. Eliminar producto");
    Console.WriteLine("0. Salir");
    Console.Write("Opción: ");

    switch (Console.ReadLine()?.Trim())
    {
        case "1":
            Listar();
            break;

        case "2":
        {
            var producto = repositorio.GetById(LeerEntero("Id: "));
            Console.WriteLine(producto is null ? "Producto no encontrado." : Formatear(producto));
            break;
        }
 
        case "3":
        {
            var producto = new Producto
            {
                Nombre = LeerTexto("Nombre: "),
                Precio = LeerDecimal("Precio: ")
            };
            repositorio.Add(producto);
            Console.WriteLine($"Producto agregado: {Formatear(producto)}");
            break;
        }

        case "4":
        {
            var id = LeerEntero("Id a actualizar: ");
            var actual = repositorio.GetById(id);
            if (actual is null) 
            { 
                Console.WriteLine("Producto no encontrado."); 
                break; 
            }

            Console.WriteLine($"Actual: {Formatear(actual)} (Enter para mantener el valor)");

            Console.Write("Nuevo nombre: ");
            var nombre = Console.ReadLine()?.Trim();

            Console.Write("Nuevo precio: ");
            var precioTexto = Console.ReadLine()?.Trim();

            var actualizado = new Producto
            {
                Id = actual.Id,
                Nombre = string.IsNullOrEmpty(nombre) ? actual.Nombre : nombre,
                Precio = decimal.TryParse(precioTexto, out var precio) && precio >= 0 ? precio : actual.Precio
            };

            repositorio.Update(actualizado);
            Console.WriteLine($"Actualizado: {Formatear(actualizado)}");
            break;
        }

        case "5":
        {
            int id = LeerEntero("Id a eliminar: ");
            if (repositorio.GetById(id) is null) 
            { 
                Console.WriteLine("Producto no encontrado."); 
                break; 
            }
            repositorio.Delete(id);
            Console.WriteLine($"Producto {id} eliminado.");
            break;
        }

        case "0":
            return;

        default:
            Console.WriteLine("Opción inválida.");
            break;
    }
}

void Listar()
{
    Console.WriteLine($"{"Id",-4} {"Nombre",-20} {"Precio",10}");

    foreach (var p in repositorio.GetAll())
        Console.WriteLine($"{ p.Id,-4 } { p.Nombre,-20 } { p.Precio,10:N2}");
}

string Formatear(Producto p) => $"[{ p.Id,-4 }] { p.Nombre } - S/{ p.Precio,10:N2}";

string LeerTexto(string etiqueta)
{
    while (true)
    {
        Console.Write(etiqueta);
        var texto = Console.ReadLine()?.Trim();

        if (!string.IsNullOrEmpty(texto)) return texto;

        Console.WriteLine("No puede estar vacío.");
    }
}

int LeerEntero(string etiqueta)
{
    while (true)
    {
        Console.Write(etiqueta);

        if (int.TryParse(Console.ReadLine(), out var valor)) return valor;

        Console.WriteLine("Ingresa un número entero.");
    }
}

decimal LeerDecimal(string etiqueta)
{
    while (true)
    {
        Console.Write(etiqueta);

        if (decimal.TryParse(Console.ReadLine(), out var valor) && valor >= 0) return valor;

        Console.WriteLine("Ingresa un monto válido (mayor o igual a 0).");
    }
}
