using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class AddCertification
    {
        [Given(@"I clicked on the certification tab under Profile page")]
        public void GivenIClickedOnTheCertificationTabUnderProfilePage()
        {
            //wait 
            Thread.Sleep(5000);

            //click on certifications tab
            Driver.driver.FindElement(By.XPath("//a[contains(@data-tab,'fourth')]")).Click();
        }
        
        [When(@"I add new certification")]


        public void WhenIAddNewCertification()
        {
            //Click on Add New Button
            Driver.driver.FindElement(By.XPath("(//div[@class='ui teal button '][contains(.,'Add New')])[3]")).Click();

            //Add Certification Name
            Driver.driver.FindElement(By.Name("certificationName")).SendKeys("ISTQB Foundation Level - 000"); 

            //Add Certification From
            Driver.driver.FindElement(By.Name("certificationFrom")).SendKeys("ISTQB");

            //Click on Year Selector
            Driver.driver.FindElement(By.XPath("//input[contains(@class,'ui teal button ')]")).Click();

           
            //Click on Add button
          //  Driver.driver.FindElement(By.XPath("//input[contains(@class,'ui teal button ')]")).Click();


        }

        [Then(@"that certification be displayed on my listing")]
        public void ThenThatCertificationBeDisplayedOnMyListing()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Certification");

                Thread.Sleep(1000);
                string ExpectedValue = "CSS";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id=\"account - profile - section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Certification Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "CertificationAdded");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }



        }
    }
}
    
