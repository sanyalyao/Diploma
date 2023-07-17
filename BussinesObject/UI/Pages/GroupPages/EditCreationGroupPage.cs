﻿using BussinesObject.UI.Elements;
using BussinesObject.UI.Models;
using BussinesObject.UI.Helpers;
using OpenQA.Selenium;

namespace BussinesObject.UI.Pages.GroupPages
{
    public class EditCreationGroupPage : BasePage
    {
        private static By groupNameFieldBy = By.CssSelector("div[data-target-selection-name='sfdc:RecordField.CollaborationGroup.Name'] *> input");
        private By groupDetailsBy = By.CssSelector("span[title='Group Details']");
        private By uploadGroupPhotoTitleBy = By.CssSelector("div[class='wizard-step active'] > div[data-aura-class=\"assistantFrameworkWizardHeader\"]");
        private By titleOfTheGroupsPage = By.CssSelector("span[class='triggerLinkText selectedListView slds-page-header__title slds-truncate slds-p-right--xx-small uiOutputText']");

        private Button newGroupButton = new Button("a","title", "New");
        private Button saveAndNextButton = new Button("button", "class", "slds-button slds-button--neutral next right slds-button--brand uiButton--brand uiButton");
        private Button doneButton = new Button("button", "class", "slds-button slds-button--neutral finish right slds-button--brand uiButton--brand uiButton");
        private Button saveButton = new Button("button", "title", "Save");

        private Input groupNameInput = new Input(groupNameFieldBy);

        private RadioMenuItem accessTypeRadio = new RadioMenuItem(By.CssSelector("li[class='uiMenuItem uiRadioMenuItem'] > a"));
        private RadioMenuItem radioMenu = new RadioMenuItem(By.CssSelector("a[role='button'][class='select']"));

        private PushMessage errorPushMessage = new PushMessage(By.CssSelector("ul[class='errorsList'] > li"));

        public EditCreationGroupPage CreateNewGroup(GroupModel newGroup)
        {
            newGroupButton.GetElement().Click();

            WaitHelper.WaitElement(driver, groupNameFieldBy);

            groupNameInput.GetElement().SendKeys(newGroup.Name);

            radioMenu.GetElement().Click();

            accessTypeRadio.GetElements().Where(element => element.GetAttribute("title").Contains(newGroup.AccessType)).First().Click();

            return this;
        }

        public GroupsPage ConfirmCreationNewGroup()
        {
            saveAndNextButton.GetElements()[0].Click();

            WaitHelper.WaitElementWithTitle(driver, uploadGroupPhotoTitleBy, "Upload Group Photo");

            saveAndNextButton.GetElements()[1].Click();
            doneButton.GetElement().Click();

            WaitHelper.WaitElementWithTitle(driver, groupDetailsBy, "Group Details");

            return new GroupsPage();
        }

        public IWebElement CheckIfErrorExist()
        {
            saveAndNextButton.GetElements()[0].Click();

            return errorPushMessage.GetElement();
        }

        public EditCreationGroupPage FillUpFields(GroupModel newGroup)
        {
            groupNameInput.GetElement().Clear();
            groupNameInput.GetElement().SendKeys(newGroup.Name);

            radioMenu.GetElement().Click();

            accessTypeRadio.GetElements().Where(element => element.GetAttribute("title").Contains(newGroup.AccessType)).First().Click();

            return this;
        }

        public GroupsPage ConfirmGroupChanges()
        {
            saveButton.GetElement().Click();

            WaitHelper.WaitElementWithTitle(driver, titleOfTheGroupsPage, "Recently Viewed");

            return new GroupsPage();
        }

        public GroupModel GetGroupInfo()
        {
            string nameGroup = driver.FindElement(groupNameFieldBy).Text;
            string accessType = radioMenu.GetElement().Text;

            GroupModel group = new GroupModel()
            {
                Name = nameGroup,
                AccessType = accessType,
            };

            return group;
        }        
    }
}
