using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace FuturaGene.Florestal.Pomar.Selenium.Configuration
{
    public class Startup
    {
        protected static IWebDriver Driver { get; set; }
        protected WebDriverWait wait;

        protected void SetUpAdmin()
        {
            if (Driver == null)
                Driver = new ChromeDriver();

            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));

            Driver.Manage().Window.Maximize();

            Driver.Navigate().GoToUrl("http://localhost:63311/account/Sair");

            wait.Until(ExpectedConditions.UrlContains("http://localhost:63311/"));

            IWebElement txtUsuario = Driver.FindElement(By.Id("usuario"));
            IWebElement txtSenha = Driver.FindElement(By.Id("senha"));
            IWebElement btnEntrar = Driver.FindElement(By.XPath("//input[@value='Entrar']"));

            txtUsuario.Clear();
            txtUsuario.SendKeys("adminpomar");

            txtSenha.Clear();
            txtSenha.SendKeys("pomaradmin");

            btnEntrar.Click();

            wait.Until(ExpectedConditions.UrlContains("http://localhost:63311/Home"));
        }

        protected void TearDown()
        {
            try
            {
                Driver.Quit();
                Driver = null;
            }
            catch (Exception)
            { }
        }
    }
}
