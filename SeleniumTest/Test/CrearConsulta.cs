using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumTest.Tests;
using SeleniumTest.Utils;
using System;
using System.Threading;

namespace SeleniumTest.Test
{
    [TestClass]
    public class CrearConsulta : BaseTest
    {
        [TestMethod]
        public void CrearNuevaConsulta_DeberiaCrearConsultaCorrectamente()
        {
            try
            {
                // Paso 1: Navegar a la página de creación de consulta
                driver.Navigate().GoToUrl("https://localhost:44333/Consulta/Create");

                Thread.Sleep(2000); // Esperar que cargue

                // Paso 2: Rellenar los campos del formulario

                // Fecha
                var fechaInput = driver.FindElement(By.Id("Fecha"));
                fechaInput.Clear();
                fechaInput.SendKeys("2024-12-12");

                // Detalles
                var detallesInput = driver.FindElement(By.Id("Detalles"));
                detallesInput.SendKeys("Consulta de prueba");

                // Estado (asegúrate de que este sea un <select>)
                var estadoSelect = driver.FindElement(By.Id("Estado"));
                estadoSelect.SendKeys("Pendiente"); // O usa SelectElement si es un dropdown

                // Paciente (asegúrate de que el nombre esté en la lista)
                var pacienteSelect = driver.FindElement(By.Id("PacienteId"));
                pacienteSelect.SendKeys("Juana Editada Gómez");

                // Paso 3: Crear
                driver.FindElement(By.CssSelector("button[type='submit']")).Click();

                Thread.Sleep(3000); // Esperar redirección

                // Paso 4: Verificación
                var mensajeExito = driver.FindElement(By.XPath("//*[contains(text(), 'Consulta creada correctamente')]"));
                Assert.IsNotNull(mensajeExito, "❌ No se muestra el mensaje de éxito.");

                ScreenshotHelper.TakeScreenshot(driver, "ConsultaCreada_OK.png");
                Console.WriteLine("✅ Test Passed: Consulta creada correctamente.");
            }
            catch (Exception ex)
            {
                ScreenshotHelper.TakeScreenshot(driver, "ConsultaCreada_Fallida.png");
                Assert.Fail("❌ Error durante la prueba: " + ex.Message);
            }
        }
    }
}
