using Keys_Onboarding.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding
{
    class MyRentals
    {

        public MyRentals() //constructor to initialise the webdriver.

        {
            PageFactory.InitElements(Global.Driver.driver, this);

        }

        #region  Initialize Web Elements 
        //Locator for Menu option in My Rentals page
        [FindsBy(How = How.XPath, Using = "//*[@id='mainPage']/table/tbody/tr[1]/td[6]/div/i")]
        public IWebElement buttonmenu { set; get; }

        //Locator for sub menu option "Send a request" in My Rentals page
        [FindsBy(How = How.XPath, Using = "//*[@id='mainPage']/table/tbody/tr[1]/td[6]/div/div/div[1]")]
        public IWebElement buttonsendarequest { set; get; }

        //Locator for sub menu option "My Requests" in My Rentals page
        [FindsBy(How = How.XPath, Using = "//a[@href='/Tenants/Home/MyRequests?returnUrl=%2FTenants%2FHome%2FMyRentals&propId=10560']")]
        public IWebElement buttonMyRequests { set; get; }

            
        //Locator for sub menu option "Landlords Requests" in My Rentals page
        [FindsBy(How = How.XPath, Using = "//*[@id='mainPage']/table/tbody/tr[1]/td[6]/div/div/div[3]/a")]
        public IWebElement buttonLandlordRequests { set; get; }

        #endregion 


        internal void click()
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                buttonmenu.Click();
                System.Threading.Thread.Sleep(5000);
                buttonsendarequest.Click();

                string Title = Global.Driver.driver.Title;

                string ExpectedValue = "My Rentals";

                string ActualValue = Title;


                //Assert.AreEqual(ExpectedValue, ActualValue);
                if (ExpectedValue == ActualValue)

                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Passed, ListARental successfull");

                else
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, ListARental Unsuccessfull");

            }

            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, ListARental Unsuccessfull", e.Message);
            }
        }


        internal void MyRequestsclick ()
        {
            try
            {
                //Global.Driver.wait(5);
                System.Threading.Thread.Sleep(5000);
                buttonmenu.Click();
                //Global.Driver.wait(5);
                System.Threading.Thread.Sleep(5000);
                buttonMyRequests.Click();
                // Global.Driver.wait(5);
                System.Threading.Thread.Sleep(5000);

                string Title = Global.Driver.driver.Title;

                string ExpectedValue = "Tenant | My Requests";

                string ActualValue = Title;


                //Assert.AreEqual(ExpectedValue, ActualValue);
                if (ExpectedValue == ActualValue)

                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Passed, MyRentals---> MyRequests successfull");

                else
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, MyRentals---> MyRequests Unsuccessfull");

            }

            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, MyRentals---> MyRequests Unsuccessfull", e.Message);
            }
        }

        internal void LandlordRequestsClick ()
        {
            try
            {
                // Global.Driver.wait(5);
                System.Threading.Thread.Sleep(3000);
                buttonmenu.Click();
                //Global.Driver.wait(5);
                System.Threading.Thread.Sleep(3000);
                buttonsendarequest.Click();

                                
                string Title = Global.Driver.driver.Title;

                string ExpectedValue = "Properties | Property Community";

                string ActualValue = Title;


                //Assert.AreEqual(ExpectedValue, ActualValue);
                if (ExpectedValue == ActualValue)

                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Passed,  MyRentals---> SendRequests successfull");

                else
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, MyRentals---> SendRequests Unsuccessfull");

            }

            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, MyRentals---> SendRequests Unsuccessfull", e.Message);
            }
        }
    }
}
