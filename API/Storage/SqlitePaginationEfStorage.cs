using Microsoft.AspNetCore.Mvc;

public class SqlitePaginationEfStorage : SqliteEfStorage, IPaginationStorage {

    public SqlitePaginationEfStorage(SqliteDBContext context) : base(context) { }

    public Contact GetContactById(int id) {
        return base.context.Contacts.Find(id);
    }
}