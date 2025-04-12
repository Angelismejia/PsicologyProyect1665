using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTest.Utils;
using System;
using System.Collections.Generic;

namespace SeleniumTest.Tests
{
    [TestClass]
    public class EditarPacienteTest : BaseTest
    {
        private List<HtmlReportGenerator.TestResult> resultados;

        [TestInitialize]
        public void TestInitialize()
        {
            resultados = new List<HtmlReportGenerator.TestResult>();
        }

        [TestMethod]
        public void EditarPaciente_DeberiaActualizarNombreCorrectamente()
        {
            string descripcion = "Verifica que se puede editar el nombre de un paciente existente y que los cambios se guardan correctamente";
            string nombreOriginal = "Juan";
            string nuevoNombre = "Juan Editado";

            try
            {
                // Paso 1: Navegar directamente al formulario de edición (ID 2003)
                driver.Navigate().GoToUrl("https://localhost:44333/Paciente/Edit/2003");

                // Esperar a que cargue el formulario
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                wait.Until(d => d.FindElement(By.XPath("//h1[text()='Editar Paciente']")));

                // Paso 2: Verificar que el formulario contiene los datos originales
                var nombreInput = driver.FindElement(By.Id("Nombre"));
                var valorActual = nombreInput.GetAttribute("value").Trim();
                Assert.AreEqual(nombreOriginal, valorActual,
                    $"❌ Valor original incorrecto. Esperado: '{nombreOriginal}', Actual: '{valorActual}'");

                // Paso 3: Editar el nombre
                nombreInput.Clear();
                nombreInput.SendKeys(nuevoNombre);

                // Verificar que el nuevo valor se estableció
                Assert.AreEqual(nuevoNombre, nombreInput.GetAttribute("value"),
                    "❌ No se pudo establecer el nuevo nombre");

                // Paso 4: Guardar cambios
                var guardarButton = driver.FindElement(By.CssSelector("button.btn-primary"));
                guardarButton.Click();

                // Paso 5: Verificar redirección y cambios
                wait.Until(d => d.Url.Contains("/Paciente"));

                // Buscar el paciente editado en la tabla
                var filaPaciente = wait.Until(d =>
                    d.FindElement(By.XPath($"//tr[td[text()='{nuevoNombre}']]")));

                Assert.IsNotNull(filaPaciente, "❌ No se encontró el paciente editado en la lista");

                // Reporte de éxito
                ScreenshotHelper.TakeScreenshot(driver, "PacienteEditado_OK.png");
                resultados.Add(new HtmlReportGenerator.TestResult
                {
                    Nombre = "Editar Paciente",
                    Estado = "Exitosa",
                    Descripcion = descripcion,
                    Imagen = "PacienteEditado_OK.png"
                });

                Console.WriteLine("✅ Test Passed: Paciente editado correctamente");
            }
            catch (Exception ex)
            {
                // Reporte de fallo
                ScreenshotHelper.TakeScreenshot(driver, "EditarPaciente_Fail.png");
                resultados.Add(new HtmlReportGenerator.TestResult
                {
                    Nombre = "Editar Paciente",
                    Estado = "Fallida",
                    Descripcion = $"{descripcion}. Error: {ex.Message}",
                    Imagen = "EditarPaciente_Fail.png"
                });

                Assert.Fail($"❌ Error durante la edición del paciente: {ex.Message}");
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            HtmlReportGenerator.GenerarReporte(resultados);
        }
    }
}