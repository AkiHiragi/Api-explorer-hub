
using Microsoft.Data.Sqlite;

public class SqliteStorage : IStorage {

    private string connectionString = @"Data Source=contacts.db";

    public bool Add(Contact contact) {
        throw new NotImplementedException();
    }

    public Contact GetContact(int id) {
        throw new NotImplementedException();
    }

    public List<Contact> GetContacts() {
        var contacts = new List<Contact>();

        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM contacts";

        using var reader = command.ExecuteReader();
        while (reader.Read()) {
            contacts.Add(new Contact {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Email = reader.GetString(2)
            });
        }

        return contacts;
    }

    public bool Remove(int id) {
        throw new NotImplementedException();
    }

    public bool Update(int id, ContactDto contact) {
        throw new NotImplementedException();
    }
}