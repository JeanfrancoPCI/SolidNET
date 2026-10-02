using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SRPConsoleNET
{
    public class ReporteServiceConSRP
    {
        private readonly DataRepository _dataRepository;
        private readonly ReportGenerator _reportGenerator;
        private readonly EmailService _emailService;
        private readonly FileStorageService _fileStorageService;

        public ReporteServiceConSRP()
        {
            _dataRepository = new DataRepository();
            _reportGenerator = new ReportGenerator();
            _emailService = new EmailService();
            _fileStorageService = new FileStorageService();
        }

        public void EjecutarProceso()
        {
            _dataRepository.ConsultarDatos();
            _reportGenerator.GenerarReporte();
            _emailService.EnviarCorreo();
            _fileStorageService.GuardarArchivo();
        }
    }

    public class DataRepository()
    {
        public void ConsultarDatos() => Console.WriteLine("Consultando datos...");
    }

    public class ReportGenerator()
    {
        public void GenerarReporte() => Console.WriteLine("Generando reporte...");
    }

    public class EmailService()
    {
        public void EnviarCorreo() => Console.WriteLine("Enviando correo...");
    }
    public class FileStorageService()
    {
        public void GuardarArchivo() => Console.WriteLine("Guardando archivo...");  
    }
}