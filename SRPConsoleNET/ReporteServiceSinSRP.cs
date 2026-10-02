using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SRPConsoleNET
{
    public class ReporteServiceSinSRP
    {
        public void ConsultarDatos() => Console.WriteLine("Consultando datos...");
        public void GenerarReporte() => Console.WriteLine("Generando reporte...");
        public void EnviarCorreo() => Console.WriteLine("Enviando correo...");
        public void GuardarArchivo() => Console.WriteLine("Guardando archivo...");

        public void EjecutarProceso()
        {
            ConsultarDatos();
            GenerarReporte();
            EnviarCorreo();
            GuardarArchivo();
        }
    }
}