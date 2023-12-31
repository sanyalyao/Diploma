﻿using BussinesObject.UI.Elements;
using BussinesObject.UI.Helpers;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace BussinesObject.UI.Pages
{
    public class HeadPanel : BasePage
    {
        private static By salesPageTitleBy = By.CssSelector("span[title='Sales']");

        private Input searcher = new Input("input", "placeholder", "Search apps and items...");

        private Button appLauncher = new Button("div", "class", "appLauncher slds-context-bar__icon-action");
        private Button appSales = new Button(By.LinkText("Sales"));

        [AllureStep("Go to the Sales page")]
        public void GoToSalesPage()
        {
            appLauncher.GetElement().Click();
            searcher.GetElement().SendKeys("Sales");
            appSales.GetElement().Click();

            WaitHelper.WaitElement(driver, salesPageTitleBy);

            logger.Info($"Go to the Sales page - {driver.Url}");
        }
    }
}
