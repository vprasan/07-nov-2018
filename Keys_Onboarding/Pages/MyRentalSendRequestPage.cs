using Keys_Onboarding.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding.Pages
{
    class MyRentalSendRequestPage
    {
        public MyRentalSendRequestPage() //constructor to initialise the webdriver.

        {
            PageFactory.InitElements(Global.Driver.driver, this);

        }

        #region  Initialize Web Elements 

        [FindsBy(How = How.XPath, Using = "//textarea[@data-bind=\"value: Model.RequestMessage, valueUpdate:'afterkeydown'\"]")]
        [CacheLookup]
        public IWebElement txtMessage { get; set; }


        [FindsBy(How = How.Id, Using = "jobRequestType")]
        [CacheLookup]
        public IWebElement jobRequestType { get; set; }

        //Locator for Submit Button
        [FindsBy(How = How.XPath, Using = "//button[@data-bind='click: $root.SendRequest, enable : IsValid']")]
        public IWebElement btnSubmit;
        #endregion


        internal void SendRequest()
        {
            try
            {

                // Populating the data from Excel
                ExcelLib.PopulateInCollection(Base.ExcelPath, "SendARequest");


                //Enter the value for all the required fields

                System.Threading.Thread.Sleep(5000);

                var select_prop_dropdown_value = new SelectElement(jobRequestType);

                System.Threading.Thread.Sleep(5000);
                select_prop_dropdown_value.SelectByText(ExcelLib.ReadData(2, "ddw_request_type"));

                txtMessage.SendKeys(ExcelLib.ReadData(2, "message") + Keys.Tab + Keys.Tab);

                btnSubmit.Click();

                System.Threading.Thread.Sleep(3000);


                string Title = Global.Driver.driver.Title;

                string ExpectedValue = "My Rentals";

                string ActualValue = Title;


                //Assert.AreEqual(ExpectedValue, ActualValue);
                if (ExpectedValue == ActualValue)

                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Passed, MyRentals--->Save Send Request successfull");

                else
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, MyRentals--->Save Send Request Unsuccessfull");

            }

            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, MyRentals--->Save Send Request Unsuccessfull", e.Message);
            }
        }       

    }
}
