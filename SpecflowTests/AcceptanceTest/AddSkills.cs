using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System.Threading;
using static SpecflowPages.CommonMethods;


namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class AddSkills
    {
        private const string XpathToFind = "//*[@id=\"account - profile - section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select/option";
       

        [Given(@"I clicked on the Skills tab under Profile page")]
        public void GivenIClickedOnTheSkillsTabUnderProfilePage()
        {
            //wait 
            Thread.Sleep(5000);

            //click on skills tab
            Driver.driver.FindElement(By.XPath("//a[contains(@data-tab,'second')]")).Click();
        }
        
        [When(@"I add a new Skills")]
        public void WhenIAddANewSkills()
        {
            //Click on Add New Button
            Driver.driver.FindElement(By.XPath("//div[@class='ui teal button'][contains(.,'Add New')]")).Click();

            //Add Skills Click on "Add Skills and enter "CSS"
            Driver.driver.FindElement(By.Name("name")).SendKeys("CSS");

            //Click on Skills Level
            Driver.driver.FindElement(By.XPath("//select[contains(@class,'ui fluid dropdown')]")).Click();

            IWebElement skillLevel = Driver.driver.FindElement(By.CssSelector("#account-profile-section > div > section:nth-child(3) > div > div > div > div.eight.wide.column > form > div.ui.bottom.attached.tab.segment.tooltip-target.active > div > div.twelve.wide.column.scrollTable > div > div > div:nth-child(2) > select > option:nth-child(4)"));
            skillLevel.Click();

          
            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[contains(@class,'ui teal button ')]")).Click();



        }

        [Then(@"that skills should be displayed om my listing")]
        public void ThenThatSkillsShouldBeDisplayedOmMyListing()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add skills");

                Thread.Sleep(1000);
                string ExpectedValue = "CSS";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id=\"account - profile - section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Skills Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillsAdded");
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
