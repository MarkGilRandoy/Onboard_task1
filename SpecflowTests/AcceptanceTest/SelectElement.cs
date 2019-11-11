using System;
using OpenQA.Selenium;

namespace SpecflowTests.AcceptanceTest
{
    internal class SelectElement
    {
        private IWebElement addCerification;

        public SelectElement(IWebElement addCerification)
        {
            this.addCerification = addCerification;
        }

        internal void SelectByText(string v)
        {
            throw new NotImplementedException();
        }
    }
}