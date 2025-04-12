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
    public class CrearTratamientoTest
    {
        private IWebDriver driver;
        private List<HtmlReportGenerator.TestResult> resultados;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://localhost:44333/Tratamiento/Create");
            resultados = new List<HtmlReportGenerator.TestResult>();
        }

        [TestMethod]
        public void CrearNuevoTratamientoAnsiedad_DeberiaCrearTratamientoCorrectamente()
        {
            string descripcion = "Verifica que se puede crear un nuevo tratamiento para ansiedad y que aparece en la lista.";
            try
            {
                // Paso 1: Acceder a "Crear Nuevo Tratamiento" (ya hecho en Setup)

                // Paso 2: Ingresar datos del tratamiento
                driver.FindElement(By.Id("Nombre")).SendKeys("Terapia Cognitiva para Ansiedad");
                driver.FindElement(By.Id("Descripcion")).SendKeys("Sesiones semanales con técnicas de reestructuración cognitiva");

                // Paso 3: Guardar
                driver.FindElement(By.CssSelector("button[type='submit']")).Click();

                Thread.Sleep(3000); // Esperar la redirección

                // Verificaciones
                Assert.IsTrue(driver.Url.Contains("/Tratamiento"), "❌ No se redirigió a la lista de tratamientos");

                var tratamiento = driver.FindElement(By.XPath("//td[contains(text(), 'Terapia Cognitiva para Ansiedad')]"));
                Assert.IsNotNull(tratamiento, "❌ No se encontró el tratamiento creado");

                ScreenshotHelper.TakeScreenshot(driver, "TratamientoCreado_OK.png");

                resultados.Add(new HtmlReportGenerator.TestResult
                {
                    Nombre = "Crear Nuevo Tratamiento para Ansiedad",
                    Estado = "Exitosa",
                    Descripcion = descripcion,
                    Imagen = "TratamientoCreado_OK.png"
                });

                Console.WriteLine("✅ Test Passed: Tratamiento creado correctamente.");
            }
            catch (Exception ex)
            {
                ScreenshotHelper.TakeScreenshot(driver, "SeccionFallida.png");

                resultados.Add(new HtmlReportGenerator.TestResult
                {
                    Nombre = "Crear Nuevo Tratamiento para Ansiedad",
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