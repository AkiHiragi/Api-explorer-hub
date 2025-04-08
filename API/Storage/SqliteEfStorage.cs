
public class SqliteEfStorage : IStorage {
    protected readonly SqliteDBContext context;

    public SqliteEfStorage(SqliteDBContext context) {
        this.context = context;
    }

    public Contact Add(Contact contact) {
        context.Contacts.Add(contact);
        context.SaveChanges();
        return contact;
    }

    public List<Contact> GetContacts() {
        return context.Contacts.ToList();
    }

    public bool Remove(int id) {
        var contact = context.Contacts.Find(id);
        if (contact == null)
            return false;
        context.Contacts.Remove(contact);
        context.SaveChanges();
        return true;
    }

    public bool Update(int id, ContactDto contactDto) {
        var contact = context.Contacts.Find(id);
        if (contact == null)
            return false;
        contact.Name = contactDto.Name;
        contact.Email = contactDto.Email;
        context.SaveChanges();
        return true;
    }
}
