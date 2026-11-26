using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destraat_Testing
{
    //teha omaduse testcaseordereri jaoks
    [TestCaseOrderer("Destraat_Testing.PriorityOrderer", "Destraat_Testing")] //ja panna sellele kaks argumenti
    public class FrontendTests1
    {
        [Fact] //siin on test
        [Order(1)] //järjekorranumber
        public void Add_Wad()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "http://localhost:5173";

            IWebElement navigateToWads = driver.FindElement(By.Id("RL_Wads")); //RL for RouterLink
            navigateToWads.Click();
            Thread.Sleep(200);
            IWebElement navigateToCreateWad = driver.FindElement(By.Id("RL_Wads"));
            navigateToWads.Click();
        }
    }
}
