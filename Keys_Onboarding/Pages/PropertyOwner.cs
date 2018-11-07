using Keys_Onboarding.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using static Keys_Onboarding.Global.CommonMethods;


namespace Keys_Onboarding
{
    public class PropertyOwner
    {
        public PropertyOwner()
        {
            PageFactory.InitElements(Global.Driver.driver, this);
        }

        #region WebElements Definition
        //Define Owners tab
        [FindsBy(How =How.XPath,Using = "//div[contains(text(),'Owners')]")]
        private IWebElement Ownertab { set; get; }

        //Define Properties page
        [FindsBy(How = How.LinkText, Using = "Properties")]
        private IWebElement PropertiesPage { set; get; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Skip')]")]
        private IWebElement btnSkip { set; get; }


        //Define search bar        
        [FindsBy(How = How.Id, Using = "SearchBox")]
        private IWebElement SearchBar { set; get; }

        //Define search button
        
        [FindsBy(How = How.Id, Using = "icon-submitt")]
        private IWebElement SearchButton { set; get; }

        #endregion

        public void Common_methods()
        {
            Global.Driver.wait(5);
            //Click on the Owners tab
            if (btnSkip.Displayed)
            {
                btnSkip.Click();
            }

            Ownertab.Click();

            //Select properties page
            PropertiesPage.Click();
        }

        internal void SearchAProperty()
        {
            try
            {
                //Calling the common methods
                Common_methods();
                Driver.wait(5);

                //Enter the value in the search bar
                SearchBar.SendKeys("TestingProperty");
                SearchBar.SendKeys(Keys.Enter);
                Global.Driver.wait(5);

                //Click on the search button
                SearchButton.Click();
                Driver.wait(20);

                System.Threading.Thread.Sleep(3000);
                string ExpectedValue = "TestingProperty";

                IWebElement searchInput = Global.Driver.driver.FindElement(By.Id("SearchBox"));
                    
                string ActualValue = searchInput.Text;
                              

                //Assert.AreEqual(ExpectedValue, ActualValue);
                if (ExpectedValue == ActualValue)
                                    
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Passed, Search successfull");
                
                else
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Search Unsuccessfull");

            }

            catch(Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Search Unsuccessfull",e.Message);
            }
         }
    }
}