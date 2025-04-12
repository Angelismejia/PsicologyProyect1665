using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTest.Utils;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SeleniumTest.Tests
{
    [TestClass]
    public class AccesoPacientesTest
    {
        private IWebDriver driver;
        private List<HtmlReportGenerator.TestResult> resultados;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            resultados = new List<HtmlReportGenerator.TestResult>();
        }

        [TestMethod]
        public void AccesoAPacientes_DesdeIndex_DeberiaMostrarPaginaPacientes()
        {
            string nombrePrueba = "Acceso a Pacientes desde Index";
            string descripcion = "Verifica que se puede acceder correctamente a la sección de pacientes desde la página principal";
            string imagenIndex = "IndexPage.png";
            string imagenPacientes = "PacientesPage.png";

            try
            {
                // 1. Navegar a la página principal
                driver.Navigate().GoToUrl("https://localhost:44333/");
                Thread.Sleep(1000); // Espera para carga inicial

                // Tomar screenshot de la página principal
                ScreenshotHelper.TakeScreenshot(driver, imagenIndex);
                Console.WriteLine("✔ Página principal cargada correctamente");

                // 2. Verificar elementos clave en la página principal
                Assert.IsTrue(driver.Title.Contains("Bienvenidos"), "El título no contiene 'Bienvenidos'");
                var cardPacientes = driver.FindElement(By.XPath("//div[contains(@class,'card-container')]//h3[contains(text(),'Registro de Pacientes')]"));
                Assert.IsNotNull(cardPacientes, "No se encontró la tarjeta de pacientes");

                // 3. Localizar y hacer clic en el botón "Más Información" de pacientes
                var botonPacientes = driver.FindElement(By.XPath("//div[contains(@class,'card-container')]//a[contains(text(),'Más Información')]"));
                botonPacientes.Click();
                Thread.Sleep(2000); // Espera para la navegación

                // 4. Verificar que estamos en la página de pacientes
                Assert.IsTrue(driver.Url.Contains("/Paciente"), "No se redirigió a la página de pacientes");
                Assert.IsTrue(driver.Title.Contains("Pacientes"), "El título no contiene 'Pacientes'");

                // Tomar screenshot de la página de pacientes
                ScreenshotHelper.TakeScreenshot(driver, imagenPacientes);
                Console.WriteLine("✔ Página de pacientes cargada correctamente");

                // 5. Verificar elementos clave en la página de pacientes
                var tituloPacientes = driver.FindElement(By.XPath("//h1[contains(text(),'Pacientes')]"));
                Assert.IsNotNull(tituloPacientes, "No se encontró el título 'Pacientes'");

                // Reporte de éxito
                resultados.Add(new HtmlReportGenerator.TestResult
                {
                    Nombre = nombrePrueba,
                    Estado = "Exitosa",
                    Descripcion = descripcion,
                    Imagen = imagenPacientes // Mostramos la imagen de la página de pacientes
                });

                Console.WriteLine("✅ Test Passed: Acceso a pacientes correcto");
            }
            catch (Exception ex)
            {
                // Capturar screenshot del fallo
                string imagenError = "ErrorAccesoPacientes.png";
                ScreenshotHelper.TakeScreenshot(driver, imagenError);

                // Reporte de fallo
                resultados.Add(new HtmlReportGenerator.TestResult
                {
                    Nombre = nombrePrueba,
                    Estado = "Fallida",
                    Descripcion = $"{descripcion}. Error: {ex.Message}",
                    Imagen = imagenError
                });

                Console.WriteLine($"❌ Test Failed: {ex.Message}");
                throw;
            }
        }

        [TestCleanup]
        public void TearDown()
        {
            try
            {
                HtmlReportGenerator.GenerarReporte(resultados);
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}