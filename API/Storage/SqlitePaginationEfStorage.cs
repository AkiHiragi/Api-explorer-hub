using Microsoft.AspNetCore.Mvc;

public class SqlitePaginationEfStorage : SqliteEfStorage, IPaginationStorage {

    public SqlitePaginationEfStorage(SqliteDBContext context) : base(context) { }

    public Contact GetContactById(int id) {
        return base.context.Contacts.Find(id);
    }

    public (List<Contact>, int TotalCount) GetContacts(int pageNumber, int pageSize) {
        int total = base.context.Contacts.Count();

        List<Contact> contacts = context.Contacts
                                        .Skip((pageNumber - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToList();
        return (contacts, total);
    }
}