using BussinesObject.UI.Elements;
using BussinesObject.UI.Models;
using BussinesObject.UI.Helpers;
using OpenQA.Selenium;
using NUnit.Allure.Attributes;
using OpenQA.Selenium.Interactions;
using System.Windows;

namespace BussinesObject.UI.Pages.GroupPages
{
    public class EditCreationGroupPage : GeneralGroupPage
    {
        private static By groupNameFieldBy = By.CssSelector("div[data-target-selection-name='sfdc:RecordField.CollaborationGroup.Name'] *> input");
        private By groupDetailsBy = By.CssSelector("span[title='Group Details']");
        private By uploadGroupPhotoTitleBy = By.CssSelector("div[class='wizard-step active'] > div[data-aura-class=\"assistantFrameworkWizardHeader\"]");
        private By groupEditTitleBy = By.CssSelector("h2[class='inlineTitle slds-p-top--large slds-p-horizontal--medium slds-p-bottom--medium slds-text-heading--medium']");

        private Button newGroupButton = new Button("a","title", "New");
        private Button saveAndNextButton = new Button("button", "class", "slds-button slds-button--neutral next right slds-button--brand uiButton--brand uiButton");
        private Button doneButton = new Button("button", "class", "slds-button slds-button--neutral finish right slds-button--brand uiButton--brand uiButton");
        private Button saveButton = new Button("button", "title", "Save");

        private Input groupNameInput = new Input(groupNameFieldBy);

        private RadioMenuItem accessTypeRadio = new RadioMenuItem(By.CssSelector("li[class='uiMenuItem uiRadioMenuItem'] > a"));
        private RadioMenuItem radioMenu = new RadioMenuItem(By.CssSelector("a[role='button'][class='select']"));

        private PushMessage errorPushMessage = new PushMessage(By.CssSelector("ul[class='errorsList'] > li"));

        [AllureStep("Create new group")]
        public EditCreationGroupPage CreateNewGroup(GroupModel newGroup)
        {
            newGroupButton.GetElement().Click();

            WaitHelper.WaitElement(driver, groupNameFieldBy);

            groupNameInput.GetElement().SendKeys(newGroup.Name);

            radioMenu.GetElement().Click();

            accessTypeRadio.GetElements().
                Where(element => element.GetAttribute("title").
                Contains(newGroup.AccessType)).
                First().
                Click();

            logger.Info($"Create new group. Name - {newGroup.Name}, AccessType - {newGroup.AccessType}");

            return this;
        }

        [AllureStep("Confirm creation of new group")]
        public GroupsPage ConfirmCreationNewGroup()
        {
            saveAndNextButton.GetElements()[0].Click();

            WaitHelper.WaitElementWithTitle(driver, uploadGroupPhotoTitleBy, "Upload Group Photo");

            saveAndNextButton.GetElements()[1].Click();
            doneButton.GetElement().Click();

            WaitHelper.WaitElementWithTitle(driver, groupDetailsBy, "Group Details");

            logger.Info("Confirm creation of new group");

            return new GroupsPage();
        }

        [AllureStep("Check if push error exist")]
        public IWebElement CheckIfErrorExist()
        {
            saveAndNextButton.GetElements()[0].Click();

            return errorPushMessage.GetElement();
        }

        [AllureStep("Fill up the fields")]
        public EditCreationGroupPage FillUpFields(GroupModel newGroup)
        {
            groupNameInput.GetElement().Clear();
            groupNameInput.GetElement().SendKeys(newGroup.Name);

            radioMenu.GetElement().Click();

            accessTypeRadio.GetElements().Where(element => element.GetAttribute("title").Contains(newGroup.AccessType)).First().Click();

            logger.Info($"Fill up the fields. New name - {newGroup.Name}, new accessType - {newGroup.AccessType}");

            return this;
        }

        [AllureStep("Confirm group changes")]
        public GroupsPage ConfirmGroupChanges()
        {
            saveButton.GetElement().Click();

            WaitHelper.WaitElementWithTitle(driver, titleOfTheGroupsPage, "Recently Viewed");

            logger.Info("Confirm group changes");

            ReloadCurrentPage(titleOfTheGroupsPage, "Recently Viewed");

            return new GroupsPage();
        }

        [AllureStep("Get information about the group")]
        public GroupModel GetGroupInfo()
        {
            string nameGroup = driver.FindElement(groupEditTitleBy).Text.Replace("Edit","").Trim();
            string accessType = radioMenu.GetElement().Text;

            GroupModel group = new GroupModel()
            {
                Name = nameGroup,
                AccessType = accessType,
            };

            logger.Info($"Get information about the group. Name - {nameGroup}, AccessType - {accessType}");

            return group;
        }        
    }
}
