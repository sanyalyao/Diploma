namespace BussinesObject.UI.Models
{
    public class AccountModel
    {
        public string AccountName;
        public string Phone;
        public string AccountNumber;
        public string Address;
        public string BillingStreet;
        public string BillingZip;
        public string BillingCity;
        public string BillingCountry;

        public AccountModel(string accountName, string phone, string accountNumber, string street, string zip, string city, string country)
        {
            AccountName = accountName;
            Phone = phone;
            AccountNumber = accountNumber;
            BillingStreet = street;
            BillingZip = zip;
            BillingCity = city;
            BillingCountry = country;
            Address = $"{street}{zip}{city}{country}".Replace(" ", "");
        }

        public AccountModel(string accountName, string phone, string accountNumber, string address)
        {
            AccountName = accountName;
            Phone = phone;
            AccountNumber = accountNumber;
            Address = address;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }
            if (object.ReferenceEquals(this, obj)) { return true; }

            AccountModel account = obj as AccountModel;

            return AccountName == account.AccountName
                && Phone == account.Phone
                && AccountNumber == account.AccountNumber
                && Address == account.Address;
        }

        public override int GetHashCode()
        {
            return $"{AccountName}{Phone}{AccountNumber}{Address}".GetHashCode();
        }

        public override string ToString()
        {
            return $"{AccountName} {Phone} {AccountNumber} {Address}";
        }
    }
}
