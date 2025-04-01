import React, { useState } from "react";
import TableContact from "./layout/TableContact/TableContact";
import FormContact from "./layout/FormContact/FormContact";


const App = () => {

    const [contacts, setContacts] = useState([
        { id: 21, name: `Имя фамилия 1`, email: `q@e1rt` },
        { id: 12, name: `Имя фамилия 2`, email: `q@e2rt` },
        { id: 6, name: `Имя фамилия 3`, email: `q@e3rt` }
    ]);

    const addContact = (contactName, contactEmail) => {
        const newId = contacts.length > 0 ? Math.max(...contacts.map(c => c.id)) + 1 : 1;
        const contact = {
            id: newId,
            name: contactName,
            email: contactEmail
        };
        setContacts([...contacts, contact]);
    }

    const deleteContact = (id) => {
        setContacts(contacts.filter(item => item.id !== id));
    }

    return (
        <div className="container mt-5">
            <div className="card">
                <div className="card-header">
                    <h1>Список контактов</h1>
                </div>
                <div className="card-body">
                    <TableContact
                        contacts={contacts}
                        deleteContact={deleteContact}
                    />
                    <FormContact addContact={addContact} />

                </div>
            </div>
        </div>
    );
}

export default App;
