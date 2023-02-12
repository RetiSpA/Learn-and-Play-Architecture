namespace Learn_and_Play___Architecture___DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}