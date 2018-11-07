using Keys_Onboarding.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding.Pages

{
    class OwnersPage

    {

        public OwnersPage() //constructor to initialise the webdriver.

        {
            PageFactory.InitElements(Global.Driver.driver, this);
        }


        #region  Initialize Web Elements

        //Locator for Add Prorety button
        [FindsBy(How = How.XPath, Using = "//a[@class='ui teal button' and @href = '/PropertyOwners/Property/AddNewProperty']")]
        private IWebElement btnAddProperty { set; get; }

        //Locator for List as Rental button
        [FindsBy(How = How.XPath, Using = "//a[@class='ui teal button' and @href = '/PropertyOwners/Property/ListRental?propId=-1&returnUrl=%2FPropertyOwners']")]
        public IWebElement btnListAsRental;

        //Locator for Add Tenant button
        [FindsBy(How = How.LinkText, Using = "Add Tenant")]
        public IWebElement btnAddTenant;

        //Locator for List as Rental second button
        [FindsBy(How = How.LinkText, Using = "List As Rental")]
        public IWebElement btnListAsRental1;

        //Locator for Send Request button
        [FindsBy(How = How.LinkText, Using = "Send Request")]
        public IWebElement btnSendRequest;


        //Locator for sort dropdown
        [FindsBy(How = How.XPath, Using = "//div[@class = 'ui dropdown selection']")]
        public IWebElement ddwsort;

        //Locator for sort dropdown by 'Name'
        [FindsBy(How = How.XPath, Using = "//div[@class='item' and @data-value='/PropertyOwners?SortOrder=Name']")]
        public IWebElement ddwsortName;

        //Locator for sort dropdown by 'Name(Desc)'
        [FindsBy(How = How.XPath, Using = "//div[@class='item' and contains(text(),'Name(Desc)')]")]
        public IWebElement ddwsortNameDesc;

        //Locator for sort dropdown by Latest Date)'
        [FindsBy(How = How.XPath, Using = "//div[@class='item' and contains(text(),'Latest Date')]")]
        public IWebElement ddwsortLatestDate;

        //Locator for sort dropdown by Latest Date)'
        [FindsBy(How = How.XPath, Using = "//div[@class='item' and contains(text(),'Earliest Date')]")]
        public IWebElement ddwsortEarliestDate;


        //Locator for group click locator
        [FindsBy(How = How.XPath, Using = "//i[@class='ui more grey list icon']")]
        public IWebElement ddwgroup;

        //Locator for group ddw item Finance
        [FindsBy(How = How.XPath, Using = "//div[@class='item' and contains(text(),'Finance')]")]
        public IWebElement ddwfinance;

        //Locator for group ddw item Property Details
        [FindsBy(How = How.XPath, Using = "//div[@class='item' and contains(text(),'Property Details')]")]
        public IWebElement ddwPropertyDetails;

        //Locator for group ddw item Manage Tenant
        [FindsBy(How = How.XPath, Using = "//a[@class='default-item-color' and (contains(text(),'Manage Tenant'))]")]
        public IWebElement ddwManageTenant;

        //Locator for group ddw item Edit Property
        [FindsBy(How = How.XPath, Using = "//div[@class='item' and contains(text(),'Edit Property')]")]
        public IWebElement ddwEditProperty;

        //Locator for group ddw item Delete
        [FindsBy(How = How.XPath, Using = "//div[@class='item' and contains(text(),'Delete')]")]
        public IWebElement ddwdelete;

        //Locator Confirm delete
        [FindsBy(How = How.XPath, Using = "//button[@data-bind='click: $root.Delete']")]
        public IWebElement btnConfirmdelete;


        //Locator back button

        // [FindsBy(How = How.XPath, Using = "//button[@class=' ui blue button']")]
        [FindsBy(How = How.XPath, Using = "//button[@class=' ui button']")]

        public IWebElement btnback;

        #endregion

        internal void clickAddProperty()

        {
            try

            {
                System.Threading.Thread.Sleep(2000);
                btnAddProperty.Click();
                System.Threading.Thread.Sleep(3000);
                System.Threading.Thread.Sleep(3000);


                string Title = Global.Driver.driver.Title;

                string ExpectedValue = "Properties | Add New Property";


                string ActualValue = Title;


                //Assert.AreEqual(ExpectedValue, ActualValue);
                if (ExpectedValue == ActualValue)

                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Passed, Click on AddProperty button successfull");

                else
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Click on AddProperty button Unsuccessfull");

            }

            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Click on Add Property button Unsuccessfull", e.Message);
            }

        }

        internal void clickDeleteProperty()
        {
            try
            {
                System.Threading.Thread.Sleep(2000);
                ddwgroup.Click();
                System.Threading.Thread.Sleep(1000);
                ddwdelete.Click();
                System.Threading.Thread.Sleep(2000);
                btnConfirmdelete.Click();

                string Title = Global.Driver.driver.Title;

                string ExpectedValue = "Properties | Property Community";


                string ActualValue = Title;


                //Assert.AreEqual(ExpectedValue, ActualValue);
                if (ExpectedValue == ActualValue)

                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Passed, delete property successfull");

                else
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, delete property Unsuccessfull");

            }

            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, delete property Unsuccessfull", e.Message);
            }
        }

        internal void clickListARental()
        {
            try
            {
                System.Threading.Thread.Sleep(2000);
                btnListAsRental.Click();
                System.Threading.Thread.Sleep(2000);

                string Title = Global.Driver.driver.Title;

                string ExpectedValue = "ListRental";


                string ActualValue = Title;


                //Assert.AreEqual(ExpectedValue, ActualValue);
                if (ExpectedValue == ActualValue)

                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Passed, Landing on ListARental Page successfull");

                else
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Landing on ListARental Page Unsuccessfull");

            }

            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Landing on ListARental Page Unsuccessfull", e.Message);
            }
        }

        internal void clickbackbutton()
        {
            try

            {
                System.Threading.Thread.Sleep(3000);
                btnback.Click();
                System.Threading.Thread.Sleep(3000);

                string Title = Global.Driver.driver.Title;

                string ExpectedValue = "Properties | Property Community";


                string ActualValue = Title;


                //Assert.AreEqual(ExpectedValue, ActualValue);
                if (ExpectedValue == ActualValue)

                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Passed, Langing on Properties Page after clicking back button successfull");

                else
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Langing on Properties Page after clicking back button Unsuccessfull");

            }

            catch (Exception e)

            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Langing on Properties Page after clicking back button Unsuccessfull", e.Message);
            }

        }

    }

}


