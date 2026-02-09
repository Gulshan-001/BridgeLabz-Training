namespace AddressBookSystem.Models
{
    public class Contact
    {
        public string FirstName;
        public string LastName;
        public string Address;
        public string City;
        public string State;
        public string Zip;
        public string Phone;
        public string Email;

        public string FullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
