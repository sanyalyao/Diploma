﻿using BussinesObject.UI.Elements;
using OpenQA.Selenium;

namespace BussinesObject.UI.Pages.ContactPages
{
    public class GeneralContractPage : BasePage
    {
        protected By contactNameTitleBy = By.ClassName("custom-truncate");
        protected By nameOfFirstColumnTableBy = By.CssSelector("span[title='Name']");

        protected Input firstNameInput = new Input("input", "name", "firstName");
        protected Input lastNameInput = new Input("input", "name", "lastName");
        protected Input mobileInput = new Input("input", "name", "MobilePhone");
        protected Input emailInput = new Input("input", "name", "Email");
        protected Input mailingStreetInput = new Input("textarea", "name", "street");
        protected Input mailingZipInput = new Input("input", "name", "postalCode");
        protected Input mailingCityInput = new Input("input", "name", "city");
        protected Input mailingCountryInput = new Input("input", "name", "country");

        protected Button saveNewContactButton = new Button("button", "name", "SaveEdit");

        protected PushMessage errorPushMessageTitle = new PushMessage(By.CssSelector("div[class='uiPanel--default uiPanel positioned north forceFormPageError slds-popover slds-popover_error open active'] *> div[class='panel-header'] *> h2[title='We hit a snag.']"));
    }
}
