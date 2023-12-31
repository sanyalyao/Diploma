﻿using Faker;
using BussinesObject.UI.Models;
using BussinesObject.UI.Models.EnumObjects;
using BussinesObject.API.Models.TaskObjects;

namespace BussinesObject.UI.Helpers
{
    public class CreationHelper
    {
        public static AccountModel CreateAccount()
        {
            string accountName = Company.Name();
            string phone = Phone.Number();
            string accountNumber = Identification.SocialSecurityNumber(false);
            string billingStreet = Address.StreetAddress();
            string billingCity = Address.City();
            string billingCountry = Address.Country();
            string billingZip = Address.ZipCode();

            AccountModel account = new AccountModel(accountName, phone, accountNumber, billingStreet, billingZip, billingCity, billingCountry);

            return account;
        }

        public static ContactModel CreateContact()
        {
            string firstname = Name.First();
            string lastname = Name.Last();
            string mobile = Phone.Number();
            string email = Internet.Email();
            string street = Address.StreetAddress();
            string city = Address.City();
            string country = Address.Country();
            string zip = Address.ZipCode();

            ContactModel contact = new ContactModel(firstname, lastname, mobile, email, street, zip, city, country);

            return contact;
        }

        public static GroupModel CreateGroup(AccessTypes accessTypes) 
        {
            string groupName = Company.Name();
            var accessType = System.Enum.GetName(typeof(AccessTypes), accessTypes);

            GroupModel newGroup = new GroupModel()
            {
                Name = groupName,
                AccessType = accessType,
            };

            return newGroup;
        }
    }
}
