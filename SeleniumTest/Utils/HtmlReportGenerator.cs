using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace SeleniumTest.Utils
{
    public class HtmlReportGenerator
    {
        public class TestResult
        {
            public string Nombre { get; set; }
            public string Estado { get; set; } // "Exitosa" o "Fallida"
            public string Descripcion { get; set; }
            public string Imagen { get; set; } // Ruta relativa desde results
        }

        public static void GenerarReporte(List<TestResult> resultados)
        {
            // Ruta para guardar el HTML
            string carpetaDestino = Path.Combine(Directory.GetCurrentDirectory(), "ReportesHtml");

            // Crear carpeta si no existe
            if (!Directory.Exists(carpetaDestino))
                Directory.CreateDirectory(carpetaDestino);

            var html = new StringBuilder();

            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html lang='es'><head><meta charset='UTF-8'>");
            html.AppendLine("<title>Reporte de Pruebas Automatizadas</title>");
            html.AppendLine("<link href='https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css' rel='stylesheet'>");
            html.AppendLine("<style>body{padding:40px;background:#f9f9f9;}img{max-width:300px;border-radius:10px;}</style>");
            html.AppendLine("</head><body>");
            html.AppendLine("<h1>Reporte de Pruebas Automatizadas</h1>");
            html.AppendLine($"<p><strong>Fecha:</strong> {DateTime.Now}</p>");
            html.AppendLine("<table class='table table-bordered table-striped'><thead class='table-dark'><tr><th>Nombre</th><th>Resultado</th><th>Descripción</th><th>Captura</th></tr></thead><tbody>");

            foreach (var res in resultados)
            {
                var color = res.Estado == "Exitosa" ? "text-success" : "text-danger";
                var icon = res.Estado == "Exitosa" ? "✅" : "❌";
                var imagenRelativa = Path.Combine("..", "results", Path.GetFileName(res.Imagen)); // ajustar ruta para que funcione desde ReportesHtml
                html.AppendLine($"<tr><td>{res.Nombre}</td><td class='{color}'><strong>{res.Estado} {icon}</strong></td><td>{res.Descripcion}</td><td><img src='{imagenRelativa}' /></td></tr>");
            }

            html.AppendLine("</tbody></table>");
            html.AppendLine("</body></html>");

            // Guardar archivo HTML
            string rutaReporte = Path.Combine(carpetaDestino, "ReportePruebas.html");
            File.WriteAllText(rutaReporte, html.ToString());
        }
    }
}
