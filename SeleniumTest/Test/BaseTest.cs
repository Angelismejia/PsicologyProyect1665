using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTest.Tests
{
    [TestClass]
    public class BaseTest
    {
        protected IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();  // Para maximizar la ventana del navegador
        }

        [TestCleanup]
        public void Teardown()
        {
            driver.Quit();  // Cierra el navegador después de la prueba
        }
    }
}
