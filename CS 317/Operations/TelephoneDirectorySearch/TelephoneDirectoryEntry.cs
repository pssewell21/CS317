namespace CS317Program.Operations.TelephoneDirectorySearch
{
    class TelephoneDirectoryEntry
    {
        private string _name;
        private string _phoneNumber;

        public TelephoneDirectoryEntry(string name, string phoneNumber)
        {
            _name = name;
            _phoneNumber = phoneNumber;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetPhoneNumber()
        {
            return _phoneNumber;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", _name, _phoneNumber);
        }
    }
}
