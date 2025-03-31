import React, { useState } from "react";
import TableContact from "./layout/TableContact/TableContact";
import FormContact from "./layout/FormContact/FormContact";


const App = () => {

    const initialContacts = Array.from({ length: 3 }, (_, i) => (
        {
            id: i + 1,
            name: `Имя фамилия ${i + 1}`,
            email: `email${i + 1}@example.ru`
        }
    ));

    const [contacts, setContacts] = useState(initialContacts);

    function addContact(contactName, contactEmail) {
        const newId = contacts.length > 0 ? Math.max(...contacts.map(c => c.id)) + 1 : 1;
        const contact = {
            id: newId,
            name: contactName,
            email: contactEmail
        };
        setContacts([...contacts, contact]);
    }

    return (
        <div className="container mt-5">
            <div className="card">
                <div className="card-header">
                    <h1>Список контактов</h1>
                </div>
                <div className="card-body">
                    <TableContact contacts={contacts} />
                    <FormContact addContact={addContact} />

                </div>
            </div>
        </div>
    );
}

export default App;
