using OpenQA.Selenium;

namespace BussinesObject.UI.Pages.GroupPages
{
    public class GeneralGroupPage : BasePage
    {
        protected By titleOfTheGroupsPage = By.CssSelector("span[class='triggerLinkText selectedListView slds-page-header__title slds-truncate slds-p-right--xx-small uiOutputText']");
    }
}
