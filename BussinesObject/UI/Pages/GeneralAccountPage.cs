using BussinesObject.UI.Elements;
using OpenQA.Selenium;

namespace BussinesObject.UI.Pages
{
    public class GeneralAccountPage : BasePage
    {
        protected By accountNameTitleBy = By.ClassName("custom-truncate");
        protected By nameOfFirstColumnTableBy = By.CssSelector("span[title='Account Name']");

        protected Input accountNameInput = new Input("input", "name", "Name");
        protected Input phoneInput = new Input("input", "name", "Phone");
        protected Input accountNumberInput = new Input("input", "name", "AccountNumber");
        protected Input billingStreetInput = new Input("textarea", "name", "street");
        protected Input billingZipInput = new Input("input", "name", "postalCode");
        protected Input billingCityInput = new Input("input", "name", "city");
        protected Input billingCountryInput = new Input("input", "name", "country");

        protected Button saveNewAccountButton = new Button("button", "name", "SaveEdit");
    }
}
