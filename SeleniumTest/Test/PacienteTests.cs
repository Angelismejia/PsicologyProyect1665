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
    public class CrearPacienteTest
    {
        private IWebDriver driver;
        private List<HtmlReportGenerator.TestResult> resultados;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://localhost:44333/Paciente/Create");
            resultados = new List<HtmlReportGenerator.TestResult>();
        }

        [TestMethod]
        public void CrearNuevoPaciente_DeberiaCrearPacienteCorrectamente()
        {
            string descripcion = "Verifica que se puede crear un nuevo paciente y que aparece en la lista.";
            try
            {
                // Paso 1: Llenar campos del formulario
                driver.FindElement(By.Id("Nombre")).SendKeys("Ana");
                driver.FindElement(By.Id("Apellido")).SendKeys("Gómez");
                driver.FindElement(By.Id("Email")).SendKeys("ana@ejemplo.com");
                driver.FindElement(By.Id("FechaNacimiento")).SendKeys("1990-01-01");
                driver.FindElement(By.Id("Telefono")).SendKeys("123456789");

                // Paso 2: Guardar
                driver.FindElement(By.CssSelector("button[type='submit']")).Click();

                Thread.Sleep(3000); // Esperar la redirección

                // Verificaciones
                Assert.IsTrue(driver.Url.Contains("/Paciente"), "❌ No se redirigió a la lista de pacientes");

                var paciente = driver.FindElement(By.XPath("//td[contains(text(), 'Ana')]"));
                Assert.IsNotNull(paciente, "❌ No se encontró el paciente creado");

                ScreenshotHelper.TakeScreenshot(driver, "PacienteCreado_OK.png");

                resultados.Add(new HtmlReportGenerator.TestResult
                {
                    Nombre = "Crear Nuevo Paciente",
                    Estado = "Exitosa",
                    Descripcion = descripcion,
                    Imagen = "PacienteCreado_OK.png"
                });

                Console.WriteLine("✅ Test Passed: Paciente creado correctamente.");
            }
            catch (Exception ex)
            {
                ScreenshotHelper.TakeScreenshot(driver, "SeccionFallida.png");

                resultados.Add(new HtmlReportGenerator.TestResult
                {
                    Nombre = "Crear Nuevo Paciente",
                    Estado = "Fallida",
                    Descripcion = descripcion + $" Error: {ex.Message}",
                    Imagen = "SeccionFallida.png"
                });

                Assert.Fail("❌ Error durante la prueba: " + ex.Message);
            }
        }

        [TestCleanup]
        public void TearDown()
        {
            HtmlReportGenerator.GenerarReporte(resultados);
            driver.Quit();
        }
    }
}
