using OpenQA.Selenium;
using System;
using System.Drawing.Imaging;
using System.IO;

namespace SeleniumTest.Utils
{
    public static class ScreenshotHelper
    {
        /// <summary>
        /// Toma un screenshot de la página actual y lo guarda en formato PNG en la carpeta "Results".
        /// </summary>
        /// <param name="driver">Instancia del navegador (IWebDriver).</param>
        /// <param name="baseFileName">Nombre base del archivo.</param>
        public static void TakeScreenshot(IWebDriver driver, string baseFileName)
        {
            try
            {
                // Tomar screenshot
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();

                // Crear carpeta de resultados
                var resultsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Results");
                Directory.CreateDirectory(resultsFolder);

                // Crear nombre de archivo con timestamp
                var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                var filename = $"{Path.GetFileNameWithoutExtension(baseFileName)}_{timestamp}.png";
                var fullPath = Path.Combine(resultsFolder, filename);

                // Usar MemoryStream y System.Drawing para guardar el screenshot
                using (var memoryStream = new MemoryStream(screenshot.AsByteArray))
                {
                    using (var image = System.Drawing.Image.FromStream(memoryStream))
                    {
                        image.Save(fullPath, ImageFormat.Png);
                    }
                }

                Console.WriteLine($"📸 Screenshot guardado en: {fullPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al guardar el screenshot: {ex.Message}");
            }
        }
    }
}
