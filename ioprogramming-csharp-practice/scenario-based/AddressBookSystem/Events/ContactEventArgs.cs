using System;
using AddressBookSystem.Models;

namespace AddressBookSystem.Events
{
    public class ContactEventArgs : EventArgs
    {
        public Contact Contact;
        public ContactEventArgs(Contact c)
        {
            Contact = c;
        }
    }
}
