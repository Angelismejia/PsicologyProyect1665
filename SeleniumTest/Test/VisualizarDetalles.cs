using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumTest.Tests;
using SeleniumTest.Utils;
using System;
using System.Threading;

namespace SeleniumTest.Test
{
    [TestClass]
    public class VisualizarDetalles : BaseTest
    {
        [TestMethod]
        public void VisualizarDetallesPaciente_DeberiaMostrarDatosCorrectamente()
        {
            try
            {
                // Paso 1: Navegar a la página de detalles del paciente
                driver.Navigate().GoToUrl("https://localhost:44333/Paciente/Details/4");

                Thread.Sleep(2000); // Esperar que cargue la página

                // Paso 2: Verificar el título de la página
                Assert.AreEqual("Detalles del Paciente - PsychologyConsultation.Web", driver.Title);

                // Paso 3: Verificar los datos mostrados

                // Nombre
                var nombre = driver.FindElement(By.XPath("//h4")).Text.Trim();
                Assert.AreEqual("Ana Reyes", nombre, "❌ El nombre no coincide");

                // Fecha de nacimiento
                var fecha = driver.FindElement(By.XPath("//p[strong[contains(text(),'Fecha de Nacimiento')]]")).Text;
                Assert.IsTrue(fecha.Contains("24/03/1992"), "❌ La fecha de nacimiento no es correcta");

                // Teléfono
                var telefono = driver.FindElement(By.XPath("//p[strong[contains(text(),'Teléfono')]]")).Text;
                Assert.IsTrue(telefono.Contains("555876543"), "❌ El teléfono no es correcto");

                // Email
                var email = driver.FindElement(By.XPath("//p[strong[contains(text(),'Email')]]")).Text;
                Assert.IsTrue(email.Contains("anareyes@example.com"), "❌ El email no es correcto");

                // Botón de volver
                var volverBtn = driver.FindElement(By.LinkText("Volver a la Lista"));
                Assert.IsTrue(volverBtn.Displayed, "❌ El botón 'Volver a la Lista' no se muestra");

                // Toma captura y muestra mensaje de éxito
                ScreenshotHelper.TakeScreenshot(driver, "DetallesPaciente_OK.png");
                Console.WriteLine("✅ Test Passed: Los detalles del paciente se muestran correctamente.");
            }
            catch (Exception ex)
            {
                // Toma captura en caso de error
                ScreenshotHelper.TakeScreenshot(driver, "DetallesPaciente_Fallido.png");
                Assert.Fail("❌ Error durante la prueba: " + ex.Message);
            }
        }
    }
}

