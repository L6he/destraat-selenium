using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Destraat_Testing
{
    public class SeleniumExploration
    {
        [Fact] //"samamoodi nagu vitestis oli 'test'", iga test algab nii
        public void Test1()
        {
            IWebDriver driver = new FirefoxDriver(); //OpenQA.Selenium
            //navigatsiooni teha niimoodi
            driver.Url = "https://techno.ee";
        }
    }
}
