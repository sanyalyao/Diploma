using NUnit.Framework;
using BussinesObject.UI.Models;
using BussinesObject.UI.Helpers;
using BussinesObject.UI.Pages.GroupPages;
using BussinesObject.UI.Models.EnumObjects;
using Allure.Net.Commons;
using NUnit.Allure.Attributes;

namespace TestCases.UI
{
    public class GroupTests : LoginSteps
    {
        [Test]
        [Description("Create a group")]
        [Category("UI"), Category("Group")]
        [AllureSeverity(SeverityLevel.critical)]

        public void CreateGroup()
        {
            GroupModel newGroup = CreationHelper.CreateGroup(AccessTypes.Private);

            Login().GoToSalesPage();
            GroupsPage.OpenGroupsPage();

            List<string> groups = 
                EditCreationGroupPage.
                CreateNewGroup(newGroup).
                ConfirmCreationNewGroup().
                OpenGroupsPage().
                GetGroupsNames();

            Assert.Contains(newGroup.Name, groups);
        }

        [Test]
        [Description("Delete a group")]
        [Category("UI"), Category("Group")]
        [AllureSeverity(SeverityLevel.critical)]

        public void DeleteGroup() 
        {
            Login().GoToSalesPage();

            GroupModel group = new GroupModel()
            {
                Name = 
                GroupsPage.
                    OpenGroupsPage().
                    GetGroupsNames().
                    FirstOrDefault(),
            };

            GroupsPage.
                GoToGroupPageByGroupName(group).
                DeleteGroup();

            Assert.IsFalse(GroupsPage.DoesGroupNameExistInGroupsTable(group));
        }

        [Test]
        [Description("Edit a group")]
        [Category("UI"), Category("Group")]
        [AllureSeverity(SeverityLevel.critical)]

        public void EditGroup()
        {
            GroupModel newGroup = CreationHelper.CreateGroup(AccessTypes.Private);

            Login().GoToSalesPage();

            GroupModel oldGroup = 
                GroupsPage.
                    OpenGroupsPage().
                    EditGroupByGroupName("Yundt Inc and Sons");

            EditCreationGroupPage.
                FillUpFields(newGroup).
                ConfirmGroupChanges();

            Assert.IsFalse(GroupsPage.DoesGroupNameExistInGroupsTable(oldGroup));
            Assert.IsTrue(GroupsPage.DoesGroupNameExistInGroupsTable(newGroup));
        }
    }
}
