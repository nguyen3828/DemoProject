using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace TestingUI
{
    [TestClass]
    public class MySeleniumTests
    {
        private TestContext testContextInstance;
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


            #region testing against localhost
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var title = driver.FindElement(By.Id("title")).GetAttribute("textContent");
            Console.WriteLine(title);
            //Check if the title page is Hellw, world!
            Assert.AreEqual(title, "Hello, world!");
            #endregion


            #region testing against a testing site

            ////Identify login
            //IWebElement loginLink = driver.FindElement(By.Id("loginLink"));

            ////operation
            //loginLink.Click();

            ////assert
            //var userInputBox = driver.FindElement(By.Id("UserName"));
            //var pwdInputBox = driver.FindElement(By.Name("Password"));
            //Assert.IsTrue(userInputBox.Displayed);


            //userInputBox.SendKeys("admin");
            //pwdInputBox.SendKeys("password");

            ////click on the login
            //driver.FindElement(By.XPath("//input[@value='Log in']")).Submit();

            //var lnkEmployeeDetails = driver.FindElement(By.LinkText("Employee Details"));
            //Assert.IsTrue(lnkEmployeeDetails.Displayed);
            #endregion
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
            appURL = "http://localhost:5000";
            //appURL = "http://eaapp.somee.com/";
            string browser = "chrome";
            switch (browser)
            {
                case "chrome":
                    ChromeOptions caps = new ChromeOptions();
                    caps.AddArgument("--ignore-ssl-errors=yes");
                    caps.AddArgument("--ignore-certificate-errors");
                    driver = new ChromeDriver(caps);
                    
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
