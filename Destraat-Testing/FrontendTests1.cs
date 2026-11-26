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
        public string[] DataOfWad1 { get; set; } = { Guid.NewGuid().ToString(), "SeleniumDescription", "26112026", "173", "https://google.com" };
        public string[] DataOfWad2 { get; set; } = { "", "NewDescription", "22222222", "939", "https://neti.ee" };
        [Fact] //siin on test
        [Order(1)] //järjekorranumber
        public void Should_NavigateToCreate_AddWad_WithCorrectData()
        {
            //ülesseade
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "http://localhost:5173";

            InputWadData(driver, DataOfWad1);

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

            driver.Quit();

            Assert.Equal(DataOfWad1[0], wadNameDetail);
            Assert.Equal(DataOfWad1[1], wadDescriptionDetail);
            Assert.Equal(DataOfWad1[2], wadReleaseDateDetail);
            Assert.Equal("173", wadCategoryDetail);
            Assert.Equal("0", wadDownloadDetail);
        }
        [Fact]
        [Order(2)]
        public void Should_NavigateToDetailsOfWad_WithPreviouslyCorrectData()
        {
            //ülesseade
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "http://localhost:5173";
            Thread.Sleep(200);

            IWebElement navigateToWads = driver.FindElement(By.Id("RL_Wads")); //RL for RouterLink
            navigateToWads.Click();
            Thread.Sleep(200);

            IWebElement thisWad = driver.FindElement(By.Id($"{DataOfWad1[0]}"));
        }

        private static void InputWadData(IWebDriver driver, string[] dataOfWad)
        {
            IWebElement navigateToWads = driver.FindElement(By.Id("RL_Wads")); //RL for RouterLink
            navigateToWads.Click();
            Thread.Sleep(200);
            IWebElement navigateToCreateWad = driver.FindElement(By.Id("CreateWad"));
            navigateToCreateWad.Click();

            IWebElement inputName = driver.FindElement(By.Id("wadName"));
            inputName.SendKeys(dataOfWad[1]);

            IWebElement inputDescription = driver.FindElement(By.Id("wadDescription"));
            inputDescription.SendKeys(dataOfWad[1]);

            IWebElement inputReleaseDate = driver.FindElement(By.Id("releaseDate"));
            inputReleaseDate.Click();
            inputReleaseDate.SendKeys("26112026");

            IWebElement inputCategory = driver.FindElement(By.Id("category"));
            inputCategory.SendKeys("173");

            IWebElement inputImageUrl = driver.FindElement(By.Id("imageUrl"));
            inputImageUrl.SendKeys("https://markomaripuu23.thkit.ee/indexmultimedia/imageofalltime.webp");
        }
    }
}
