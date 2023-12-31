﻿using NUnit.Framework;
using BussinesObject.UI.Models;
using BussinesObject.UI.Helpers;
using BussinesObject.UI.Pages.GroupPages;
using BussinesObject.UI.Models.EnumObjects;
using Allure.Net.Commons;
using NUnit.Allure.Attributes;

namespace TestCases.UI.NegativeTests
{
    public class GroupTests : LoginSteps
    {
        [Test]
        [Description("Checking a negative push message when name is not filled up and access type is chosen")]
        [Category("UI"), Category("Group"), Category("Negative")]
        [AllureSeverity(SeverityLevel.normal)]

        public void CreateGroupWithoutName()
        {
            GroupModel newGroup = CreationHelper.CreateGroup(AccessTypes.Public);
            newGroup.Name = string.Empty;

            Login().GoToSalesPage();
            GroupsPage.OpenGroupsPage();
            EditCreationGroupPage.CreateNewGroup(newGroup);
            EditCreationGroupPageSteps.CheckIfErrorExistByText("These required fields must be completed: Name");
        }

        [Test]
        [Description("Checking a negative push message when name is filled up and access type is not chosen")]
        [Category("UI"), Category("Group"), Category("Negative")]
        [AllureSeverity(SeverityLevel.normal)]

        public void CreateGroupWithoutAccessType()
        {
            GroupModel newGroup = CreationHelper.CreateGroup(AccessTypes.None);

            Login().GoToSalesPage();
            GroupsPage.OpenGroupsPage();
            EditCreationGroupPage.CreateNewGroup(newGroup);
            EditCreationGroupPageSteps.CheckIfErrorExistByText("These required fields must be completed: Access Type");
        }

        [Test]
        [Description("Checking a negative push message when name is not filled up and access type is not chosen")]
        [Category("UI"), Category("Group"), Category("Negative")]
        [AllureSeverity(SeverityLevel.normal)]

        public void CreateGroupWithEmptyFields()
        {
            GroupModel newGroup = CreationHelper.CreateGroup(AccessTypes.None);
            newGroup.Name = string.Empty;

            Login().GoToSalesPage();
            GroupsPage.OpenGroupsPage();
            EditCreationGroupPage.CreateNewGroup(newGroup);
            EditCreationGroupPageSteps.CheckIfErrorExistByText("These required fields must be completed: Access Type, Name");
        }
    }
}
