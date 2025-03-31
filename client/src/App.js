import React, { useState } from "react";
import TableContact from "./layout/TableContact/TableContact";


const App = () => {

    const initialContacts = Array.from({ length: 3 }, (_, i) => (
        {
            id: i + 1,
            name: `Имя фамилия ${i + 1}`,
            email: `email${i + 1}@example.ru`
        }
    ));

    const [contacts, setContacts] = useState(initialContacts);

    function AddContact() {
        const newId = contacts.length > 0 ? Math.max(...contacts.map(c => c.id)) + 1 : 1;
        const contact = {
            id: newId,
            name: `Имя фамилия ${newId}`,
            email: `email${newId}@example.ru`
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
                    <div>
                        <button className="btn btn-primary" onClick={AddContact}>
                            Добавить контакт
                        </button>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default App;
