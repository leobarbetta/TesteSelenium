using FuturaGene.Florestal.Pomar.Selenium.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace FuturaGene.Florestal.Pomar.Selenium.TestCases.Material
{
    public class EspecieTest : Startup, IDisposable
    {
        [Fact]
        public void InsereEspecieSucesso()
        {
            Driver.Navigate().GoToUrl("http://localhost:63311/Especies");
            wait.Until(ExpectedConditions.UrlContains("http://localhost:63311/Especies"));

            IWebElement btnNovaEspecie = Driver.FindElement(By.CssSelector("button[class='btn btn-success center-block btn-fg square']"));
            btnNovaEspecie.Click();

            IWebElement btnCreate = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("btnCreate")));
            IWebElement txtNomeEspecie = Driver.FindElement(By.Id("Nome"));

            txtNomeEspecie.Clear();
            txtNomeEspecie.SendKeys("Especie Desconhecida - 11");

            btnCreate.Click();

            IWebElement retorno = wait.Until(ExpectedConditions.ElementExists(By.ClassName("iziToast-color-green")));

            Assert.Equal("Sucesso", retorno.Text);

        }


        public EspecieTest()
        {
            SetUpAdmin();
        }

        public void Dispose()
        {
            TearDown();
        }
    }
}
