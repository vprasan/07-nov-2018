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
    public class MyRentalSendRequestSteps : Global.Base
    {
        [Given(@"user is in the send a request page with tenant credentials")]
        public void GivenUserIsInTheSendARequestPageWithTenantCredentials()
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
                test = extent.StartTest("MyRentals-->SendRequests");

                //create the object of the CommonPage
                CommonPage pageTenants = new CommonPage();
                Global.Driver.wait(5);
                pageTenants.clickTenants();


               
                //create the object of the MyRental Page
                MyRentals pageMyRentals = new MyRentals();
                System.Threading.Thread.Sleep(2000);
                pageMyRentals.click();
                System.Threading.Thread.Sleep(5000);


            }


        }

        [When(@"user enters the required request details in the rental request page and clicks submit button")]
        public void WhenUserEntersTheRequiredRequestDetailsInTheRentalRequestPageAndClicksSubmitButton()
        {

            MyRentalSendRequestPage pagesendrequest = new MyRentalSendRequestPage();
            pagesendrequest.SendRequest();

        }

        [Then(@"the rental properties page should be displayed after saving the send request details")]
        public void ThenTheRentalPropertiesPageShouldBeDisplayedAfterSavingTheSendRequestDetails()
        {
            // Screenshot
            String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "MyRentalsSendRequest");
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
