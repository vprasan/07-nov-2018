//using Baseclass.Contrib.SpecFlow.Selenium.NUnit.Bindings;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testspecflow.Utility;

namespace Keys_Onboarding

{

    class ListARental
    {
              
        public ListARental() //constructor to initialise the webdriver.

        {
        
            PageFactory.InitElements(Global.Driver.driver, this);

        }
        
        #region  Initialize Web Elements 

        //Locator for preoperty ddw
        
        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/div/form/fieldset/div[2]/div/input[2]")]
        public IWebElement ddwproperty { set; get;}

        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/div/form/fieldset/div[2]/div/div[2]/div[3]")]
        public IWebElement ddwpropertyselect { set; get;}

        //Locator for title
        [FindsBy(How = How.XPath, Using = "//input[@data-bind='textInput : Title']")]
        public IWebElement txttitle { set; get;}

        //Locator for Description
        [FindsBy(How = How.XPath, Using = "//textarea[@data-bind='textInput : RentalDescription']")]
        public IWebElement txtDesc { set; get;}

        //Locator for Moving Cost
        [FindsBy(How = How.XPath, Using = "//input[@data-bind='textInput : MovingCost']")]
        public IWebElement txtmovingcost { set; get;}

        //Locator for Rent
        [FindsBy(How = How.XPath, Using = "//input[@data-bind='textInput : TargetRent']")]
        public IWebElement txtRent { set; get;}


        //Locator for avaialble date
        [FindsBy(How = How.XPath, Using = "//input[@data-bind=\"datePicker : AvailableDate, dateTimePickerOptions : {format: 'DD/MM/YYYY', minDate: new Date() }\"]")]
        public IWebElement txtdate { set; get;}

      
        //Locator for occupant count
        [FindsBy(How = How.XPath, Using = "//input[@data-bind='textInput : OccupantCount']")]
        public IWebElement txtcount { set; get;}

        //Locator for pet allowed
        [FindsBy(How = How.XPath, Using = "//select[@data-bind=\"options: PetsAllowedOption, optionsText: 'Choice',optionsValue : 'Choice', value : PetsAllowed\"]")]
        public IWebElement txtpetsallowed { set; get;}

        
        //Locator for Save Button
        [FindsBy(How = How.XPath, Using = "//button[@data-bind='click : SubmitRentalListing,enable:validInput']")]
        public IWebElement btnSave { set; get;}

        //Locator for Cancel Button
        [FindsBy(How = How.XPath, Using = "//button[@data-bind='click: confirmationModal']")]
        public IWebElement btnCancel { set; get;}

        #endregion




        internal void ListAPropertyForRental(Boolean bsave, Boolean bcancel)
        {
            try
            {

                //Enter the value for all the required fields
                
                System.Threading.Thread.Sleep(1000);
                ddwproperty.Click();
                System.Threading.Thread.Sleep(1000);
                ddwpropertyselect.Click();
                txttitle.SendKeys(title);
                txtDesc.SendKeys(Desc);
                System.Threading.Thread.Sleep(3000);
                txtmovingcost.SendKeys(Convert.ToString(cost));
                txtRent.SendKeys(Convert.ToString(rent));
                txtdate.SendKeys(date);
                txtcount.SendKeys(Convert.ToString(count));
                txtpetsallowed.SendKeys(petsallowed + Keys.Tab);
                //txtYeearBuilt.SendKeys(Convert.ToString(built) + Keys.Tab);
                //SearchBar.SendKeys(Keys.Enter);
                Global.Driver.wait(5);

                if (bsave)
                {
                    btnSave.Click();
                    bsave = false;
                }

                if (bcancel)
                {
                    btnCancel.Click();
                    bcancel = false;
                }


                string Title = Global.Driver.driver.Title;

                string ExpectedValue = "Properties page";

                
                string ActualValue = Title;


                //Assert.AreEqual(ExpectedValue, ActualValue);
                if (ExpectedValue == ActualValue)

                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Passed, ListARental successfull");

                else
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, ListARental Unsuccessfull");

            }

            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Search Unsuccessfull", e.Message);
            }
        }

        
    }


}
