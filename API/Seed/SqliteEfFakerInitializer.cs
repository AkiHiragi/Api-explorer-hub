
using Bogus;
using Microsoft.EntityFrameworkCore;

public class SqliteEfFakerInitializer : IInitializer {
    private readonly SqliteDBContext context;

    public SqliteEfFakerInitializer(SqliteDBContext context) {
        this.context = context;
    }

    private string GenerateEmailFromName(string name) {
        return Transliterate(name)
            .ToLower()
            .Replace(" ", ".") + "@example.com";
    }

    private string Transliterate(string cyrillic) {
        var translitMap = new Dictionary<string, string>
        {
            {"а", "a"}, {"б", "b"}, {"в", "v"}, {"г", "g"}, {"д", "d"},
            {"е", "e"}, {"ё", "yo"}, {"ж", "zh"}, {"з", "z"}, {"и", "i"},
            {"й", "y"}, {"к", "k"}, {"л", "l"}, {"м", "m"}, {"н", "n"},
            {"о", "o"}, {"п", "p"}, {"р", "r"}, {"с", "s"}, {"т", "t"},
            {"у", "u"}, {"ф", "f"}, {"х", "kh"}, {"ц", "ts"}, {"ч", "ch"},
            {"ш", "sh"}, {"щ", "shch"}, {"ъ", ""}, {"ы", "y"}, {"ь", ""},
            {"э", "e"}, {"ю", "yu"}, {"я", "ya"}, {" "," "}
        };

        return string.Concat(cyrillic.ToLower().Select(c => translitMap.TryGetValue(c.ToString(), out var latChar) ? latChar : c.ToString().Replace(" ", "")));
    }

    public void Initialize() {
        context.Database.Migrate();
        if (!context.Contacts.Any()) {
            var faker = new Faker<Contact>("ru")
                .RuleFor(c => c.Name, f => f.Name.FullName())
                .RuleFor(c => c.Email, (f, c) => GenerateEmailFromName(c.Name));

            var contacts = faker.Generate(20);
            context.Contacts.AddRange(contacts);
            context.SaveChanges();
        }
    }
}
