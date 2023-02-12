namespace Learn_and_Play___Architecture___AL.VM
{
    public class UserVM
    {
        public string Name { get; set; }
        public IEnumerable<ContactVM> Contacts { get; set; }
    }

    public class ContactVM 
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
