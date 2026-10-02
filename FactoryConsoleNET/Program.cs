using FactoryConsoleNET;

while (true)
{
    Console.WriteLine($"\nCanales disponibles: {string.Join(", ", NotificadorFactory.Canales)}");
    Console.Write("Canal (vacío para salir): ");

    var canal = Console.ReadLine()?.Trim() ?? "";
    if (canal == "") break;

    try
    {
        Console.Write($"{ NotificadorFactory.DatoRequerido(canal) }: ");
        var destino = Console.ReadLine()?.Trim() ?? "";

        Console.Write("Mensaje: ");
        var mensaje = Console.ReadLine() ?? "";

        INotificador notificador = NotificadorFactory.Crear(canal, destino);
        notificador.EnviarNotificacion(mensaje);
    }
    catch (NotSupportedException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}
