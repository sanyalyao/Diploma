using NUnit.Framework;
using BussinesObject.UI.Models;
using BussinesObject.UI.Helpers;
using BussinesObject.UI.Pages.GroupPages;
using BussinesObject.UI.Models.EnumObjects;
using OpenQA.Selenium;

namespace TestCases.UI.NegativeTests
{
    public class GroupTests : LoginSteps
    {
        [Test]
        [Description("Checking a negative push message when name is not filled up and access type is chosen")]
        public void CreateGroupWithoutName()
        {
            GroupModel newGroup = CreationHelper.CreateGroup(AccessTypes.Public);
            newGroup.Name = string.Empty;

            Login().GoToSalesPage();
            GroupsPage.OpenGroupsPage();

            IWebElement error = EditCreationGroupPage.CreateNewGroup(newGroup).CheckIfErrorExist();

            Assert.IsTrue(error.Displayed);
            Assert.AreEqual("These required fields must be completed: Name", error.Text);
        }

        [Test]
        [Description("Checking a negative push message when name is filled up and access type is not chosen")]
        public void CreateGroupWithoutAccessType()
        {
            GroupModel newGroup = CreationHelper.CreateGroup(AccessTypes.None);

            Login().GoToSalesPage();
            GroupsPage.OpenGroupsPage();

            IWebElement error = EditCreationGroupPage.CreateNewGroup(newGroup).CheckIfErrorExist();

            Assert.IsTrue(error.Displayed);
            Assert.AreEqual("These required fields must be completed: Access Type", error.Text);
        }

        [Test]
        [Description("Checking a negative push message when name is not filled up and access type is not chosen")]
        public void CreateGroupWithEmptyFields()
        {
            GroupModel newGroup = CreationHelper.CreateGroup(AccessTypes.None);
            newGroup.Name = string.Empty;

            Login().GoToSalesPage();
            GroupsPage.OpenGroupsPage();

            IWebElement error = EditCreationGroupPage.CreateNewGroup(newGroup).CheckIfErrorExist();

            Assert.IsTrue(error.Displayed);
            Assert.AreEqual("These required fields must be completed: Access Type, Name", error.Text);
        }
    }
}
