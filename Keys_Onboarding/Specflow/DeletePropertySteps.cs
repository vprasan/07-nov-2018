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
    public class DeletePropertySteps : Global.Base
    {
        [Given(@"user is in logged into the application")]
        public void GivenUserIsInLoggedIntoTheApplication()
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
            }

        }
        
        [When(@"user clicks on the delete property button in the property page")]
        public void WhenUserClicksOnTheDeletePropertyButtonInThePropertyPage()
        {

            // Creates a toggle for the given test, adds all log events under it    
            test = extent.StartTest("Delete a Property");


            //create the object of the CommonPage
            CommonPage pageproperties = new CommonPage();
            pageproperties.clickOwners();

            //create the object of the OwnersPage
            OwnersPage PageOwners = new OwnersPage();
            PageOwners.clickDeleteProperty();
            System.Threading.Thread.Sleep(3000);



        }

        [Then(@"the selected property will be deleted from the owners property")]
        public void ThenTheSelectedPropertyWillBeDeletedFromTheOwnersProperty()
        {
            // Screenshot
            String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Delete a Property");
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
