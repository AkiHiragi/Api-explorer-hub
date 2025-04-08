using Microsoft.Data.Sqlite;

public class SqliteStorage : IStorage {

    private readonly string connectionString;

    public SqliteStorage(string connectionString) {
        this.connectionString = connectionString;
    }

    public Contact Add(Contact contact) {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        string sql = @"INSERT INTO contacts(name, email) VALUES (@name, @email);
            SELECT last_insert_rowid()";
        command.CommandText = sql;
        command.Parameters.AddWithValue("@name", contact.Name);
        command.Parameters.AddWithValue("@email", contact.Email);

        contact.Id = Convert.ToInt32(command.ExecuteScalar());

        return contact;
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
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM contacts WHERE id=@id";
        command.Parameters.AddWithValue("@id", id);

        return command.ExecuteNonQuery() > 0;

    }

    public bool Update(int id, ContactDto contact) {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = @"
            UPDATE contacts
            SET
                name=@name,
                email=@email
            WHERE id=@id;";

        command.Parameters.AddWithValue("@name", contact.Name);
        command.Parameters.AddWithValue("@email", contact.Email);
        command.Parameters.AddWithValue("@id", id);


        return command.ExecuteNonQuery() > 0;
    }
}