using NUnit.Framework;
using BussinesObject.UI.Models;
using BussinesObject.UI.Helpers;
using BussinesObject.UI.Pages.GroupPages;
using BussinesObject.UI.Models.EnumObjects;

namespace TestCases.UI
{
    public class GroupTests : LoginSteps
    {
        [Test]
        public void CreateGroup()
        {
            GroupModel newGroup = CreationHelper.CreateGroup(AccessTypes.Private);

            Login().GoToSalesPage();
            GroupsPage.OpenGroupsPage();

            List<string> groups = EditCreationGroupPage.CreateNewGroup(newGroup).ConfirmCreationNewGroup().OpenGroupsPage().ReloadCurrentPage().GetGroupsNames();

            Assert.Contains(newGroup.Name, groups);
        }

        [Test]
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
