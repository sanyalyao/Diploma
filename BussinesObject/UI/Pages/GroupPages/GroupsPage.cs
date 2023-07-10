using BussinesObject.UI.Elements;
using BussinesObject.UI.Models;
using BussinesObject.UI.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;

namespace BussinesObject.UI.Pages.GroupPages
{
    public class GroupsPage : BasePage
    {
        private By titleOfTheGroupsPage = By.CssSelector("span[class='triggerLinkText selectedListView slds-page-header__title slds-truncate slds-p-right--xx-small uiOutputText']");
        private By groupNameTitleBy = By.CssSelector("div[class='header anchor anchor--rec-home Public forceChatterUserProfileHighlightsStencilDesktop forceChatterChatterGroupCompactStencilDesktop forceRecordLayout'] *> span[class='uiOutputText']");
        private By groupNameFieldBy = By.CssSelector("div[data-target-selection-name='sfdc:RecordField.CollaborationGroup.Name'] *> input");

        private Button editGroupButton = new Button("div", "data-target-selection-name", "d3d97191b9714f2388cd2ad681fdc4ed");
        private Button goToEditPageButton = new Button(By.LinkText("Edit Group"));
        private Button tabGroupsButton = new Button("one-app-nav-bar-item-root", "data-id", "CollaborationGroup");

        public GroupsPage OpenGroupsPage()
        {
            tabGroupsButton.GetElement().Click();

            WaitHelper.WaitElementWithTitle(driver, titleOfTheGroupsPage, "Recently Viewed");

            return this;
        }

        public GroupsPage ReloadCurrentPage()
        {
            driver.Navigate().Refresh();

            WaitHelper.WaitElementWithTitle(driver, titleOfTheGroupsPage, "Recently Viewed");

            return this;
        }

        public bool DoesGroupNameExistInTable(GroupModel group)
        {
            List<string> listOfGroupsames = driver.FindElements(By.CssSelector("th[scope='row'] > span > div > div > div > a")).Count != 0
                ? GetGroupsNames()
                : new List<string>();

            return listOfGroupsames.Contains(group.Name);
        }

        public List<string> GetGroupsNames()
        {
            List<IWebElement> rows = driver.FindElements(By.CssSelector("th[scope='row'] > span > div > div > div > a")).ToList();
            List<string> groupsNames = new List<string>();

            foreach (IWebElement row in rows)
            {
                groupsNames.Add(row.Text);
            }

            return groupsNames;
        }

        public GroupPage TakeGroup(int sequenceNumber)
        {
            driver.Navigate().GoToUrl(GetGroupsLinks()[sequenceNumber]);

            WaitHelper.WaitElement(driver, groupNameTitleBy);

            return new GroupPage();
        }

        public EditCreationGroupPage EditGroup(int sequenceNumber)
        {
            editGroupButton.GetElements()[sequenceNumber].Click();
            goToEditPageButton.GetElement().Click();

            WaitHelper.WaitElement(driver, groupNameFieldBy);

            return new EditCreationGroupPage();
        }

        private List<string> GetGroupsLinks()
        {
            List<string> linksToEachGroup = driver.FindElements(By.CssSelector("th[scope='row'] > span *> a")).Count != 0
                ? GetLinksFromTable()
                : new List<string>();

            return linksToEachGroup;
        }

        private List<string> GetLinksFromTable()
        {
            List<IWebElement> rows = driver.FindElements(By.CssSelector("th[scope='row'] > span *> a")).ToList();
            List<string> links = new List<string>();

            foreach (IWebElement row in rows)
            {
                links.Add(row.GetAttribute("href"));
            }

            return links;
        }
    }
}
