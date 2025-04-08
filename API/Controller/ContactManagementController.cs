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
    public ActionResult<List<Contact>> GetContacts() {
        return Ok(storage.GetContacts());
    }

    [HttpGet("contacts/{id}")]
    public ActionResult<Contact> GetContactById(int id) {
        return storage.GetContactById(id) != null ?
            Ok(storage.GetContactById(id))
            : NotFound();
    }

    [HttpDelete("contacts/{id}")]
    public ActionResult DeleteContact(int id) {
        return storage.Remove(id) ?
        NoContent() :
        Conflict("Контакта с указанным ID не существует");
    }

    [HttpPut("contacts/{id}")]
    public ActionResult UpdateContact(int id, [FromBody] ContactDto contact) {
        return storage.Update(id, contact) ?
        Ok(id) :
        Conflict("Контакта с указанным ID не существует");
    }
}