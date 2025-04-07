public interface IStorage {
    List<Contact> GetContacts();
    Contact GetContact(int id);
    Contact Add(Contact contact);
    bool Remove(int id);
    bool Update(int id, ContactDto contact);
}
