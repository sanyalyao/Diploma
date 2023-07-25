using BussinesObject.UI.Elements;
using BussinesObject.UI.Models;
using BussinesObject.UI.Helpers;
using OpenQA.Selenium;
using NUnit.Allure.Attributes;

namespace BussinesObject.UI.Pages.GroupPages
{
    public class GroupsPage : GeneralGroupPage
    {
        private By groupNameTitleBy = By.CssSelector("div[class='media__body nameActionsContainer slds-p-left--x-large slds-no-space slds-container_fluid']  *> span[class='uiOutputText']");
        private By groupNameFieldBy = By.CssSelector("div[data-target-selection-name='sfdc:RecordField.CollaborationGroup.Name'] *> input");
        private By groupNamesWithLinksBy = By.CssSelector("th[scope='row'] > span *> a");
        private By groupTableRowsBy = By.CssSelector("table[role='grid'] > tbody > tr");
        private static By editGroupButtonBy = By.CssSelector("div[data-target-selection-name='d3d97191b9714f2388cd2ad681fdc4ed']");

        private Button editGroupButton = new Button(editGroupButtonBy);
        private Button goToEditPageButton = new Button(By.LinkText("Edit Group"));
        private Button tabGroupsButton = new Button("one-app-nav-bar-item-root", "data-id", "CollaborationGroup");

        [AllureStep("Open Groups page")]
        public GroupsPage OpenGroupsPage()
        {
            tabGroupsButton.GetElement().Click();

            WaitHelper.WaitElementWithTitle(driver, titleOfTheGroupsPage, "Recently Viewed");

            logger.Info($"Open Groups page - {driver.Url}");

            ReloadCurrentPage(titleOfTheGroupsPage, "Recently Viewed");

            return this;
        }

        [AllureStep("Check if the name's group exist in the groups table")]
        public bool DoesGroupNameExistInGroupsTable(GroupModel group)
        {
            List<string> listOfGroupsames = driver.FindElements(By.CssSelector("th[scope='row'] > span > div > div > div > a")).Count != 0
                ? GetGroupsNames()
                : new List<string>();

            bool result = listOfGroupsames.Contains(group.Name);

            logger.Info($"Check if the name's group exist in the groups table. Result: {result}");

            return result;
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

        [AllureStep("Go to the group page")]
        public GroupPage GotoGroupPageBySequenceNumber(int sequenceNumber)
        {
            driver.Navigate().GoToUrl(GetGroupsLinks()[sequenceNumber]);

            WaitHelper.WaitElement(driver, groupNameTitleBy);

            logger.Info($"Go to the group page from the row {sequenceNumber + 1}");

            return new GroupPage();
        }

        [AllureStep("Go to the group page")]
        public GroupPage GoToGroupPageByGroupName(GroupModel group)
        {
            List<IWebElement> groupNamesLinks = driver.FindElements(groupNamesWithLinksBy).ToList();

            driver.Navigate().GoToUrl(groupNamesLinks.Where(element => element.Text.ToLower() == group.Name.ToLower()).First().GetAttribute("href"));

            WaitHelper.WaitElement(driver, groupNameTitleBy);

            logger.Info($"Go to the group page with name \"{group.Name}\"");

            return new GroupPage();

        }

        [AllureStep("Edit a group")]
        public GroupModel EditGroupBySequenceNumber(int sequenceNumber)
        {
            editGroupButton.GetElements()[sequenceNumber].Click();
            goToEditPageButton.GetElement().Click();

            WaitHelper.WaitElement(driver, groupNameFieldBy);

            logger.Info($"Edit a group from the row {sequenceNumber + 1}");

            return new EditCreationGroupPage().GetGroupInfo();
        }

        [AllureStep("Edit a group")]
        public GroupModel EditGroupByGroupName(string groupName)
        {
            List<IWebElement> rows = driver.FindElements(groupTableRowsBy).ToList();

            rows.Where(row => row.FindElement(groupNamesWithLinksBy).Text.ToLower() == groupName.ToLower()).First().FindElement(editGroupButtonBy).Click();
            goToEditPageButton.GetElement().Click();

            WaitHelper.WaitElement(driver, groupNameFieldBy);

            logger.Info($"Edit the group with name \"{groupName}\"");

            return new EditCreationGroupPage().GetGroupInfo();
        }

        private List<string> GetGroupsLinks()
        {
            List<string> linksToEachGroup = driver.FindElements(groupNamesWithLinksBy).Count != 0
                ? GetLinksFromTable()
                : new List<string>();

            return linksToEachGroup;
        }

        private List<string> GetLinksFromTable()
        {
            List<IWebElement> rows = driver.FindElements(groupNamesWithLinksBy).ToList();
            List<string> links = new List<string>();

            foreach (IWebElement row in rows)
            {
                links.Add(row.GetAttribute("href"));
            }

            return links;
        }
    }
}
