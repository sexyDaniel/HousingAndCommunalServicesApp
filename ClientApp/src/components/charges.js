import React from 'react';

export default class Charges extends React.Component {
    render() {
        return <div>
            <h1>Начисления</h1>
            <div className="owner-info">
                <h4>Собственник: Иванов Иван Петрович</h4>
                <h4>Проживает: г.Москва ул.Горького 25, д.15</h4>
            </div>
            <div className="row charge-tabs">
                <div className="col-9 charge-tables">
                    <div className="charge-info shadow charge-table">
                        <div className="service-company">
                            <h5>Название: ООО "Обслуживающая компания"</h5>
                            <h5>Телефон: 88005553535</h5>
                        </div>
                        <div className="charge">
                            <h6>Дата начисления: Февраль 2021</h6>
                            <table className="table table-primary">
                                <thead>
                                    <tr>
                                        <th>Вид платежа</th>
                                        <th>Единицы измерения</th>
                                        <th>Кол-во ед. изм.</th>
                                        <th>Размер платы (руб/ед изм.)</th>
                                        <th>Начисленно фактически</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Обращение с ТКО</td>
                                        <td>куб. м</td>
                                        <td>444</td>
                                        <td>567</td>
                                        <td>4900</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <div className="charge-info shadow charge-table">
                        <div className="service-company">
                            <h5>Название: ООО "Газовая компания"</h5>
                            <h5>Телефон: 893290023677</h5>
                        </div>
                        <div className="charge">
                            <h6>Дата начисления: Февраль 2021</h6>
                            <table className="table table-primary">
                                <thead>
                                    <tr>
                                        <th>Вид платежа</th>
                                        <th>Единицы измерения</th>
                                        <th>Кол-во ед. изм.</th>
                                        <th>Размер платы (руб/ед изм.)</th>
                                        <th>Начисленно фактически</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Обращение с ТКО</td>
                                        <td>куб. м</td>
                                        <td>444</td>
                                        <td>567</td>
                                        <td>4900</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <div className="charge-info shadow charge-table">
                        <div className="service-company">
                            <h5>Название: ООО "Обслуживающая компания"</h5>
                            <h5>Телефон: 88005553535</h5>
                        </div>
                        <div className="charge">
                            <h6>Дата начисления: Февраль 2021</h6>
                            <table className="table table-primary">
                                <thead>
                                    <tr>
                                        <th>Вид платежа</th>
                                        <th>Единицы измерения</th>
                                        <th>Кол-во ед. изм.</th>
                                        <th>Размер платы (руб/ед изм.)</th>
                                        <th>Начисленно фактически</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Обращение с ТКО</td>
                                        <td>куб. м</td>
                                        <td>444</td>
                                        <td>567</td>
                                        <td>4900</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div className="col-3">
                    <h3>Фильтр</h3>
                    <form className="charge-form">
                        <span>С:</span><input type="month" className="form-control" />
                        <span>По:</span><input type="month" className="form-control" />
                        <button className="btn btn-primary">Вывести все начисления</button>
                    </form>
                </div>
            </div>
        </div>;
    }
}