using BussinesObject.UI.Elements;
using BussinesObject.UI.Helpers;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace BussinesObject.UI.Pages.GroupPages
{
    public class GroupPage : BasePage
    {
        private By nameOfFirstColumnTableBy = By.CssSelector("th[aria-label='Name']");

        private Button listOfCommandsButton = new Button("li", "data-target-reveals", "sfdc:QuickAction.Global.NewLead,sfdc:StandardButton.CollaborationGroup.EditGroupNotificationSettings,sfdc:StandardButton.CollaborationGroup.EditGroup,sfdc:StandardButton.CollaborationGroup.DeleteGroup,sfdc:StandardButton.CollaborationGroup.AddMembersAction,sfdc:StandardButton.CollaborationGroup.InvitePeopleAction");
        private Button deleteGroupButton = new Button("a", "data-target-selection-name", "sfdc:StandardButton.CollaborationGroup.DeleteGroup");
        private Button confirmDeleteGroupButton = new Button("button", "title", "Delete Group");

        [AllureStep("Delete special group")]
        public GroupsPage DeleteGroup()
        {
            listOfCommandsButton.GetElement().Click();
            deleteGroupButton.GetElement().Click();
            confirmDeleteGroupButton.GetElement().Click();

            WaitHelper.WaitElement(driver, nameOfFirstColumnTableBy);

            logger.Info("Delete special group");

            return new GroupsPage();
        }
    }
}
