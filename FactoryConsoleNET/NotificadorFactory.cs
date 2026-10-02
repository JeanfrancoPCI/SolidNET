namespace FactoryConsoleNET
{
    public static class NotificadorFactory
    {
        private static readonly Dictionary<string, (string DatoRequerido, Func<string, INotificador> Crear)> _canales =
            new(StringComparer.OrdinalIgnoreCase)
            {
                ["email"] = ("Correo electrónico", destino => new EmailNotificador(destino)),
                ["sms"]   = ("Número de teléfono", destino => new SMSNotificador(destino)),
                ["teams"] = ("Correo de Teams",    destino => new TeamsNotificador(destino))
            };

        public static IEnumerable<string> Canales => _canales.Keys;

        public static string DatoRequerido(string canal) => Obtener(canal).DatoRequerido;

        public static INotificador Crear(string canal, string destino) => Obtener(canal).Crear(destino);

        private static (string DatoRequerido, Func<string, INotificador> Crear) Obtener(string canal) =>
            _canales.TryGetValue(canal, out var registro)
                ? registro
                : throw new NotSupportedException($"Canal '{canal}' no soportado");
    }
}
