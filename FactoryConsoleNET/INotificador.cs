using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryConsoleNET
{
    public interface INotificador
    {
        void EnviarNotificacion(string mensaje); 
    }

    public class EmailNotificador : INotificador
    {
        private readonly string _email;
        public EmailNotificador(string email)
        {
            _email = email;
        }
        public void EnviarNotificacion(string mensaje)
        {
            Console.WriteLine($"Enviando notificación por correo: {mensaje} al correo {_email}");
        }
    }

    public class SMSNotificador : INotificador
    {
        private readonly string _numeroTelefono;
        public SMSNotificador(string numeroTelefono)
        {
            _numeroTelefono = numeroTelefono;
        }
        public void EnviarNotificacion(string mensaje)
        {
            Console.WriteLine($"Enviando notificación por SMS: {mensaje} al número {_numeroTelefono}");
        }
    }

    public class TeamsNotificador : INotificador
    {
        private readonly string _correo;
        public TeamsNotificador(string correo)
        {
            _correo = correo;
        }
        public void EnviarNotificacion(string mensaje)
        {
            Console.WriteLine($"Enviando notificación por Teams: {mensaje} al correo {_correo}");
        }
    }
}