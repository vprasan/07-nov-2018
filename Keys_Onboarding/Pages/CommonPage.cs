using Keys_Onboarding.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding
{
    public class CommonPage
    {
        // public CommonPage(IWebDriver driver) //constructor to initialise the webdriver.
        public CommonPage()

        {
            PageFactory.InitElements(Global.Driver.driver, this);

        }

        #region  Initialize Web Elements 
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Skip')]")]
        public IWebElement btnSkip { set; get; }
        
        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Owners')]")]
        public IWebElement btnOwner { set; get; }

        [FindsBy(How = How.LinkText, Using = "Properties")]
        public IWebElement btnProperties { set; get; }

        [FindsBy(How = How.XPath, Using = "//a[contains(@class, 'item-link item selected')]")]
        public IWebElement btnDashboard { set; get; }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Tenants')]")]
        public IWebElement btnTenants { set; get; }

        [FindsBy(How = How.XPath, Using = "//a[@href ='/Tenants/Home/MyRentals']")]
        public IWebElement btnMyRentals { set; get; }

        #endregion


        //Logic for landing on Properties Page
        internal void clickOwners()
        {
            try
            {
                if (btnSkip.Displayed)
                {
                    btnSkip.Click();
                }

                System.Threading.Thread.Sleep(5000);
                btnOwner.Click();
                System.Threading.Thread.Sleep(5000);
                btnProperties.Click();


                string Title = Global.Driver.driver.Title;

                string ExpectedValue = "Properties | Property Community";


                string ActualValue = Title;


                //Assert.AreEqual(ExpectedValue, ActualValue);
                if (ExpectedValue == ActualValue)

                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Passed, Landing on Properties page successfull");

                else
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Landing on Properties page Unsuccessfull");
            }

            catch (Exception e)
            {
                 Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Landing on Properties page Unsuccessfull", e.Message);
            }
            
        }

        internal void clickDasbhoard()
        {

            try
            {
                if (btnSkip.Displayed)
                {
                    btnSkip.Click();
                }
                
                System.Threading.Thread.Sleep(5000);
                btnDashboard.Click();
                System.Threading.Thread.Sleep(5000);
                //btnDashboard.Click();

                string Title = Global.Driver.driver.Title;
                string ExpectedValue = "Dashboard";
                string ActualValue = Title;
                
                //Assert.AreEqual(ExpectedValue, ActualValue);
                if (ExpectedValue == ActualValue)

                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Passed, Landing on Dashboard page successfull");

                else
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Landing on Dashboard page Unsuccessfull");
                
            }
            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Landing on Dashboard Page Unsuccessfull", e.Message);
            }


        }

        internal void clickTenants()
        {               
                try

                {
                    if (btnSkip.Displayed)
                    {
                        btnSkip.Click();
                    }
                    
                    System.Threading.Thread.Sleep(5000);
                    btnTenants.Click();
                    System.Threading.Thread.Sleep(5000);
                    btnMyRentals.Click();

                    string Title = Global.Driver.driver.Title;
                    string ExpectedValue = "My Rentals";
                    string ActualValue = Title;

                    //Assert.AreEqual(ExpectedValue, ActualValue);
                    if (ExpectedValue == ActualValue)

                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Passed, Landing on My Rentals page successfull");

                    else
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Landing on My Rentals page Unsuccessfull");

                }

                catch (Exception e)

                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Landing on My Rentals page Unsuccessfull", e.Message);
                }
        }        
    }
}