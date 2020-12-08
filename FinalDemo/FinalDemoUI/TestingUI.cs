using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace TestingUI
{
    [TestClass]
    public class MySeleniumTests
    {
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContextInstance;
        private IWebDriver driver;
        private string appURL;

        public MySeleniumTests()
        {

        }

        [TestMethod]
        [TestCategory("Chrome")]
        public void TheBingSearchTest()
        {
            driver.Navigate().GoToUrl(appURL);
            
            
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);           
            //Assert.Equals(driver.FindElement(By.Id("title")).GetAttribute("textContent"), "Hello, world!");

            //Identify login
            IWebElement loginLink = driver.FindElement(By.Id("loginLink"));

            //operation
            loginLink.Click();

            //assert
            var userInputBox = driver.FindElement(By.Id("UserName"));
            var pwdInputBox = driver.FindElement(By.Name("Password"));
            Assert.IsTrue(userInputBox.Displayed);
         

            userInputBox.SendKeys("admin");
            pwdInputBox.SendKeys("password");

            //click on the login
            driver.FindElement(By.XPath("//input[@value='Log in']")).Submit();

            var lnkEmployeeDetails = driver.FindElement(By.LinkText("Employee Details"));
            Assert.IsTrue(lnkEmployeeDetails.Displayed);
        }

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestInitialize()]
        public void SetupTest()
        {
            //appURL = "http://localhost:5001";
            appURL = "http://eaapp.somee.com/";
            string browser = "chrome";
            switch (browser)
            {
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "FireFox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }
        }

        [TestCleanup()]
        public void MytestCleanup()
        {
            driver.Quit();
        }

    }
}
