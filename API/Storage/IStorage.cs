public interface IStorage {
    List<Contact> GetContacts();
    Contact Add(Contact contact);
    bool Remove(int id);
    bool Update(int id, ContactDto contact);
}
