using Keys_Onboarding.Config;
using Keys_Onboarding.Global;
using Keys_Onboarding.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Keys_Onboarding.Global.CommonMethods;


namespace Keys_Onboarding.Specflow
{
    [Binding]
    public class MyRentalMyRequestsSteps : Global.Base
    {
        [Given(@"user is in the rental properties page")]
        public void GivenUserIsInTheRentalPropertiesPage()
        {
            {
                switch (Browser)
                {

                    case 1:
                        Driver.driver = new FirefoxDriver();
                        break;
                    case 2:
                        Driver.driver = new ChromeDriver();
                        Driver.driver.Manage().Window.Maximize();
                        break;

                }
                if (Keys_Resource.IsLogin == "true")
                {
                    Login loginobj = new Login();
                    loginobj.LoginSuccessfull();
                }
                else
                {
                    Register obj = new Register();
                    obj.Navigateregister();
                }

                extent = new ExtentReports(ReportPath, false, DisplayOrder.NewestFirst);
                extent.LoadConfig(Keys_Resource.ReportXMLPath);

                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("MyRentals-->MyRequests");

                //create the object of the CommonPage
                CommonPage pageTenants = new CommonPage();
                Global.Driver.wait(5);
                pageTenants.clickTenants();

            }

        }

        [When(@"user clicks on the menu option My Requests")]
        public void WhenUserClicksOnTheMenuOptionMyRequests()
        {
         
            //create the object of the MyRentalsPage
            MyRentals pageMyRentals = new MyRentals();
            Global.Driver.wait(5);
            System.Threading.Thread.Sleep(3000);
            pageMyRentals.MyRequestsclick();
           // Global.Driver.wait(5);
            System.Threading.Thread.Sleep(3000);

        }

        [Then(@"the My Requests page should be displayed")]
        public void ThenTheMyRequestsPageShouldBeDisplayed()
        {
            // Screenshot
            String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "MyRentalsMyRequests");
            test.Log(LogStatus.Info, "Image example: " + img);
            // end test. (Reports)
            extent.EndTest(test);
            // calling Flush writes everything to the log file (Reports)
            extent.Flush();

            // Close the driver :)            
            Global.Driver.driver.Close();
        }
    }
}
