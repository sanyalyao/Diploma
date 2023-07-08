namespace BussinesObject.UI.Models
{
    public class ContactModel
    {
        public string FullName;
        public string FirstName;
        public string LastName;
        public string Mobile;
        public string Email;
        public string Address;
        public string MailingStreet;
        public string MailingZip;
        public string MailingCity;
        public string MailingCountry;

        public ContactModel(string firstname, string lastname, string mobile, string email, string street, string zip, string city, string country)
        {
            FirstName = firstname;
            LastName = lastname;
            FullName = $"{firstname}{lastname}".Replace(" ","");
            Mobile = mobile;
            Email = email;
            MailingStreet = street;
            MailingZip = zip;
            MailingCity = city;
            MailingCountry = country;
            Address = $"{street}{zip}{city}{country}".Replace(" ", "");
        }

        public ContactModel(string fullname, string mobile, string email, string address)
        {
            FullName = fullname;
            Mobile = mobile;
            Email = email;
            Address = address;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }
            if (object.ReferenceEquals(this, obj)) { return true; }

            ContactModel contact = obj as ContactModel;

            return FullName == contact.FullName
                && Mobile == contact.Mobile
                && Email == contact.Email
                && Address == contact.Address;
        }

        public override int GetHashCode()
        {
            return $"{FullName}{Mobile}{Email}{Address}".GetHashCode();
        }

        public override string ToString()
        {
            return $"{FullName} {Mobile} {Email} {Address}";
        }
    }
}
