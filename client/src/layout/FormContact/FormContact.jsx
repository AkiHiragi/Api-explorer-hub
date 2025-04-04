import React, { useState } from "react";

const FormContact = (props) => {

    const [contactName, setContactName] = useState("");
    const [contactEmail, setContactEmail] = useState("");

    const submit = () => {
        if (contactName !== "" && contactEmail !== "")
            props.addContact(contactName, contactEmail);
        setContactName("");
        setContactEmail("");
    }

    return (
        <div>
            <div className="mb-3">
                <form>
                    <div className="mb-3">
                        <label className="form-label">Введите имя:</label>
                        <input className="form-control" type="text"
                            value={contactName}
                            onChange={(e) => setContactName(e.target.value)} />
                    </div>
                    <div className="mb-3">
                        <label className="form-label">Введите e-mail:</label>
                        <textarea className="form-control" rows={1}
                            value={contactEmail}
                            onChange={(e) => setContactEmail(e.target.value)} />
                    </div>
                </form>
            </div>
            <div>
                <button className="btn btn-primary"
                    onClick={submit}
                >
                    Добавить контакт
                </button>
            </div>
        </div>
    )
}

export default FormContact;