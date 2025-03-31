const App = () => {
    return (
        <div className="container mt-5">
            <div className="card">
                <div className="card-header">
                    <h1>Список контактов</h1>
                </div>
                <div className="card-body">
                    <table className="table table-hover">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Имя контакта</th>
                                <th>E-mail</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>1</td>
                                <td>Имя фамилия 1</td>
                                <td>email@example.ru1</td>
                            </tr>

                            <tr>
                                <td>2</td>
                                <td>Имя фамилия 2</td>
                                <td>email@example.ru2</td>
                            </tr>

                            <tr>
                                <td>3</td>
                                <td>Имя фамилия 3</td>
                                <td>email@example.ru3</td>
                            </tr>

                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    );
}

export default App;
