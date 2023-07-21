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
        [Order(1)]
        [AllureSeverity(SeverityLevel.critical)]

        public void CreateGroup()
        {
            GroupModel newGroup = CreationHelper.CreateGroup(AccessTypes.Private);

            Login().GoToSalesPage();
            GroupsPage.OpenGroupsPage();

            List<string> groups = EditCreationGroupPage.CreateNewGroup(newGroup).ConfirmCreationNewGroup().OpenGroupsPage().ReloadCurrentPage().GetGroupsNames();

            Assert.Contains(newGroup.Name, groups);
        }

        [Test]
        [Description("Delete a group")]
        [Category("UI"), Category("Group")]
        [Order(3)]
        [AllureSeverity(SeverityLevel.critical)]

        public void DeleteGroup() 
        {
            Login().GoToSalesPage();

            GroupModel group = new GroupModel()
            {
                Name = GroupsPage.OpenGroupsPage().GetGroupsNames()[0],
            };

            GroupsPage.TakeGroup(0).DeleteGroup().ReloadCurrentPage();

            Assert.IsFalse(GroupsPage.DoesGroupNameExistInTable(group));
        }

        [Test]
        [Description("Edit a group")]
        [Category("UI"), Category("Group")]
        [Order(2)]
        [AllureSeverity(SeverityLevel.critical)]

        public void EditGroup()
        {
            Login().GoToSalesPage();

            GroupModel oldGroup = GroupsPage.OpenGroupsPage().EditGroup(0).GetGroupInfo();
            GroupModel newGroup = CreationHelper.CreateGroup(AccessTypes.Private);

            EditCreationGroupPage.FillUpFields(newGroup).ConfirmGroupChanges().ReloadCurrentPage();

            Assert.IsFalse(GroupsPage.DoesGroupNameExistInTable(oldGroup));
            Assert.IsTrue(GroupsPage.DoesGroupNameExistInTable(newGroup));
        }
    }
}
