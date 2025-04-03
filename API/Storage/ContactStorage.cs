using Bogus;

public class InMemoryStorage : IStorage {

    private List<Contact> Contacts { get; set; }

    public InMemoryStorage() {
        this.Contacts = new List<Contact>();

        string Transliterate(string cyrillic) {
            var translitMap = new Dictionary<string, string>
            {
                {"а", "a"}, {"б", "b"}, {"в", "v"}, {"г", "g"}, {"д", "d"},
                {"е", "e"}, {"ё", "yo"}, {"ж", "zh"}, {"з", "z"}, {"и", "i"},
                {"й", "y"}, {"к", "k"}, {"л", "l"}, {"м", "m"}, {"н", "n"},
                {"о", "o"}, {"п", "p"}, {"р", "r"}, {"с", "s"}, {"т", "t"},
                {"у", "u"}, {"ф", "f"}, {"х", "kh"}, {"ц", "ts"}, {"ч", "ch"},
                {"ш", "sh"}, {"щ", "shch"}, {"ъ", ""}, {"ы", "y"}, {"ь", ""},
                {"э", "e"}, {"ю", "yu"}, {"я", "ya"}
            };

            return string.Concat(cyrillic.ToLower().Select(c => translitMap.TryGetValue(c.ToString(), out var latChar) ? latChar : c.ToString().Replace(" ", "")));
        }

        var faker = new Faker<Contact>("ru")
            .RuleFor(c => c.Id, f => f.IndexGlobal + 1)
            .RuleFor(c => c.Name, f => f.Name.FullName())
            .RuleFor(c => c.Email, f => {
                var fullName = f.Name.FullName().Split();
                return $"{Transliterate(fullName[0])}.{Transliterate(fullName[1])}@example.com".ToLower();
            });

        Contacts.AddRange(faker.Generate(10));
    }

    public List<Contact> GetContacts() {
        return this.Contacts;
    }

    public bool Add(Contact contact) {
        if (!Contacts.Any(el => el.Id == contact.Id)) {
            Contacts.Add(contact);
            return true;
        }
        return false;
    }

    public Contact GetContact(int id) {
        return Contacts.FirstOrDefault(item => item.Id == id);
    }

    public bool Remove(int id) {
        foreach (var contact in Contacts) {
            if (contact.Id == id) {
                Contacts.Remove(contact);
                return true;
            }
        }
        return false;
    }

    public bool Update(int id, ContactDto contact) {
        for (int i = 0; i < Contacts.Count; i++) {
            if (Contacts[i].Id == id) {
                if (!string.IsNullOrWhiteSpace(contact.Name))
                    Contacts[i].Name = contact.Name;
                if (!string.IsNullOrWhiteSpace(contact.Email))
                    Contacts[i].Email = contact.Email;
                return true;
            }
        }
        return false;
    }
}