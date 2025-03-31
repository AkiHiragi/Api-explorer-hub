import TableContact from "./layout/TableContact/TableContact";

const contacts = [
    { id: 1, name: `Имя фамилия 1`, email: `email1@example.ru` },
    { id: 2, name: `Имя фамилия 2`, email: `email2@example.ru` },
    { id: 3, name: `Имя фамилия 3`, email: `email3@example.ru` },
]

const App = () => {
    return (
        <div className="container mt-5">
            <div className="card">
                <div className="card-header">
                    <h1>Список контактов</h1>
                </div>
                <div className="card-body">
                    <TableContact contacts={contacts} />
                </div>
            </div>
        </div>
    );
}

export default App;
