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
        public void Should_NavigateToCreate_AddWad_WithCorrectData()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "http://localhost:5173";

            IWebElement navigateToWads = driver.FindElement(By.Id("RL_Wads")); //RL for RouterLink
            navigateToWads.Click();
            Thread.Sleep(200);
            IWebElement navigateToCreateWad = driver.FindElement(By.Id("CreateWad"));
            navigateToCreateWad.Click();

            IWebElement inputName = driver.FindElement(By.Id("wadName"));
            inputName.SendKeys("SeleniumName");
            IWebElement inputDescription = driver.FindElement(By.Id("wadDescription"));
            inputDescription.SendKeys("SeleniumDescription");

            IWebElement inputReleaseDate = driver.FindElement(By.Id("releaseDate"));
            inputReleaseDate.Click();
            inputReleaseDate.SendKeys("26112026");

            IWebElement inputCategory = driver.FindElement(By.Id("category"));
            inputCategory.SendKeys("173");

            IWebElement inputImageUrl = driver.FindElement(By.Id("imageUrl"));
            inputImageUrl.SendKeys("https://markomaripuu23.thkit.ee/indexmultimedia/imageofalltime.webp");

            IWebElement saveButton = driver.FindElement(By.Id("saveWad"));
            saveButton.Click();

            Thread.Sleep(250);

            IWebElement thisWadButton = driver.FindElement(By.XPath("//button[text()='SeleniumName']"));
            thisWadButton.Click();

            string wadNameDetail = driver.FindElement(By.Id("wadNameDetail")).Text;
            string wadDescriptionDetail = driver.FindElement(By.Id("wadDescriptionDetail")).Text;
            string wadReleaseDateDetail = driver.FindElement(By.Id("wadReleaseDateDetail")).Text;
            string wadCategoryDetail = driver.FindElement(By.Id("wadCategoryDetail")).Text;
            string wadDownloadDetail = driver.FindElement(By.Id("wadDownloadDetail")).Text;

            Assert.Equal("SeleniumName", wadNameDetail);
            Assert.Equal("SeleniumDescription", wadDescriptionDetail);
            Assert.Equal("26112026", wadReleaseDateDetail);
            Assert.Equal("173", wadCategoryDetail);
        }
    }
}
