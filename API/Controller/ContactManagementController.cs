using Microsoft.AspNetCore.Mvc;

public class ContactManagementController : BaseController {

    private readonly IPaginationStorage storage;

    public ContactManagementController(IPaginationStorage storage) {
        this.storage = storage;
    }

    [HttpPost("contacts")]
    public IActionResult CreateContact([FromBody] Contact contact) {
        return (storage.Add(contact) != null) ?
        Ok(contact) :
        Conflict("Контакт с указанным ID существует");
    }

    [HttpGet("contacts")]
    public IActionResult GetContacts() {
        return Ok(storage.GetContacts());
    }

    [HttpGet("contacts/page")]
    public IActionResult GetContacts(int pageNumber = 1, int pageSize = 5) {
        var (contacts, total) = storage.GetContacts(pageNumber, pageSize);
        var response = new {
            Contacts = contacts,
            TotalCount = total,
            CurrentPage = pageNumber,
            PageSize = pageSize
        };
        return Ok(response);
    }

    [HttpGet("contacts/{id}")]
    public IActionResult GetContactById(int id) {
        return storage.GetContactById(id) != null ?
            Ok(storage.GetContactById(id))
            : NotFound();
    }

    [HttpDelete("contacts/{id}")]
    public IActionResult DeleteContact(int id) {
        return storage.Remove(id) ?
        NoContent() :
        Conflict("Контакта с указанным ID не существует");
    }

    [HttpPut("contacts/{id}")]
    public IActionResult UpdateContact(int id, [FromBody] ContactDto contact) {
        return storage.Update(id, contact) ?
        Ok(id) :
        Conflict("Контакта с указанным ID не существует");
    }
}